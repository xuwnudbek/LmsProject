using FluentValidation;
using LmsProjectApi.DTOs.Attendances;

namespace LmsProjectApi.Validators.Attendances
{
    public class AttendanceUpdateValidator : AbstractValidator<AttendanceUpdateDto>
    {
        public AttendanceUpdateValidator()
        {
            RuleFor(a => a.Status)
                .NotNull().WithMessage("Attendance status is required.");
        }
    }
}
