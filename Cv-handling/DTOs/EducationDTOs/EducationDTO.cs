using System.ComponentModel.DataAnnotations;

namespace Cv_handling.DTOs.EducationDTOs;

public class EducationDTO
{
    [Key]
        public int EducationId { get; set; }
    [StringLength(50, MinimumLength = 1)]
    public string SchoolName { get; set; }    
    [StringLength(50, MinimumLength = 1)]
    public string SchoolTitle { get; set; }
    
    public bool IsAlumni { get; set; }
    
    [DataType(DataType.Date)]
    public DateOnly StartDate { get; set; }
    
    [DataType(DataType.Date)]
    public DateOnly GraduationDate { get; set; }
    public int ExperienceId { get; set; }
}


public class EducationUpdateDTO 
{
    [Required]
    public string SchoolName { get; set; }
    [Required]
    public DateOnly StartDate { get; set; }
    [Required]
    public DateOnly GraduationDate { get; set; }
    
    public int? ExperienceId { get; set; }

   
    
}
public class EducationCreateDTO 
{
    [Required]
    public string SchoolName { get; set; }
    [Required]
    public string SchoolTitle { get; set; }
    [Required]
    public bool IsAlumni { get; set; }
    [Required]
    public DateOnly StartDate { get; set; }
    [Required]
    public DateOnly GraduationDate { get; set; }
   
    
}
