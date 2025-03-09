namespace Cv_handling.DTOs;

public abstract class GithubDtos
{
    public abstract record GitHubRepo(string Name, string? Language, string? Description, string HtmlUrl);
}