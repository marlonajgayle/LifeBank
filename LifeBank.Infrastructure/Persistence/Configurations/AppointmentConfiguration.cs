using LifeBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeBank.Infrastructure.Persistence.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.Property(e => e.AppointmentId)
                .HasColumnName("AppointmentID");

            builder.Property(e => e.Location);

            builder.Property(e => e.StartDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(e => e.EndDate)
               .IsRequired()
               .HasColumnType("datetime");

            builder.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(15);

            builder.HasOne<Donor>(d => d.Donor)
                .WithMany(a => a.Appointments)
                .HasForeignKey("DonorId");
        }
    }
}
