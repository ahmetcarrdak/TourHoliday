using Microsoft.EntityFrameworkCore;
using TourHoliday.Models;

namespace TourHoliday.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Tour> Tours { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AgencySaleTour> AgencySaleTours { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // DateTime properties configuration
            modelBuilder.Entity<Tour>()
                .Property(b => b.DateAdded)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Tour>()
                .Property(b => b.LastUpdated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Agency>()
                .Property(b => b.DateAdded)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Agency>()
                .Property(b => b.LastUpdated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<User>()
                .Property(b => b.DateAdded)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<User>()
                .Property(b => b.LastUpdated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<AgencySaleTour>()
                .Property(b => b.AddedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Status properties configuration
            modelBuilder.Entity<Tour>()
                .Property(b => b.Status)
                .HasDefaultValue(0);

            modelBuilder.Entity<Agency>()
                .Property(b => b.Status)
                .HasDefaultValue(0);

            modelBuilder.Entity<AgencySaleTour>()
                .Property(b => b.Status)
                .HasDefaultValue(0);

            modelBuilder.Entity<Admin>()
                .Property(b => b.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Admin>()
                .Property(b => b.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Composite Key configuration for unique relationship (if needed)
            modelBuilder.Entity<AgencySaleTour>()
                .HasIndex(a => new { a.AgencyId, a.TourId })
                .IsUnique();
        }
    }
}
