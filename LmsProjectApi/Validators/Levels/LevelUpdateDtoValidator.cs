using FluentValidation;
using LmsProjectApi.DTOs.Levels;

namespace LmsProjectApi.Validators.Levels
{
    public class LevelUpdateDtoValidator : AbstractValidator<LevelUpdateDto>
    {
        public LevelUpdateDtoValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Level name is required.");
        }
    }
}
