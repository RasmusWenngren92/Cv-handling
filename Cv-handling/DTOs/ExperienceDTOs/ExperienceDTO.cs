using Cv_handling.DTOs.DTOs;
using Cv_handling.DTOs.WorkDTOs;

namespace Cv_handling.DTOs.ExperienceDTOs;

public class ExperienceDTO
{
    public int ExperienceId { get; set; }
    public WorkDTO? Work { get; set; }
    public EducationDTO? Education { get; set; }
}