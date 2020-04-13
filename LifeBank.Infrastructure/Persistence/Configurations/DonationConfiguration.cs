using LifeBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeBank.Infrastructure.Persistence.Configurations
{
    public class DonationConfiguration : IEntityTypeConfiguration<Donation>
    {
        public void Configure(EntityTypeBuilder<Donation> builder)
        {
            builder.Property(e => e.Donor)
                .IsRequired();

            builder.Property(e => e.UnitsOfBlood)
                .IsRequired();

            builder.Property(e => e.DonationDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.HasOne<Donor>(d => d.Donor)
                .WithMany(d => d.Donations)
                .HasForeignKey("DonorId");
        }
    }
}
