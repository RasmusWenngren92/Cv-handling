using System.ComponentModel.DataAnnotations;

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
}