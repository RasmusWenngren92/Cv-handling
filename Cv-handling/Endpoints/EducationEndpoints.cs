using System.ComponentModel.DataAnnotations;
using Cv_handling.Data;
using Cv_handling.DTOs;
using Cv_handling.Models;
using Cv_handling.UserServices;
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
                    .Select(e => new EducationDtos.EducationDto
                    {
                        SchoolName = e.SchoolName,
                        Degree = e.Degree,
                        StartYear = e.StartYear,
                        GraduationYear = e.GraduationYear
                    }).FirstOrDefaultAsync();

                return education is not null
                    ? Results.Ok(education)
                    : Results.NotFound($"Education with id {id} not found");
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
        group.MapPost("/", async (CvDbContext ctx, EducationDtos.CreateEducationDto newEducation) =>
        {
            try
            {
                var validationContext = new ValidationContext(newEducation);
                var validationResult = new List<ValidationResult>();

                var isValid = Validator.TryValidateObject(newEducation, validationContext, validationResult, true);

                if (!isValid)
                    return Results.BadRequest(validationResult.Select(e => e.ErrorMessage));

                var education = new Education
                {
                    SchoolName = newEducation.SchoolName,
                    Degree = newEducation.Degree,
                    StartYear = newEducation.StartYear,
                    GraduationYear = newEducation.GraduationYear
                };

                ctx.Educations.Add(education);
                await ctx.SaveChangesAsync();
                return Results.Created($"/education/{education.EducationId}", education);
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

        group.MapPut("/{id:int}", async (CvDbContext ctx, int id, EducationDtos.UpdateEducationDto education) =>
        {
            try
            {
                var existingEducation = await ctx.Educations.FirstOrDefaultAsync(u => u.EducationId == id);


                if (existingEducation == null)
                    return Results.NotFound(Results.NotFound($"Education with id {id} not found"));
                if (!string.IsNullOrWhiteSpace(education.School))
                    existingEducation.SchoolName = education.School;

                if (!string.IsNullOrWhiteSpace(education.Degree))
                    existingEducation.Degree = education.Degree;

                if (education.StartYear > 1960)
                    existingEducation.StartYear = education.StartYear;

                if (education.GraduationYear.HasValue)
                    existingEducation.GraduationYear = education.GraduationYear.Value;

                await ctx.SaveChangesAsync();

                return Results.Ok(existingEducation);
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