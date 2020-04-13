using LifeBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeBank.Infrastructure.Persistence.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.Property(e => e.LocationId)
                .HasColumnName("LocationID");

            builder.Property(e => e.LocatioName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.AdressLine1)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(e => e.AdressLine2)
                .HasMaxLength(60);

            builder.Property(e => e.Parish);

            builder.Property(e => e.Telephone)
                .HasMaxLength(11);

            builder.Property(e => e.Email)
                .HasMaxLength(30);

            builder.HasOne<Parish>(p => p.Parish)
                .WithMany(l => l.Locations)
                .HasForeignKey("ParishId");
        }
    }
}
