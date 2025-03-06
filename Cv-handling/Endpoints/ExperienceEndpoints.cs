using Cv_handling.Data;
using Cv_handling.DTOs.EducationDTOs;
using Cv_handling.DTOs.ExperienceDTOs;
using Cv_handling.DTOs.WorkDTOs;
using Cv_handling.Models;
using Microsoft.EntityFrameworkCore;

namespace Cv_handling.Endpoints;

public class ExperienceEndpoints
{
    public static void RegisterEndpoints(WebApplication app)
    {
        app.MapGet("users/{userId:int}/experiences",
            async (CvDbContext context, int userId, int page = 1, int pageSize = 10) =>
            {
                try
                {
                    var experienceList = await context.Experiences
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .Where(e => e.UserIdFk == userId)
                        .Include(e => e.Work)
                        .Include(e => e.Education)
                        .Select(e => new ExperienceDTO
                        {
                            ExperienceId = e.ExperienceId,
                            UserId = e.UserIdFk,
                            Type = e.Type,
                            Work = e.Type == ExperienceType.Work && e.Work != null
                                ? new WorkDTO
                                {
                                    WorkId = e.Work.WorkId,
                                    CompanyName = e.Work.CompanyName,
                                    WorkTitle = e.Work.WorkTitle,
                                    Description = e.Work.Description,
                                    Duration = e.Work.Duration
                                }
                                : null,
                            Education = e.Type == ExperienceType.Education && e.Education != null
                                ? new EducationDTO
                                {
                                    EducationId = e.Education.EducationId,
                                    SchoolName = e.Education.SchoolName,
                                    StartDate = e.Education.StartDate,
                                    GraduationDate = e.Education.GraduationDate,
                                    IsAlumni = e.Education.IsAlumni,
                                }
                                : null

                        }).ToListAsync();

                    return experienceList.Count > 0
                        ? Results.Ok(experienceList)
                        : Results.NotFound("No experiences found for this user.");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occured: {ex.Message}");
                    return Results.Problem(
                        title: "An error occured",
                        detail: "Something went wrong while fetching experience data.",
                        statusCode: 500,
                        instance: "/experience");
                }
            });

        app.MapPost("/users/{userId:int}/experiences/work", async (CvDbContext context, int userId, WorkCreateDTO dto) =>
        {
            try
            {
                var work = new Work
                {
                    CompanyName = dto.CompanyName,
                    WorkTitle = dto.WorkTitle,
                    Description = dto.Description,
                    Duration = dto.Duration,
                };

                context.Work.Add(work);
                await context.SaveChangesAsync();

                var experience = new Experience
                {
                    UserIdFk = userId,
                    Type = ExperienceType.Work,
                    WorkIdFk = work.WorkId
                };


                context.Experiences.Add(experience);
                await context.SaveChangesAsync();

                return Results.Created($"/users/{userId}/experiences/{experience.ExperienceId}",
                    new ExperienceDTO
                    {
                        ExperienceId = experience.ExperienceId,
                        UserId = experience.UserIdFk,
                        Type = experience.Type,
                        Work = new WorkDTO
                        {
                            WorkId = work.WorkId,
                            CompanyName = work.CompanyName,
                            WorkTitle = work.WorkTitle,
                            Description = work.Description,
                            Duration = work.Duration,
                        }
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
                return Results.Problem(
                    title: "An error occured",
                    detail: "Something went wrong while creating data.",
                    statusCode: 500,
                    instance: "/experience");
            }
        });

        app.MapPost("/users/{userId:int}/experiences/education",
            async (CvDbContext context, int userId, EducationCreateDTO dto) =>
            {
                try
                {
               
                    var education = new Education
                    {
                        SchoolName = dto.SchoolName,
                        StartDate = dto.StartDate,
                        GraduationDate = dto.GraduationDate,
                        IsAlumni = dto.IsAlumni,
                        SchoolTitle = dto.SchoolTitle,
                    };

                    context.Education.Add(education);
                    await context.SaveChangesAsync();

                    var experience = new Experience
                    {
                        UserIdFk = userId,
                        Type = ExperienceType.Education,
                        EducationIdFk = education.EducationId,
                    };
                    context.Experiences.Add(experience);
                    await context.SaveChangesAsync();

                    return Results.Created($"/users/{userId}/experiences/{experience.ExperienceId}",
                        new ExperienceDTO
                        {
                            ExperienceId = experience.ExperienceId,
                            UserId = experience.UserIdFk,
                            Type = experience.Type,
                            Education = new EducationDTO
                            {
                                EducationId = education.EducationId,
                                SchoolName = education.SchoolName,
                                StartDate = education.StartDate,
                                GraduationDate = education.GraduationDate,
                                IsAlumni = education.IsAlumni,
                                SchoolTitle = education.SchoolTitle,
                            }
                        });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occured: {ex.Message}");
                    return Results.Problem(
                        title: "An error occured",
                        detail: "Something went wrong while creating data.",
                        statusCode: 500,
                        instance: "/experience");
                }
            });

    }
    
}