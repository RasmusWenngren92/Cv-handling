using System.ComponentModel.DataAnnotations;
using Cv_handling.Data;
using Cv_handling.DTOs;
using Cv_handling.Models;
using Cv_handling.Services;
using Microsoft.EntityFrameworkCore;

namespace Cv_handling.Endpoints;

public static class EducationEndpoints
{
    public static RouteGroupBuilder MapEducationEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/GetEducations", async (UserService userService) =>
        {
            try
            {
                var educations = await userService.GetEducations();
                return Results.Ok(educations);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e}");

                return Results.Problem(
                    title: "An unexpected error occurred.",
                    detail: "Something went wrong while fetching data.",
                    statusCode: StatusCodes.Status500InternalServerError,
                    instance: "/educations"
                );
            }
        });

        group.MapGet("/{id:int}", async (CvDbContext ctx, int id) =>
        {
            try
            {
                var education = await ctx.Educations
                    .Where(e => e.EducationId == id)
                    .Select(e => new EducationDto
                    {
                        SchoolName = e.SchoolName,
                        Degree = e.Degree,
                        StartYear = e.StartYear,
                        GraduationYear = e.GraduationYear
                    }).FirstOrDefaultAsync();

                var responsDto = new EducationsResponseDto
                {
                    SchoolName = education?.SchoolName,
                    Degree = education?.Degree,
                    StartYear = education?.StartYear,
                    GraduationYear = education?.GraduationYear,
                    
                };

                return Results.Ok(responsDto);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e}");

                return Results.Problem(
                    title: "An unexpected error occurred.",
                    detail: "Something went wrong while fetching data.",
                    statusCode: StatusCodes.Status500InternalServerError,
                    instance: "/education"
                );
            }
        });
        group.MapPost("/", async (CvDbContext ctx, CreateEducationDto newEducation) =>
        {
            try
            {
                var userExists = await ctx.Users.AnyAsync(u => u.UserId == newEducation.UserIdFk);
                if (!userExists)
                    return Results.NotFound($"User with id {newEducation.UserIdFk} not found");

                var education = new Education
                {
                    SchoolName = newEducation.SchoolName,
                    Degree = newEducation.Degree,
                    StartYear = newEducation.StartYear,
                    GraduationYear = newEducation.GraduationYear,
                    UseridFk = newEducation.UserIdFk
                };

                ctx.Educations.Add(education);
                await ctx.SaveChangesAsync();
                var responseDto = new EducationsResponseDto
                {
                    EducationId = education.EducationId,
                    UserIdFk = education.UseridFk,
                    SchoolName = education.SchoolName,
                    Degree = education.Degree,
                    StartYear = education.StartYear,
                    GraduationYear = education.GraduationYear
                };
                
                return Results.Created($"/education/{education.EducationId}", responseDto);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e}");

                if (e is DbUpdateException)
                    return Results.Problem(
                        title: "Database update error",
                        detail: "Could not add the education record to the database",
                        statusCode: StatusCodes.Status500InternalServerError,
                        instance: "/education"
                    );
            
                return Results.Problem(
                    title: "An unexpected error occurred",
                    detail: "Something went wrong while creating data",
                    statusCode: StatusCodes.Status500InternalServerError,
                    instance: "/education"
                );
            }
        });

        group.MapPut("/{id:int}", async (CvDbContext ctx, int id, UpdateEducationDto education) =>
        {
            try
            {
                var existingEducation = await ctx.Educations.FirstOrDefaultAsync(u => u.EducationId == id);


                if (existingEducation == null)
                    return Results.NotFound(Results.NotFound($"Education with id {id} not found"));
                if (!string.IsNullOrWhiteSpace(education.SchoolName))
                    existingEducation.SchoolName = education.SchoolName;

                if (!string.IsNullOrWhiteSpace(education.Degree))
                    existingEducation.Degree = education.Degree;

                if (education.StartYear > 1960)
                    existingEducation.StartYear = education.StartYear;

                if (education.GraduationYear.HasValue)
                    existingEducation.GraduationYear = education.GraduationYear.Value;
                
                await ctx.SaveChangesAsync();
                
                var responsDto = new EducationsResponseDto
                {
                    SchoolName = education.SchoolName,
                    Degree = education.Degree,
                    StartYear = education.StartYear,
                    GraduationYear = education.GraduationYear,
                };



                return Results.Ok(responsDto);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e}");

                return Results.Problem(
                    title: "An unexpected error occurred.",
                    detail: "Something went wrong while fetching data.",
                    statusCode: StatusCodes.Status500InternalServerError,
                    instance: "/education"
                );
            }
        });

        group.MapDelete("/{id:int}", async (CvDbContext ctx, int id) =>
        {
            try
            {
                var education = await ctx.Educations.FirstOrDefaultAsync(u => u.EducationId == id);

                if (education == null)
                    return Results.NotFound($"Education with id {id} not found");

                ctx.Educations.Remove(education);
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
                    instance: "/education"
                );
            }
        });

        return group;
    }
}