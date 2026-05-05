using FluentValidation;
using LmsProjectApi.DTOs.Groups;
using System;

namespace LmsProjectApi.Validators.Groups
{
    public class GroupCreateDtoValidator : AbstractValidator<GroupCreateDto>
    {
        public GroupCreateDtoValidator()
        {
            RuleFor(g => g.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(g => g.PaymentValue)
                .GreaterThanOrEqualTo(0).WithMessage("PaymentValue must be greater than or equal to 0.");

            RuleFor(g => g.StartDate)
                .GreaterThanOrEqualTo(DateTimeOffset.UtcNow).WithMessage("StartDate must be greater than or equal to now.");

            RuleFor(g => g.EndDate)
                .GreaterThan(DateTimeOffset.UtcNow).WithMessage("EndDate must be greater than now.");
        }
    }
}
