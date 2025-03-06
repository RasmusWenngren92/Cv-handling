using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cv_handling.DTOs.ExperienceDTOs;

namespace Cv_handling.Models;

public class Experience
{
    [Key]
    public int ExperienceId { get; set; }
    
    
    [ForeignKey("User")]
    
    public int UserIdFk { get; set; }
    
    public virtual User User { get; set; }
    
    public ExperienceType Type { get; set; }
    
    [ForeignKey("Work")]
    public int? WorkIdFk { get; set; } 
    public virtual Work Work { get; set; }
    
    
    [ForeignKey("Education")]
    public int? EducationIdFk { get; set; }
    public virtual Education Education { get; set; }
}