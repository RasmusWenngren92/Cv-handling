using Cv_handling.Data;
using Cv_handling.DTOs.ExperienceDTOs;
using Cv_handling.DTOs.WorkDTOs;
using Cv_handling.Models;
using Microsoft.EntityFrameworkCore;

namespace Cv_handling.Endpoints;

public class ExperienceEndpoints
{
    public static void RegisterEndpoints(WebApplication app)
    {
       app.MapGet("users/{userId}/experiences", async (CvDbContext context, int userId,int page = 1, int pageSize = 10) =>
       {
           try
           {
                var experienceList = await context.Experiences
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Where
                    
           }
           catch (Exception e)
           {
               Console.WriteLine(e);
               throw;
           }
       })
        
    }
    
}