using Cv_handling.Data;
using Cv_handling.Endpoints;
using Microsoft.EntityFrameworkCore;

namespace Cv_handling;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
            

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            
            builder.Services.AddDbContext<CvDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            
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
            
            // app.UseHttpsRedirection();
            UserEndpoints.RegisterEndpoints(app);
            EducationEndpoints.RegisterEndpoints(app);
            WorkEndpoints.RegisterEndpoints(app);
            ExperienceEndpoints.RegisterEndpoints(app);
            
            
            app.Run();
    }
    
}


