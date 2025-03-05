using System.ComponentModel.DataAnnotations;
using Cv_handling.DTOs.ExperienceDTOs;

namespace Cv_handling.DTOs.UserDTOs;

public class UserDTO
{
        [Key]
        public int UserId { get; set; }
    [StringLength(50, MinimumLength = 1)]
    public string FirstName { get; set; }

    [StringLength(50, MinimumLength = 1)]
    public string LastName { get; set; }

    [EmailAddress] 
    [StringLength(100)]
    public string Email { get; set; }

    [StringLength(15)]
    [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Phone number must be in valid international format.")]
    public string PhoneNumber { get; set; }

    [DataType(DataType.Date)]
    public DateTime? Birthday { get; set; }
    public List<ExperienceDTO> Experiences { get; set; } 
}



public class UserUpdateDto 
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Email { get; set; }
}

public class UserCreateDTO 
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Email { get; set; }
    [DataType(DataType.Date)]
    public DateTime? Birthday { get; set; }
    [StringLength(15)]
    [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Phone number must be in valid international format.")]
    public string PhoneNumber { get; set; }

    public List<ExperienceCreateDTO> Experiences { get; set; } = new();
}