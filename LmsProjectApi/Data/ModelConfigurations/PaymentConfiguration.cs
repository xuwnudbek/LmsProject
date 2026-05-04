using LmsProjectApi.Models.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LmsProjectApi.Data.ModelConfigurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(p => p.Amount)
                   .IsRequired();

            builder.Property(p => p.DiscountAmount)
                   .HasDefaultValue(0);

            builder.Property(p => p.Comment)
                   .HasMaxLength(500);

            builder.HasOne(p => p.User)
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Group)
                .WithMany(g => g.Payments)
                .HasForeignKey(p => p.GroupId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
