using System.ComponentModel.DataAnnotations;

namespace Cv_handling.DTOs;

public class UserDto
{
    [Required]
    [StringLength(30, MinimumLength = 2,
        ErrorMessage = "A first name is required and must be between 2 and 30 characters")]
    public string FirstName { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 2,
        ErrorMessage = "A last name is required and must be between 2 and 30 characters")]
    public string LastName { get; set; }

    [Required]
    [StringLength(100)]
    [EmailAddress(ErrorMessage = "Please provide a valid email format")]
    public string EmailAddress { get; set; }

    [RegularExpression(@"^(\+46|0)[0-9]{9}$", ErrorMessage = "Please provide a valid mobile number")]
    [StringLength(20)]
    public string PhoneNumber { get; set; }
}

public class CreateUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
}

public class UpdateUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
}

public class UserDetailResponseDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string? PhoneNumber { get; set; }

    public List<EducationsResponseDto> Educations { get; set; } = [];
    public List<WorkResponseDto> Works { get; set; } = [];
}