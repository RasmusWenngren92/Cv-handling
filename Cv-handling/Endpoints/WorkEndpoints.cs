using System.ComponentModel.DataAnnotations;
using Cv_handling.Data;
using Cv_handling.DTOs;
using Cv_handling.Models;
using Cv_handling.Services;
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
                var userExists = await ctx.Users.AnyAsync(u => u.UserId == newWork.UserIdFk);
                if (!userExists)
                    return Results.NotFound($"User with id {newWork.UserIdFk} not found");

                var work = new Work
                {
                   Title = newWork.Title,
                   Company = newWork.Company,
                   Description = newWork.Description,
                   StartYear = newWork.StartYear,
                   EndYear = newWork.EndYear,
                   UseridFk = newWork.UserIdFk
                };

                ctx.Works.Add(work);
                await ctx.SaveChangesAsync();

                var responsDto = new WorkResponseDto
                {
                    WorkId = work.WorkId,
                    UserIdFk = work.UseridFk,
                    Company = newWork.Company,
                    Description = newWork.Description,
                    StartYear = newWork.StartYear,
                    EndYear = newWork.EndYear,
                };
                return Results.Created($"/work/{work.WorkId}", responsDto);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e}");

                if (e is DbUpdateException)
                    return Results.Problem(
                        title: "Database update error",
                        detail: "Could not add the education record to the database",
                        statusCode: StatusCodes.Status500InternalServerError,
                        instance: "/work"
                    );
            
                return Results.Problem(
                    title: "An unexpected error occurred",
                    detail: "Something went wrong while creating data",
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

                var responsDto = new WorkResponseDto
                {
                    Company = work.Company,
                    Title = work.Title,
                    Description = work.Description,
                    StartYear = work.StartYear,
                    EndYear = work.EndYear,
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