using LmsProjectApi.Models.Attendances;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LmsProjectApi.Data.ModelConfigurations
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.Property(a => a.Status)
                .IsRequired();

            builder.HasOne(a => a.User)
                .WithMany(u => u.Attendances)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.LessonSession)
                .WithMany(ls => ls.Attendances)
                .HasForeignKey(a => a.LessonSessionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
