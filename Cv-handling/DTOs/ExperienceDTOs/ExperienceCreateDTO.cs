using System.ComponentModel.DataAnnotations;

namespace Cv_handling.DTOs.ExperienceDTOs;

public class ExperienceCreateDTO
{
    [Required]
    public int WorkIdFk { get; set; }
    
    [Required]
    public int EducationIdFk { get; set; }
}