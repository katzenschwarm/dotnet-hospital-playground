using HMS.Database.Configurations;
using HMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace HMS.Database
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Patient> Patients => Set<Patient>();

        public DbSet<Room> Rooms => Set<Room>();

        public DbSet<Doctor> Doctors => Set<Doctor>();

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options): base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new DoctorConfiguration());
            builder.ApplyConfiguration(new PatientConfiguration());
            builder.ApplyConfiguration(new RoomConfiguration());
        }
    }
}
