using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cv_handling.Models;

public class User
{
    [Key]
    public required int UserId { get; set; }

    [StringLength(50, MinimumLength = 1)]
    public required string FirstName { get; set; }

    [StringLength(50, MinimumLength = 1)]
    public required string LastName { get; set; }
    
    [EmailAddress] 
    [StringLength(100)]
    public required string Email { get; set; }
    
    public required DateTime Birthday { get; set; }
    
    public required int PhoneNumber { get; set; }
    
    [ForeignKey("Work")]
    public int WorkIdFk { get; set; } 
    public virtual Work Work { get; set; }
    
    [ForeignKey("Education")]
    public int EducationIdFk { get; set; }
    public virtual Education Education { get; set; }
}