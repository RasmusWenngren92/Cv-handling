using Cv_handling.DTOs.ExperienceDTOs;

namespace Cv_handling.DTOs.UserDTOs;

public abstract class UserCreateDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public string Email { get; set; }

    public string Phonenumber { get; set; }
    public string Adress { get; set; }

    public DateTime Birthday { get; set; }
    
    public List<ExperienceCreateDTO> Experiences { get; set; } = new();

}