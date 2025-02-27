using Cv_handling.DTOs.DTOs;
using Cv_handling.DTOs.UserDTOs;
using Cv_handling.Models;
using FluentValidation;

namespace Cv_handling.Services;

    public class UserCreateDTOValidator : AbstractValidator<UserCreateDTO>
    {
        public UserCreateDTOValidator()
        {
            RuleFor(user => user.FirstName).NotEmpty().WithMessage("Please enter your first name");
            RuleFor(user => user.LastName).NotEmpty().WithMessage("Please enter your last name");
            RuleFor(user => user.Email).NotEmpty().WithMessage("Valid email is required");
            RuleFor(user => user.Phonenumber).NotEmpty().Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Phone number must be in valid international format.");
            
            
        }
    }
