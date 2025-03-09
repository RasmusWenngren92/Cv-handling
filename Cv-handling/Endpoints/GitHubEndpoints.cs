using Cv_handling.DTOs;

namespace Cv_handling.Endpoints;

public static class GitHubEndpoints
{
    
    public static RouteGroupBuilder MapGithubEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/{username}", async (HttpClient client, string username) =>
        {  
            var url = $"https://api.github.com/{username}/repos";
            
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0");
            
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return Results.BadRequest($"Could not ger repositories for user {username}");
            }

            var repositories = await response.Content.ReadFromJsonAsync<List<GithubDtos.GitHubRepo>>();

            if (repositories == null || repositories.Count == 0)
            {
                return Results.NotFound($"No public repositories found for user {username}.");
            }

            var result = repositories.Select(repo => new
            {
                Name = repo.Name,
                Language = string.IsNullOrEmpty(repo.Language) ? "Unknown" : repo.Language,
                Description = string.IsNullOrEmpty(repo.Description) ? "Missing" : repo.Description,
                url = repo.HtmlUrl
            });
            return Results.Ok(result);
        });

        return group;
    }
    
}