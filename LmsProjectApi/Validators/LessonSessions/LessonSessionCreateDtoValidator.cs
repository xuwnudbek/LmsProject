using FluentValidation;
using LmsProjectApi.DTOs.LessonSessions;
using System;

namespace LmsProjectApi.Validators.LessonSessions
{
    public class LessonSessionCreateDtoValidator : AbstractValidator<LessonSessionCreateDto>
    {
        public LessonSessionCreateDtoValidator()
        {
            RuleFor(ls => ls.Status)
                .NotNull().WithMessage("Status is required.");

            RuleFor(ls => ls.TeacherAttendanceStatus)
                .NotNull().WithMessage("TeacherAttendanceStatus is required.");

            RuleFor(g => g.StartAt)
                .GreaterThanOrEqualTo(DateTimeOffset.UtcNow).WithMessage("StartAt must be greater than or equal to now.");

            RuleFor(g => g.EndAt)
                .GreaterThan(DateTimeOffset.UtcNow).WithMessage("EndAt must be greater than now.");
        }
    }
}
