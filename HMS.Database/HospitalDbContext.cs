using HMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace HMS.Database
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options): base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SetupPatientRelationships(modelBuilder);
            SetupDoctorRelationships(modelBuilder);
            SetupRoomRelationships(modelBuilder);
        }

        private static void SetupRoomRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                                        .HasMany(d => d.Patients)
                                        .WithOne(p => p.Room)
                                        .IsRequired(false);

            modelBuilder.Entity<Room>()
                .HasOne(r => r.Doctor)
                .WithMany(d => d.Rooms)
                .IsRequired(false);
        }

        private static void SetupDoctorRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                            .HasMany(d => d.Patients)
                            .WithOne(p => p.Doctor)
                            .IsRequired(false);

            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Rooms)
                .WithOne(r => r.Doctor)
                .IsRequired(false);
        }

        private static void SetupPatientRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.Doctor)
                .WithMany(d => d.Patients)
                .IsRequired(false);

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.Room)
                .WithMany(r => r.Patients)
                .IsRequired(false);
        }
    }
}
