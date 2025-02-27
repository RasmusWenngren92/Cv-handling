using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cv_handling.Models;

public class Experience
{
    [Key]
    public int ExperienceId { get; set; }
    

    public int WorkId_FK { get; set; }
}