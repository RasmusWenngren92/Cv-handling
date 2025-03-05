using System.ComponentModel.DataAnnotations;

namespace Cv_handling.DTOs.WorkDTOs;

public class WorkDTO
{
    public int WorkId { get; set; }
    [StringLength(50, MinimumLength = 1)]
    public string CompanyName { get; set; }
    [StringLength(50, MinimumLength = 1)]
    public string WorkTitle { get; set; }
    [DataType(DataType.Date)]
    public DateOnly Duration { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
    public int ExperienceId { get; set; }
    
    
}

public class WorkUpdateDTO 
{
    [Required]
    public string CompanyName { get; set; }
    [Required]
    public string WorkTitle { get; set; }
    public string Duration { get; set; }
    public string Description { get; set; }
    
    public int? ExperienceId { get; set; }
}
public class WorkCreateDTO 
{
    [Required]
    public string CompanyName { get; set; }
    [Required]
    public string WorkTitle { get; set; }
    [Required]
    public DateOnly Duration { get; set; }
    [Required]
    public string Description { get; set; }
}