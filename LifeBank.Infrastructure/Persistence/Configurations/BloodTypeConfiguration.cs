using LifeBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeBank.Infrastructure.Persistence.Configurations
{
    public class BloodTypeConfiguration : IEntityTypeConfiguration<BloodType>
    {
        public void Configure(EntityTypeBuilder<BloodType> builder)
        {
            builder.Property(e => e.BloodTypeId)
                .HasColumnName("BloodTypeID");

            builder.Property(e => e.BloodGroup)
                .IsRequired()
                .HasMaxLength(3);

            builder.HasMany<Donor>(d => d.Donors)
                .WithOne(b => b.BloodType)
                .HasForeignKey("BloodTypeId");
        }
    }
}
