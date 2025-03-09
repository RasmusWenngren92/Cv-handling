using System.ComponentModel.DataAnnotations;
using Cv_handling.Data;
using Cv_handling.DTOs;
using Cv_handling.Models;
using Cv_handling.Services;
using Microsoft.EntityFrameworkCore;

namespace Cv_handling.Endpoints;

public static class UserEndpoints
{
    public static RouteGroupBuilder MapUserEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/GetUsers", async (UserService userServices) =>
        {
            try
            {
                var users = await userServices.GetUsers();
                return Results.Ok(users);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e}");

                return Results.Problem(
                    title: "An unexpected error occurred.",
                    detail: "Something went wrong while fetching data.",
                    statusCode: StatusCodes.Status500InternalServerError,
                    instance: "/user"
                );
            }
        });

        group.MapGet("/user/{id:int}", async (CvDbContext ctx, int id) =>
        {
            try
            {
                var user = await ctx.Users
                    .Where(e => e.UserId == id)
                    .Select(u => new UserDto
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        EmailAddress = u.EmailAddress,
                        PhoneNumber = u.PhoneNumber
                    }).FirstOrDefaultAsync();

                return user is not null ? Results.Ok(user) : Results.NotFound($"User with id {id} not found");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e}");

                return Results.Problem(
                    title: "An unexpected error occurred.",
                    detail: "Something went wrong while fetching data.",
                    statusCode: StatusCodes.Status500InternalServerError,
                    instance: "/user"
                );
            }
        });

        group.MapPost("/user", async (CvDbContext ctx, CreateUserDto newUser) =>
        {
            try
            {
                var validationContext = new ValidationContext(newUser);
                var validationResult = new List<ValidationResult>();

                var isValid = Validator.TryValidateObject(newUser, validationContext, validationResult, true);

                if (!isValid)
                    return Results.BadRequest(validationResult.Select(e => e.ErrorMessage));

                var user = new User
                {
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    EmailAddress = newUser.EmailAddress,
                    PhoneNumber = newUser.PhoneNumber
                };

                ctx.Users.Add(user);
                await ctx.SaveChangesAsync();

                var responsDto = new UserResponseDto
                {
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    EmailAddress = newUser.EmailAddress,
                    PhoneNumber = newUser.PhoneNumber
                };

                return Results.Created($"/api/user/{user.UserId}", responsDto);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e}");

                return Results.Problem(
                    title: "An unexpected error occurred.",
                    detail: e.Message,
                    statusCode: StatusCodes.Status500InternalServerError,
                    instance: "/user"
                );
            }
        });

        group.MapPut("/user/{id:int}", async (CvDbContext ctx, int id, UpdateUserDto user) =>
        {
            try
            {
                var existingUser = await ctx.Users.FirstOrDefaultAsync(u => u.UserId == id);
                if (existingUser == null)
                    return Results.NotFound($"User with id {id} not found");

                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.EmailAddress = user.EmailAddress;
                existingUser.PhoneNumber = user.PhoneNumber;

                var validationContext = new ValidationContext(existingUser);
                var validationResults = new List<ValidationResult>();
                if (!Validator.TryValidateObject(existingUser, validationContext, validationResults, true))
                    return Results.BadRequest(validationResults.Select(r => r.ErrorMessage));

                await ctx.SaveChangesAsync();

                var responseDto = new UserDto
                {
                    FirstName = existingUser.FirstName,
                    LastName = existingUser.LastName,
                    EmailAddress = existingUser.EmailAddress,
                    PhoneNumber = existingUser.PhoneNumber
                };
                return Results.Ok(responseDto);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e}");

                return Results.Problem(
                    title: "An unexpected error occurred.",
                    detail: "Something went wrong while fetching data.",
                    statusCode: StatusCodes.Status500InternalServerError,
                    instance: "/user"
                );
            }
        });

        group.MapGet("/user/{id:int}/detail", async (CvDbContext ctx, int id) =>
        {
            var user = await ctx.Users
                .Where(u => u.UserId == id)
                .Include(u => u.Educations)
                .Include(u => u.Works)
                .FirstOrDefaultAsync();

            if (user is null)
                return Results.NotFound($"User with id {id} not found");

            var userDetails = new UserDetailResponseDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                PhoneNumber = user.PhoneNumber,
                Educations = user.Educations.Select(e => new EducationsResponseDto
                {
                    SchoolName = e.SchoolName,
                    Degree = e.Degree,
                    StartYear = e.StartYear,
                    GraduationYear = e.GraduationYear
                }).ToList(),
                Works = user.Works.Select(e => new WorkResponseDto
                {
                    Title = e.Title,
                    Company = e.Company,
                    Description = e.Description,
                    StartYear = e.StartYear,
                    EndYear = e.EndYear
                }).ToList()
            };
            return Results.Ok(userDetails);
        });

        group.MapDelete("/user/{id:int}", async (CvDbContext ctx, int id) =>
        {
            try
            {
                var user = await ctx.Users.FirstOrDefaultAsync(u => u.UserId == id);

                if (user == null)
                    return Results.NotFound($"User with id {id} not found");

                ctx.Users.Remove(user);
                await ctx.SaveChangesAsync();

                return Results.Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e}");

                return Results.Problem(
                    title: "An unexpected error occurred.",
                    detail: "Something went wrong while fetching data.",
                    statusCode: StatusCodes.Status500InternalServerError,
                    instance: "/user"
                );
            }
        });

        return group;
    }
}