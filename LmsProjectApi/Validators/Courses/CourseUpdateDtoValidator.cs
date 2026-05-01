using FluentValidation;
using LmsProjectApi.DTOs.Courses;

namespace LmsProjectApi.Validators.Courses
{
    public class CourseUpdateDtoValidator : AbstractValidator<CourseUpdateDto>
    {
        public CourseUpdateDtoValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Course name is required.")
                .MinimumLength(2).WithMessage("Course name must be at least 2 characters.");

            RuleFor(c => c.Description)
                    .MaximumLength(500).WithMessage("Course description must not exceed 500 characters.");

            RuleFor(c => c.PaymentValue)
                    .GreaterThanOrEqualTo(0).WithMessage("Payment value must not be negative.");

            RuleFor(c => c.DurationInDays)
                    .GreaterThan(0).WithMessage("Duration must be greater than 0.")
                    .LessThanOrEqualTo(365).WithMessage("Duration must not exceed 365 days.");

            RuleFor(c => c.UserId)
                    .NotEmpty().WithMessage("Teacher is required.");

            RuleFor(c => c.SubjectId)
                    .NotEmpty().WithMessage("Subject is required.");
        }
    }
}
