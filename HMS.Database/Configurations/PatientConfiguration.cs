using HMS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HMS.Database.Configurations
{
    internal class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder
                .HasOne(p => p.Doctor)
                .WithMany(d => d.Patients)
            .IsRequired(false);

            builder
                .HasOne(p => p.Room)
                .WithMany(r => r.Patients)
                .IsRequired(false);
        }
    }
}
