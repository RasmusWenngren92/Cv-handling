using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cv_handling.Models;

public class Education
{
    [Key] public int EducationId { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2,
        ErrorMessage = "A School name is required and must be between 2 and 100 characters")]
    public string SchoolName { get; set; }

    [Required] [StringLength(100)] public string? Degree { get; set; }

    [Required]
    [Range(1960, 2030, ErrorMessage = "Provide a valid year between 1960 and 2030")]
    public int StartYear { get; set; }

    [Range(1960, 2030, ErrorMessage = "Provide a valid year between 1960 and 2030")]
    public int? GraduationYear { get; set; }
    
    [ForeignKey("User")] public int UseridFk { get; set; }

    
    public User User { get; set; }
}