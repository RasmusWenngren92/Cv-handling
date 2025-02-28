using Cv_handling.DTOs.ExperienceDTOs;
using Cv_handling.Models;

namespace Cv_handling.DTOs.DTOs;

public class UserDTO
{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserEmail { get; set; }
    public List<ExperienceDTO> Experiences { get; set; }
}