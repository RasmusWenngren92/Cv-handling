using Cv_handling.Data;
using Cv_handling.Endpoints;
using Cv_handling.Services;
using Microsoft.EntityFrameworkCore;

namespace Cv_handling;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<CvDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped<UserService>();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        builder.Services.AddHttpClient();
        var app = builder.Build();


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }

        app.UseHttpsRedirection();


        app.MapGroup("/users").MapUserEndpoints();
        app.MapGroup("/educations").MapEducationEndpoints();
        app.MapGroup("/works").MapWorkEndpoints();


        GitHubEndpoints.MapGitHubEndpoints(app);

        app.Run();
    }
}