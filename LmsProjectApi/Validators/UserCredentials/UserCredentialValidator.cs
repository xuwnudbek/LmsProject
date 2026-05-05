using FluentValidation;
using LmsProjectApi.Models.UserCredentials;

namespace LmsProjectApi.Validators.Accounts
{
    public class UserCredentialValidator : AbstractValidator<UserCredential>
    {
        public UserCredentialValidator()
        {
            RuleFor(uc => uc.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(4).WithMessage("Username must be at least 4 characters.");

            RuleFor(uc => uc.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters.");
        }
    }
}
