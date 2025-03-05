using Cv_handling.Data;
using Cv_handling.DTOs.WorkDTOs;
using Cv_handling.Models;
using Cv_handling.Services;
using Microsoft.EntityFrameworkCore;

namespace Cv_handling.Endpoints;

public class WorkEndpoints
{
    public static void RegisterEndpoints(WebApplication app)
    {
        app.MapGet("/work", async (CvDbContext context, int page = 1, int pageSize = 10) =>
        {
            try
            {
                var workList = await context.Work
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(w => new WorkDTO
                    {
                        WorkId = w.WorkId,
                        CompanyName = w.CompanyName,
                        Description = w.Description,
                        Duration = w.Duration,
                        WorkTitle = w.WorkTitle
                    }).ToListAsync();
                return workList.Count == 0 ? Results.NotFound("No work found") : Results.Ok(workList);
            }
            catch (Exception)
            {
                return Results.StatusCode(500);
            }
        });

        app.MapPost("/work", async (WorkCreateDTO newWork, UserService userService, CvDbContext context) =>
        {
            try
            {
                var (isValid, message) = userService.ValidateWork(newWork);

                if (!isValid)
                    return Results.BadRequest(new { Message = message });

                var work = new Work
                {
                    CompanyName = newWork.CompanyName,
                    Description = newWork.Description,
                    Duration = newWork.Duration,
                    WorkTitle = newWork.WorkTitle
                };
                context.Work.Add(work);
                await context.SaveChangesAsync();

                return Results.Created($"/work/{work.WorkId}", new WorkDTO
                {
                    CompanyName = work.CompanyName,
                    Description = work.Description,
                    WorkTitle = work.WorkTitle,
                    Duration = work.Duration
                });
            }
            catch (Exception)
            {
                return Results.StatusCode(500);
            }
        });

        app.MapPut("/work/{id:int}", async (CvDbContext context, int id, Work work) =>
        {
            try
            {
                var existingWork = await context.Work.FirstOrDefaultAsync(w => w.WorkId == id);
                if (existingWork == null) return Results.NotFound($"Work with id {id} not found");

                existingWork.WorkTitle = work.WorkTitle;
                existingWork.Description = work.Description;
                existingWork.Duration = work.Duration;
                existingWork.CompanyName = work.CompanyName;

                context.Work.Update(existingWork);
                await context.SaveChangesAsync();
                return Results.NoContent();
            }
            catch (Exception)
            {
                return Results.StatusCode(500);
            }
        });

        app.MapDelete("/work/{id:int}", async (CvDbContext context, int id) =>
        {
            try
            {
                var existingWork = await context.Work.FirstOrDefaultAsync(w => w.WorkId == id);
                if (existingWork == null) return Results.NotFound($"Work with id {id} not found");
                context.Work.Remove(existingWork);
                await context.SaveChangesAsync();
                return Results.NoContent();
            }
            catch (Exception e)
            {
                return Results.StatusCode(500);
            }
        });
    }
}