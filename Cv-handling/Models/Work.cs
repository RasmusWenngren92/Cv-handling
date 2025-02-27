using System.ComponentModel.DataAnnotations;

namespace Cv_handling.Models;

public class Work
{
    [Key] 
    public int WorkId { get; set; }
    
    [StringLength(50, MinimumLength = 1)]
    public required string CompanyName { get; set; }

    [StringLength(50, MinimumLength = 1)]
    public required string CompanyTitle { get; set; }

    [StringLength(50, MinimumLength = 1)]
    public required string JobDescription { get; set; }

    [DataType(DataType.Date)]
    public DateOnly AtCompany { get; set; }
    
}