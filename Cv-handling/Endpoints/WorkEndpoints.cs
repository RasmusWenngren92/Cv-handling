using System.ComponentModel.DataAnnotations;
using Cv_handling.Data;
using Cv_handling.DTOs;
using Cv_handling.Models;
using Cv_handling.UserServices;
using Microsoft.EntityFrameworkCore;

namespace Cv_handling.Endpoints;

public static class WorkEndpoints
{
    public static RouteGroupBuilder MapWorkEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/GetWorks", async (UserService userService) =>
        {
            try
            {
                var works = await userService.GetWorks();
                return Results.Ok(works);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e}");

                return Results.Problem(
                    title: "An unexpected error occurred.",
                    detail: "Something went wrong while fetching data.",
                    statusCode: StatusCodes.Status500InternalServerError,
                    instance: "/works"
                );
            }
        });


        group.MapGet("/{id:int}", async (CvDbContext ctx, int id) =>
        {
            try
            {
                var work = await ctx.Works
                    .Where(w => w.WorkId == id)
                    .Select(w => new WorkDto()
                    {
                        Title = w.Title,
                        Company = w.Company,
                        Description = w.Description,
                        StartYear = w.StartYear,
                        EndYear = w.EndYear
                    }).FirstOrDefaultAsync();

                return work is not null
                    ? Results.Ok(work) 
                    : Results.NotFound($"Work with id {id} not found");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e}");

                return Results.Problem(
                    title: "An unexpected error occurred.",
                    detail: "Something went wrong while fetching data.",
                    statusCode: StatusCodes.Status500InternalServerError,
                    instance: "/work"
                );
            }
        });
        group.MapPost("/", async (CvDbContext ctx, CreateWorkDto newWork) =>
        {
            try
            {
                var validationContext = new ValidationContext(newWork);
                var validationResult = new List<ValidationResult>();

                var isValid = Validator.TryValidateObject(newWork, validationContext, validationResult, true);

                if (!isValid)
                    return Results.BadRequest(validationResult.Select(e => e.ErrorMessage));

                var work = new Work
                {
                   Title = newWork.Title,
                   Company = newWork.Company,
                   Description = newWork.Description,
                   StartYear = newWork.StartYear,
                   EndYear = newWork.EndYear
                };

                ctx.Works.Add(work);
                await ctx.SaveChangesAsync();
                return Results.Created($"/work/{work.WorkId}", work);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e}");

                return Results.Problem(
                    title: "An unexpected error occurred.",
                    detail: "Something went wrong while fetching data.",
                    statusCode: StatusCodes.Status500InternalServerError,
                    instance: "/work"
                );
            }
        });

        group.MapPut("/{id:int}", async (CvDbContext ctx, int id, UpdateWorkDto work) =>
        {
            try
            {
                var existingWork = await ctx.Works.FirstOrDefaultAsync(u => u.WorkId == id);


                if (existingWork == null)
                    return Results.NotFound(Results.NotFound($"Work with id {id} not found"));
                if (!string.IsNullOrWhiteSpace(work.Title))
                    existingWork.Title = work.Title;
                if (!string.IsNullOrWhiteSpace(work.Company))
                    existingWork.Company = work.Company;

                if (!string.IsNullOrWhiteSpace(work.Description))
                    existingWork.Description = work.Description;

                if (work.StartYear > 1960)
                    existingWork.StartYear = work.StartYear;

                if (work.EndYear.HasValue)
                    existingWork.EndYear = work.EndYear.Value;

                await ctx.SaveChangesAsync();

                return Results.Ok(existingWork);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e}");

                return Results.Problem(
                    title: "An unexpected error occurred.",
                    detail: "Something went wrong while fetching data.",
                    statusCode: StatusCodes.Status500InternalServerError,
                    instance: "/work"
                );
            }
        });

        group.MapDelete("/{id:int}", async (CvDbContext ctx, int id) =>
        {
            try
            {
                var work = await ctx.Works.FirstOrDefaultAsync(u => u.WorkId == id);

                if (work == null)
                    return Results.NotFound($"Work with id {id} not found");

                ctx.Works.Remove(work);
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
                    instance: "/work"
                );
            }
        });

        return group;
    }
}