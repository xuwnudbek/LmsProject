using FluentValidation;
using LmsProjectApi.Models.Levels;

namespace LmsProjectApi.Validators.Levels
{
    public class LevelCreateDtoValidator : AbstractValidator<Level>
    {
        public LevelCreateDtoValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Level name is required.");
        }
    }
}
