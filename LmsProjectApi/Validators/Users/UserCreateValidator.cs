using FluentValidation;
using LmsProjectApi.DTOs.Users;
using System.Data;

namespace LmsProjectApi.Validators.Users
{
    public class UserCreateValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateValidator()
        {
            RuleFor(u => u.FirstName)
                .NotEmpty().WithMessage("FirstName is required.")
                .MaximumLength(20).WithMessage("FirstName must not exceed 20 characters.");

            RuleFor(u => u.LastName)
                .NotEmpty().WithMessage("LastName is required.")
                .MaximumLength(20).WithMessage("LastName must not exceed 20 characters.");

            RuleFor(u => u.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber is required.")
                .Matches(@"^\+?[0-9]{9,13}$").WithMessage("PhoneNumber is not valid.");

            RuleFor(u => u.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MaximumLength(50).WithMessage("Username must not exceed 50 characters.");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
                .MaximumLength(100).WithMessage("Password must not exceed 100 characters.");

            RuleFor(u => u.ConfirmPassword)
                .NotEmpty().WithMessage("ConfirmPassword is required.")
                .Equal(u => u.Password).WithMessage("Passwords do not match.");

            RuleFor(u => u.Role)
                .IsInEnum().WithMessage("Role is not valid.");
        }
    }
}
