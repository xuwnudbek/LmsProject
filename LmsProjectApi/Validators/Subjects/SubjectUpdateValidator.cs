using FluentValidation;
using LmsProjectApi.DTOs.Subjects;

namespace LmsProjectApi.Validators.Subjects
{
    public class SubjectUpdateValidator : AbstractValidator<SubjectUpdateDto>
    {
        public SubjectUpdateValidator()
        {
            RuleFor(p => p.Name)
                .NotNull().WithMessage("Name is required.");

            RuleFor(p => p.HasLevel)
                .NotNull().WithMessage("HasLevel is required.");
        }
    }
}
