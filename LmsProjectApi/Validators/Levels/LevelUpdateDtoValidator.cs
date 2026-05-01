using FluentValidation;
using LmsProjectApi.Models.Levels;

namespace LmsProjectApi.Validators.Levels
{
    public class LevelUpdateDtoValidator : AbstractValidator<Level>
    {
        public LevelUpdateDtoValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Level name is required.");
        }
    }
}
