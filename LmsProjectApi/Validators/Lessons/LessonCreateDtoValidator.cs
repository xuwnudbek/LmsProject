using FluentValidation;
using LmsProjectApi.DTOs.Lessons;

namespace LmsProjectApi.Validators.Lessons
{
    public class LessonCreateDtoValidator : AbstractValidator<LessonCreateDto>
    {
        public LessonCreateDtoValidator()
        {
            RuleFor(g => g.Name)
                .NotEmpty().WithMessage("Name is required.");
            
            RuleFor(g => g.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
        }
    }
}
