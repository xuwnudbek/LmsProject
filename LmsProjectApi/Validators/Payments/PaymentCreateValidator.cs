using FluentValidation;
using LmsProjectApi.DTOs.Payments;

namespace LmsProjectApi.Validators.Payments
{
    public class PaymentCreateValidator : AbstractValidator<PaymentCreateDto>
    {
        public PaymentCreateValidator()
        {
            RuleFor(p => p.Amount)
                .NotNull().WithMessage("Amount is required.")
                .GreaterThanOrEqualTo(0).WithMessage("Amount must greater than or equal to 0.");

            RuleFor(p => p.DiscountAmount)
                .NotNull().WithMessage("DiscountAmount is required.")
                .GreaterThanOrEqualTo(0).WithMessage("DiscountAmount must greater than or equal to 0.");

            RuleFor(p => p.Comment)
                .MaximumLength(500).WithMessage("Comment must not exceed 500 characters.");
        }
    }
}
