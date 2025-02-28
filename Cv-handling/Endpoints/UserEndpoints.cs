using Cv_handling.Data;
using Cv_handling.DTOs.DTOs;
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
        app.MapGet("/users", async (CvDbContext context) =>
        {

            var userList = await context.Users.Include(u=>u.Experiences).Select(u => new UserDTO
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
                        Duration = e.Work.Duration,
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
            
            return Results.Ok(userList);
        });

        app.MapPost("/users", async (UserCreateDTO newUser, UserService userService, CvDbContext context ) =>
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
                PhoneNumber = newUser.Phonenumber,
                Adress = newUser.Adress
            };
            context.Users.Add(user);
            await context.SaveChangesAsync();
            
            return Results.Created($"/users/{user.UserId}", new UserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserEmail = user.Email,
            });
        });


    }
}