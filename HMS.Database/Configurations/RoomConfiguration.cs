using HMS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HMS.Database.Configurations
{
    internal class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder
                .HasMany(d => d.Patients)
                .WithOne(p => p.Room)
                .IsRequired(false);

            builder
                .HasOne(r => r.Doctor)
                .WithMany(d => d.Rooms)
                .IsRequired(false);
        }
    }
}
