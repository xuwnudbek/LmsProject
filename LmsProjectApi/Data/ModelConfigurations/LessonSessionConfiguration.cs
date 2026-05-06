using LmsProjectApi.Enums;
using LmsProjectApi.Models.LessonSessions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LmsProjectApi.Data.ModelConfigurations
{
    public class LessonSessionConfiguration : IEntityTypeConfiguration<LessonSession>
    {
        public void Configure(EntityTypeBuilder<LessonSession> builder)
        {
            builder.Property(ls => ls.Status)
                .IsRequired();

            builder.Property(ls => ls.TeacherAttendanceStatus)
                .HasDefaultValue(AttendanceStatus.NotMarked);

            builder.Property(ls => ls.StartAt)
                .IsRequired();

            builder.Property(ls => ls.EndAt)
                .IsRequired();

            builder.HasOne(ls => ls.Group)
                .WithMany(g => g.LessonSessions)
                .HasForeignKey(ls => ls.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ls => ls.Lesson)
                .WithMany(l => l.LessonSessions)
                .HasForeignKey(ls => ls.LessonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
