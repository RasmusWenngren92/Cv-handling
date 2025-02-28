namespace Cv_handling.DTOs.WorkDTOs;

public class WorkDTO
{
    public int WorkId { get; set; }
    public string CompanyName { get; set; }
    public string WorkTitle { get; set; }
    public DateOnly Duration { get; set; }
    public string Description { get; set; }
}