using System.ComponentModel.DataAnnotations;

namespace Cv_handling.Models;

public class Work
{
    [Key] 
    public int WorkId { get; set; }
    
    [StringLength(50, MinimumLength = 1)]
    public required string CompanyName { get; set; }

    [StringLength(50, MinimumLength = 1)]
    public required string WorkTitle { get; set; }

    [MaxLength(500)]
    public required string Description { get; set; }

    [DataType(DataType.Date)]
    public DateOnly Duration { get; set; }
    
    public virtual List<User> Users { get; set; }
    public virtual List<Experience> Experiences { get; set; }
    public int UserIdFk { get; set; }
    public virtual User User { get; set; }
    
}