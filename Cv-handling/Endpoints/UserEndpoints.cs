using Cv_handling.Data;
using Cv_handling.DTOs.DTOs;
using Cv_handling.DTOs.UserDtos;
using Cv_handling.Models;
using Cv_handling.Services;
using Microsoft.EntityFrameworkCore;

namespace Cv_handling.Endpoints;

public class UserEndpoints
{
    List<User> users = new List<User>();
    public void RegisterEndpoints(WebApplication app)
    {
        var validator = new UserService.UserCreateDTOValidator();
        app.MapGet("/users", async (CvDbContext context) =>
        {
            var userList = await context.Users.Select(u => new UserDTO
            {
                
            }).ToListAsync();
        });

        app.MapPost("/users", (UserCreateDTO newUser) =>
        {
            var validationResult = validator.Validate(newUser);
            if(!validationResult.IsValid)
                return Results.BadRequest(new { validationResult.Errors });
            
            var user = new User
            {
                UserId = new Random().Next(1, 1000),
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                Birthday = default,
                PhoneNumber = 0
            };
            users.Add(user);
            return Results.Created($"/users/{user.UserId}", new UserDTO
            {
                UserName = user.FirstName,
                UserEmail = user.Email,
            });
        });


    }
}