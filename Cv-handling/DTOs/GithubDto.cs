using System.Text.Json.Serialization;

namespace Cv_handling.DTOs;

public class GithubDto
{
    public string Name { get; set; }
    public string? Language { get; set; }
    public string? Description { get; set; }
  
    public string HtmlUrl { get; set; }
}