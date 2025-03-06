using System.ComponentModel.DataAnnotations;
using Cv_handling.DTOs.EducationDTOs;
using Cv_handling.DTOs.WorkDTOs;

namespace Cv_handling.DTOs.ExperienceDTOs;
public enum ExperienceType
{
    Work,
    Education
}
public class ExperienceDTO
{
    public int ExperienceId { get; set; }
    
    public int UserId { get; set; }
   
    public ExperienceType Type { get; set; }
    
    public EducationDTO Education { get; set; }
    public WorkDTO? Work { get; set; }
}
public class ExperienceCreateDTO
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public ExperienceType Type { get; set; }

    public int? WorkId { get; set; }
    public int? EducationId { get; set; }
}
public class ExperienceUpdateDTO
{
    public int ExperienceId { get; set; }
    public int? WorkId { get; set; }
    public int? EducationId { get; set; }
}
