using System.ComponentModel.DataAnnotations;

namespace Cv_handling.DTOs;

public class WorkDto
{
    [Required]
    [StringLength(100, MinimumLength = 1,
        ErrorMessage = "A job title is required and must be between 2 and 100 characters")]
    public string Title { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 1,
        ErrorMessage = "A company name is required and must be between 2 and 100 characters")]
    public string Company { get; set; }

    [Required(ErrorMessage = "Description is required")]
    [StringLength(500)]
    [MinLength(10)]
    public string Description { get; set; }

    [Required]
    [Range(1960, 2030, ErrorMessage = "Provide a valid year between 1960 and 2030")]
    public int StartYear { get; set; }

    [Range(1960, 2030, ErrorMessage = "Provide a valid year between 1960 and 2030")]
    public int? EndYear { get; set; }
}

public class CreateWorkDto
{
    [Required]
    [StringLength(100, MinimumLength = 1,
        ErrorMessage = "A job title is required and must be between 2 and 100 characters")]
    public string Title { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 1,
        ErrorMessage = "A company name is required and must be between 2 and 100 characters")]
    public string Company { get; set; }

    [Required(ErrorMessage = "Description is required")]
    [StringLength(500)]
    [MinLength(10)]
    public string Description { get; set; }

    [Required]
    [Range(1960, 2030, ErrorMessage = "Provide a valid year between 1960 and 2030")]
    public int StartYear { get; set; }

    [Range(1960, 2030, ErrorMessage = "Provide a valid year between 1960 and 2030")]
    public int? EndYear { get; set; }

    public int UserIdFk { get; set; }
}

public class UpdateWorkDto
{
    [Required] public int UserIdFk { get; set; }

    [Required] public string Title { get; set; }
    [Required] public string Company { get; set; }
    public string? Description { get; set; }

    [Range(1960, 2030, ErrorMessage = "Provide a valid year between 1960 and 2030")]
    public int StartYear { get; set; }

    [Range(1960, 2030, ErrorMessage = "Provide a valid year between 1960 and 2030")]
    public int? EndYear { get; set; }
}

public class WorkResponseDto
{
    public int WorkId { get; set; }
    public int UserIdFk { get; set; }
    public string Title { get; set; }
    public string Company { get; set; }
    public string? Description { get; set; }
    public int StartYear { get; set; }
    public int? EndYear { get; set; }
}