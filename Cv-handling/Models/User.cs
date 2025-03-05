using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cv_handling.Models;

public class User
{
    [Key]
    public int UserId { get; set; }

    [StringLength(50, MinimumLength = 1)]
    public required string FirstName { get; set; }

    [StringLength(50, MinimumLength = 1)]
    public required string LastName { get; set; }
    
    [EmailAddress] 
    [StringLength(100)]
    public required string Email { get; set; }
    
    [DataType(DataType.Date)]
    public required DateTime? Birthday { get; set; }
    
    [StringLength(15)]
    [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Phone number must be in valid international format.")]
    public required string PhoneNumber { get; set; }

    public List<Education> Educations { get; set; } = [];
    public List<Work> Works { get; set; } = [];
    public virtual List<Experience> Experiences { get; set; } = []; 
    
}