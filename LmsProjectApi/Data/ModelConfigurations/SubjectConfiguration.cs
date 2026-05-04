using LmsProjectApi.Models.Subjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LmsProjectApi.Data.ModelConfigurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasIndex(s => s.Name)
                .IsUnique();

            builder.Property(s => s.HasLevel)
                .HasDefaultValue(false);
        }
    }
}
