using Cv_handling.Data;
using Cv_handling.DTOs.DTOs;
using Cv_handling.DTOs.UserDTOs;
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
            var userList = await context.Users.Select(u => new UserDTO
            {
                
            }).ToListAsync();
            return userList;
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
                UserName = user.FirstName,
                UserEmail = user.Email,
            });
        });


    }
}