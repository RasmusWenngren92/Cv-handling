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
    public required DateTime Birthday { get; set; }
    
    [StringLength(15)]
    [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Phone number must be in valid international format.")]
    public required string PhoneNumber { get; set; }
    
    [ForeignKey("Work")]
    public int WorkIdFk { get; set; } 
    public virtual Work Work { get; set; }
    
    [ForeignKey("Education")]
    public int EducationIdFk { get; set; }
    public virtual Education Education { get; set; }
}