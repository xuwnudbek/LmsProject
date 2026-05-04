using FluentValidation;
using LmsProjectApi.DTOs.Levels;

namespace LmsProjectApi.Validators.Levels
{
    public class LevelCreateDtoValidator : AbstractValidator<LevelCreateDto>
    {
        public LevelCreateDtoValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Level name is required.");
        }
    }
}
