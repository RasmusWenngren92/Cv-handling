using Cv_handling.Data;
using Cv_handling.DTOs.EducationDTOs;
using Cv_handling.DTOs.ExperienceDTOs;
using Cv_handling.DTOs.UserDTOs;
using Cv_handling.DTOs.WorkDTOs;
using Cv_handling.Models;
using Cv_handling.Services;
using Microsoft.EntityFrameworkCore;

namespace Cv_handling.Endpoints;

public class UserEndpoints
{
    public static void RegisterEndpoints(WebApplication app)
    {
        app.MapGet("/users", async (CvDbContext context, int page = 1, int pageSize = 10) =>
        {
            try
            {
                var userList = await context.Users.Include(u => u.Experiences)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(u => new UserDTO
                    {
                        UserId = u.UserId,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Experiences = u.Experiences.Select(e => new ExperienceDTO
                        {
                            ExperienceId = e.ExperienceId,
                            Work = new WorkDTO
                            {
                                WorkId = e.Work.WorkId,
                                CompanyName = e.Work.CompanyName,
                                WorkTitle = e.Work.WorkTitle,
                                Description = e.Work.Description,
                                Duration = e.Work.Duration
                            },
                            Education = new EducationDTO
                            {
                                EducationId = e.Education.EducationId,
                                SchoolName = e.Education.SchoolName,
                                StartDate = e.Education.StartDate,
                                GraduationDate = e.Education.GraduationDate
                            }
                        }).ToList()
                    }).ToListAsync();
                return userList.Count == 0 ? Results.NotFound("No users found") : Results.Ok(userList);
            }
            catch (Exception)
            {
                return Results.StatusCode(500);
            }
        });

        app.MapPost("/users", async (UserCreateDTO newUser, UserService userService, CvDbContext context) =>
        {
            try
            {
                var (isValid, message) = userService.ValidateUser(newUser);

                if (!isValid)
                    return Results.BadRequest(new { Message = message });

                var user = new User
                {
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    Email = newUser.Email,
                    Birthday = newUser.Birthday,
                    PhoneNumber = newUser.PhoneNumber
                };
                context.Users.Add(user);
                await context.SaveChangesAsync();

                return Results.Created($"/users/{user.UserId}", new UserDTO
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                });
            }
            catch (Exception )
            {
                return Results.StatusCode(500);
            }
        });

        app.MapPut("/users/{id:int}", async (CvDbContext context, int id, User user) =>
        {
            try
            {
                var existingUser = await context.Users.FirstOrDefaultAsync(u => u.UserId == id);

                if (existingUser == null) return Results.NotFound($"User with ID {id} not found");

                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                existingUser.Birthday = user.Birthday;
                existingUser.PhoneNumber = user.PhoneNumber;

                context.Users.Update(existingUser);

                await context.SaveChangesAsync();
                return Results.NoContent();
            }
            catch (Exception )
            {
                return Results.StatusCode(500);
            }
        });

        app.MapDelete("/users/{id:int}", async (CvDbContext context, int id) =>
        {
            try
            {
                var existingUser = await context.Users.FirstOrDefaultAsync(u => u.UserId == id);
                if (existingUser == null) return Results.NotFound($"User with ID {id} not found");
                context.Users.Remove(existingUser);
                await context.SaveChangesAsync();
                return Results.NoContent();
            }
            catch (Exception )
            {
                return Results.StatusCode(500);
            }
        });
    }
}