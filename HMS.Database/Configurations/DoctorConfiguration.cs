using HMS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HMS.Database.Configurations
{
    internal class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder
                .HasMany(d => d.Patients)
                .WithOne(p => p.Doctor)
                .IsRequired(false);

            builder
                .HasMany(d => d.Rooms)
                .WithOne(r => r.Doctor)
                .IsRequired(false);
        }
    }
}
