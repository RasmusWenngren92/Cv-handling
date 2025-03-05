using Cv_handling.Data;
using Cv_handling.DTOs.EducationDTOs;
using Cv_handling.DTOs.ExperienceDTOs;
using Cv_handling.DTOs.WorkDTOs;
using Cv_handling.Models;
using Cv_handling.Services;
using Microsoft.EntityFrameworkCore;
using EducationDTO = Cv_handling.DTOs.EducationDTOs.EducationDTO;

namespace Cv_handling.Endpoints;

public class EducationEndpoints
{
    public static void RegisterEndpoints(WebApplication app)
    {
        app.MapGet("/education", async (CvDbContext context, int page = 1, int pageSize = 10) =>
        {
            try
            {
                var educationList = await context.Education
                    .Skip((page -1) * pageSize)
                    .Take(pageSize)
                    .Select(e => new EducationDTO
                {
                
                    EducationId = e.EducationId,
                    SchoolName = e.SchoolName,
                    StartDate = e.StartDate,
                    SchoolTitle = e.SchoolTitle,
                    GraduationDate = e.GraduationDate
                        
             
                }).ToListAsync();
            
                return educationList.Count == 0 ? Results.NotFound("No Education found") : Results.Ok(educationList);
            }
            catch (Exception)
            {
              return Results.StatusCode(500);
            }
           
        });

        app.MapPost("/education",
            async (EducationCreateDTO newEducation, UserService userService, CvDbContext context) =>
            {
                try
                {
                    var(isValid, message) = userService.ValidateEducation(newEducation);
                
                    if(!isValid)
                        return Results.BadRequest( new { Message = message } );

                    var education = new Education
                    {
                        SchoolName = newEducation.SchoolName,
                        SchoolTitle = newEducation.SchoolTitle,
                        StartDate = newEducation.StartDate,
                        GraduationDate = newEducation.GraduationDate,
                        IsAlumni = newEducation.IsAlumni,
                    };
                    context.Education.Add(education);
                    await context.SaveChangesAsync();
                
                    return Results.Created($"/education/{education.EducationId}", new EducationDTO
                    {
                        SchoolName = education.SchoolName,
                        StartDate = education.StartDate,
                        GraduationDate = education.GraduationDate,
                    });
                }
                catch (Exception )
                {
                    return Results.StatusCode(500);
                }
               
            });

        app.MapPut("/education/{id:int}", async (CvDbContext context, int id, Education education) =>
        {
            try
            {
                var existingEducation = await context.Education.FirstOrDefaultAsync(e => e.EducationId == id);
            
                if(existingEducation == null) return Results.NotFound($"Education with id {id} not found");
            
                existingEducation.SchoolName = education.SchoolName;
                existingEducation.SchoolTitle = education.SchoolTitle;
                existingEducation.StartDate = education.StartDate;
                existingEducation.GraduationDate = education.GraduationDate;
                existingEducation.IsAlumni = education.IsAlumni;
            
                context.Education.Update(existingEducation);
                await context.SaveChangesAsync();
                return Results.NoContent(); 
            }
            catch (Exception )
            {
                return Results.StatusCode(500);
            }
           
        });

        app.MapDelete("/education/{id:int}", async (CvDbContext context, int id) =>
        {
            try
            {
                var existingEducation = await context.Education.FirstOrDefaultAsync(e => e.EducationId == id);
                if(existingEducation == null) return Results.NotFound($"Education with id {id} not found");
                context.Education.Remove(existingEducation);
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