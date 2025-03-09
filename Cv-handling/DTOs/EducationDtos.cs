using System.ComponentModel.DataAnnotations;

namespace Cv_handling.DTOs;

public class EducationDto
{
    [StringLength(100, MinimumLength = 2,
        ErrorMessage = "A School name is required and must be between 2 and 100 characters")]
    public required string? SchoolName { get; set; }

    [Required] [StringLength(100)] public string? Degree { get; set; }

    [Required]
    [Range(1960, 2030, ErrorMessage = "Provide a valid year between 1960 and 2030")]
    public int StartYear { get; set; }

    [Range(1960, 2030, ErrorMessage = "Provide a valid year between 1960 and 2030")]
    public int? GraduationYear { get; set; }
}

public class CreateEducationDto
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public required string SchoolName { get; set; }

    [Required] [StringLength(100)] public string? Degree { get; set; }
    [Required] [Range(1960, 2030)] public int StartYear { get; set; }
    [Range(1960, 2030)] public int? GraduationYear { get; set; }
    [Required] public int UserIdFk { get; set; }
}

public class UpdateEducationDto
{
    [Required] public int UserIdFk { get; set; }

    [Required] public required string SchoolName { get; set; }
    [Required] public string? Degree { get; set; }
    [Required] [Range(1960, 2030)] public int StartYear { get; set; }
    [Range(1960, 2030)] public int? GraduationYear { get; set; }
}

public class EducationsResponseDto
{
    public int EducationId { get; set; }
    public int UserIdFk { get; set; }
    public string? SchoolName { get; set; }
    public string? Degree { get; set; }
    public int? StartYear { get; set; }
    public int? GraduationYear { get; set; }
}