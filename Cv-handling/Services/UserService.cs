using System.Data;
using Cv_handling.Data;
using Cv_handling.DTOs.EducationDTOs;
using Cv_handling.DTOs.UserDTOs;
using Cv_handling.DTOs.WorkDTOs;
using Cv_handling.Models;

namespace Cv_handling.Services;
using FluentValidation;

public class UserService
{
    private readonly CvDbContext _context;
    private readonly IValidator<UserCreateDTO> _validator;
    private readonly IValidator<EducationCreateDTO> _educationValidator;
    private readonly IValidator<WorkCreateDTO> _workValidator;


    public (bool isValid, string message) ValidateUser(UserCreateDTO newUser)
    {
        var validationResult = _validator.Validate(newUser);
        return !validationResult.IsValid
            ? (false, "Validation failed: " + string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)))
            : (true, string.Empty);
    }

    public class UserCreateDTOValidator : AbstractValidator<UserCreateDTO>
    {
        public UserCreateDTOValidator()
        {
            RuleFor(user => user.FirstName).NotEmpty().WithMessage("Please enter your first name");
            RuleFor(user => user.LastName).NotEmpty().WithMessage("Please enter your last name");
            RuleFor(user => user.Email).NotEmpty().WithMessage("Valid email is required");
        }
    }

    public (bool isValid, string message) ValidateEducation(EducationCreateDTO newEducation)
    {
        var validationResult = _educationValidator.Validate(newEducation);
        return !validationResult.IsValid
            ? (false, "Validation failed: " + string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)))
            : (true, string.Empty);
    }

    public class EducationCreateDTOValidator : AbstractValidator<EducationCreateDTO>
    {
        public EducationCreateDTOValidator()
        {
            RuleFor(education => education.SchoolName).NotEmpty().WithMessage("Please enter school name");
            RuleFor(education => education.SchoolTitle).NotEmpty().WithMessage("Please enter school title");
            RuleFor(education => education.IsAlumni).NotEmpty().WithMessage("Please state if you are an Alumni");
            RuleFor(education => education.GraduationDate).NotEmpty().WithMessage("Please enter graduation date");
            RuleFor(education => education.StartDate).NotEmpty().WithMessage("Please enter start date");
        }
    }

    public (bool isValid, string message) ValidateWork(WorkCreateDTO newWork)
    {
        var validationResult = _workValidator.Validate(newWork);
        return !validationResult.IsValid
            ? (false, "Validation failed: " + string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)))
            : (true, string.Empty);
    }

    public class WorkCreateDTOValidator : AbstractValidator<WorkCreateDTO>
    {
        public WorkCreateDTOValidator()
        {
            RuleFor(work => work.WorkTitle).NotEmpty().WithMessage("Please enter work title");
            RuleFor(work => work.Description).NotEmpty().WithMessage("Please enter description");
            RuleFor(work => work.Duration).NotEmpty().WithMessage("Please enter duration");
            RuleFor(work => work.CompanyName).NotEmpty().WithMessage("Please enter company name");
        }
    }
}