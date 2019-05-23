using Api.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Real
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         //=> optionsBuilder.UseNpgsql("Host=dart_db;Database=postgres;Username=postgres;Password=postgres");
         => optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=postgres");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasIndex(g => g.Id);
            modelBuilder.Entity<Player>().HasIndex(p => p.Id);
            modelBuilder.Entity<Round>().HasIndex(r => r.Id);
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Round> Rounds { get; set; }
    }
}
