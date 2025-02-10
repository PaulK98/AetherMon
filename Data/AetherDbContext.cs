using Microsoft.EntityFrameworkCore;
using AetherMon.Models;

namespace AetherMon.Data
{
    /// <summary>
    /// Database context for AetherMon application using SQLite
    /// Handles all database operations and entity mappings
    /// </summary>
    public class AetherDbContext : DbContext
    {
        public AetherDbContext(DbContextOptions<AetherDbContext> options) : base(options) { }

        /// <summary>
        /// DbSet for captured Pokémon entities
        /// </summary>
        public DbSet<AetherCapture> Captures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity properties and constraints
            modelBuilder.Entity<AetherCapture>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.CaptureTime).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
        }
    }
}
