using LmsProjectApi.Models.SubjectLevels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LmsProjectApi.Data.ModelConfigurations
{
    public class SubjectLevelConfiguration : IEntityTypeConfiguration<SubjectLevel>
    {
        public void Configure(EntityTypeBuilder<SubjectLevel> builder)
        {
            builder.HasKey(sl => new { sl.SubjectId, sl.LevelId });

            builder.Property(sl => sl.OrderIndex)
                .IsRequired()
                .HasDefaultValue(0);

            builder.HasIndex(sl => new { sl.SubjectId, sl.OrderIndex })
                .IsUnique();


            builder.HasOne(sl => sl.Subject)
                .WithMany(s => s.SubjectLevels)
                .HasForeignKey(sl => sl.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sl => sl.Level)
                .WithMany(l => l.SubjectLevels)
                .HasForeignKey(sl => sl.LevelId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
