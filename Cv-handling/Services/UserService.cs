using Cv_handling.DTOs.DTOs;
using Cv_handling.DTOs.UserDTOs;
using Cv_handling.Models;

namespace Cv_handling.Services;
using FluentValidation;

public class UserService
{
    private readonly IValidator<UserCreateDTO> _validator;

    public UserService(IValidator<UserCreateDTO> validator)
    {
        this._validator = validator;
    }
    
    public (bool isValid, string message) ValidateUser(UserCreateDTO newUser)
    {
        // Validate using the validator
        var validationResult = _validator.Validate(newUser);
        return !validationResult.IsValid ? (false, "Validation failed: " + string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))) : (true, string.Empty); // Validation passed
    }
}