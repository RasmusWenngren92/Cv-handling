namespace Cv_handling.DTOs.DTOs;

public class EducationDTO
{
    public int EducationId { get; set; }
    public string SchoolName { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly GraduationDate { get; set; }
}