using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace Cv_handling.Models;

public class Work
{
    [Key] 
    public int WorkId { get; set; }
    
    [Required]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "A job title is required and must be between 2 and 100 characters")]
    public string  Title { get; set; }
    
    [Required]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "A company name is required and must be between 2 and 100 characters")]
    public string  Company { get; set; }
    
    [Required(ErrorMessage = "Description is required")]
    [StringLength(500), MinLength(10)]
    public string Description { get; set; }
    
    [Required]  
    [Range(1960, 2030, ErrorMessage = "Provide a valid year between 1960 and 2030")]
    public int StartYear { get; set; }
    
    [Range(1960, 2030, ErrorMessage = "Provide a valid year between 1960 and 2030")]
    public int? EndYear { get; set; }
    
    // Foreign key
    [ForeignKey("User")]
    public int UseridFk { get; set; }
    
    //Navigation property
    public User User { get; set; }
}