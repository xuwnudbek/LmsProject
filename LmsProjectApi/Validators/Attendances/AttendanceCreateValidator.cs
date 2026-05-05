using FluentValidation;
using LmsProjectApi.DTOs.Attendances;

namespace LmsProjectApi.Validators.Attendances
{
    public class AttendanceCreateValidator : AbstractValidator<AttendanceCreateDto>
    {
        public AttendanceCreateValidator()
        {
            RuleFor(a => a.Status)
                .NotNull().WithMessage("Attendance status is required.");
        }
    }
}
