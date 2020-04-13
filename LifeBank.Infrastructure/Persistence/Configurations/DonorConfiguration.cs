using LifeBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeBank.Infrastructure.Persistence.Configurations
{
    public class DonorConfiguration : IEntityTypeConfiguration<Donor>
    {
        public void Configure(EntityTypeBuilder<Donor> builder)
        {
            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.MiddleInital)
                .HasMaxLength(10);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Gender)
                .IsRequired();

            builder.Property(e => e.DateOfBirth)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(e => e.BloodType);

            builder.HasMany<Donation>(d => d.Donations)
                .WithOne(dr => dr.Donor)
                .HasForeignKey("DonorId");

            builder.HasOne<BloodType>(b => b.BloodType)
                .WithMany(d => d.Donors)
                .HasForeignKey("BloodTypeId");
        }
    }
}
