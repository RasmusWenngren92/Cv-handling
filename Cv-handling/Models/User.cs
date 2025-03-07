using System.ComponentModel.DataAnnotations;
using Cv_handling.DTOs;

namespace Cv_handling.Models;

public class User
{
    [Key] 
    public int UserId { get; set; }   
    
    [Required]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "A first name is required and must be between 2 and 30 characters")]
    public string FirstName { get; set; }    
    
    [Required]
    [StringLength(30,MinimumLength = 2, ErrorMessage = "A last name is required and must be between 2 and 30 characters")]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "A email is required")]
    [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Please provide a valid email format")]
    [StringLength(100)]
    public string EmailAddress { get; set; }

    [RegularExpression(@"^(\+46|0)[0-9]{9}$", ErrorMessage = "Please provide a valid mobile number")]
    [StringLength(20)]
    public string PhoneNumber { get; set; }
    
    public List<Education> Educations { get; set; }
    public List<Work> Works { get; set; }
    
    
    
}