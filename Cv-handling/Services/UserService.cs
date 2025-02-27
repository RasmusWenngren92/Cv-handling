using Cv_handling.DTOs.UserDtos;
using Cv_handling.Models;
using FluentValidation;

namespace Cv_handling.Services;

public class UserService
{
    public class UserCreateDTOValidator : AbstractValidator<UserCreateDTO>
    {
        public UserCreateDTOValidator()
        {
            RuleFor(user => user.FirstName).NotEmpty().WithMessage("Please enter your first name");
            RuleFor(user => user.LastName).NotEmpty().WithMessage("Please enter your last name");
            RuleFor(user => user.Email).NotEmpty().WithMessage("Valid email is required");
            
            
        }
    }
}