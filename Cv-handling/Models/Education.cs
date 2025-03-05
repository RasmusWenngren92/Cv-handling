using System.ComponentModel.DataAnnotations;

namespace Cv_handling.Models;

public class Education
{
    [Key] 
    public int EducationId { get; set; }
    
    [StringLength(50, MinimumLength = 1)]
    public required string SchoolName { get; set; }

    [StringLength(50, MinimumLength = 1)]
    public required string SchoolTitle { get; set; }
    
    [DataType(DataType.Date)]
    public required DateOnly StartDate { get; set; }  
    
    [DataType(DataType.Date)]
    public required DateOnly GraduationDate { get; set; }
    
    public bool IsAlumni { get; set; } = false;
    public int UserIdFk { get; set; }
    public virtual User User { get; set; }
    
    public virtual List<Experience> Experiences { get; set; }
}