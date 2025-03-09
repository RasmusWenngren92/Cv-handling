using System.Text.Json;
using Cv_handling.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Cv_handling.Endpoints;

public static class GitHubEndpoints
{
    
    public static  WebApplication MapGitHubEndpoints(WebApplication app)
    {
        app.MapGet("/api/github/{username}", async ([FromServices]HttpClient client, string username) =>
        {
           
            client.DefaultRequestHeaders.Add("User-Agent", "request");
            
            var response = await client.GetAsync($"https://api.github.com/users/{username}/repos");
            
            
            if (!response.IsSuccessStatusCode)
            {
                return Results.BadRequest($"Could not get repositories for user {username}");
            }
            
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            
            var repositories = JsonSerializer.Deserialize<List<GithubDto>>(json, options);
            
            if (repositories == null || repositories.Count == 0)
            {
                return Results.Ok("No repositories found.");
            }


            var repoList = repositories.Select(repo => new
            {
                repo.Name,
                Language = string.IsNullOrEmpty(repo.Language) ? "unknown" : repo.Language,
                Description = string.IsNullOrEmpty(repo.Description) ? "missing" : repo.Description,
                Url = repo.HtmlUrl
            });
            
            return Results.Ok(repoList);
        });

        return app;
    }
    
}