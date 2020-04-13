using LifeBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeBank.Infrastructure.Persistence.Configurations
{
    public class ParishConfiguration : IEntityTypeConfiguration<Parish>
    {
        public void Configure(EntityTypeBuilder<Parish> builder)
        {
            builder.Property(e => e.ParishId)
                .HasColumnName("ParishID");

            builder.Property(e => e.ParishName)
                .IsRequired()
                .HasMaxLength(25);

            builder.HasMany<Location>(l => l.Locations)
                .WithOne(p => p.Parish)
                .HasForeignKey("ParishId");
        }
    }
}
