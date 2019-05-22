using Api.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Real
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Password=dart;User ID=dart;Initial Catalog=dart;Data Source=dart");
        
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Round> Rounds { get; set; }
    }
}
