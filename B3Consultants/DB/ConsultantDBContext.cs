using Microsoft.EntityFrameworkCore;
using B3Consultants.Entities;

namespace B3Consultants.DB
{
    public class ConsultantDBContext : DbContext
    {
        private string _connectionString = "Server=LAPTOP-D8S1KU5B\\SQLEXPRESS; Database=B3ConsultantsDataBase; Trusted_Connection=True;";
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Consultant
            modelBuilder.Entity<Consultant>()
                .Property(r => r.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Consultant>()
                .Property(r => r.LastName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Consultant>()
                .Property(r => r.RoleId)
                .IsRequired();
            modelBuilder.Entity<Consultant>()
                .Property(r => r.ExperienceId)
                .IsRequired();
            modelBuilder.Entity<Consultant>()
                .Property(r => r.HourlyRatePlnNet)
                .IsRequired();
            modelBuilder.Entity<Consultant>()
                .Property(r => r.Location)
                .IsRequired()
                .HasMaxLength(30);
            modelBuilder.Entity<Consultant>()
                .Property(r => r.AvailabilityId)
                .IsRequired();
            modelBuilder.Entity<Consultant>()
                .Property(r => r.ProfileSource)
                .IsRequired();

            //Availability
            modelBuilder.Entity<Availability>()
                .Property(r => r.WhenAvailable)
                .IsRequired();

            //Experience
            modelBuilder.Entity<Experience>()
                .Property(r => r.ExperienceLevel)
                .IsRequired();

            //Role
            modelBuilder.Entity<Role>()
                .Property(r => r.RoleTitle)
                .IsRequired();

            //User
            modelBuilder.Entity<User>()
                .Property(r => r.FirstName)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(r => r.LastName)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(r => r.Email)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(r => r.PhoneNumber)
                .IsRequired();
            modelBuilder.Entity<User>()
               .Property(r => r.PasswordHash)
               .IsRequired();
            modelBuilder.Entity<User>()
               .Property(r => r.UserRoleId)
               .IsRequired();

            //UserRole
            modelBuilder.Entity<UserRole>()
                .Property(r => r.UserRoleTitle)
                .IsRequired();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
