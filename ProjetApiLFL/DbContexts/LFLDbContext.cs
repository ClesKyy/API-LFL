using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetApiLFL.Models;

namespace ProjetApiLFL.DbContexts
{
    public class LFLDbContext : IdentityDbContext<User, Role, Guid>
    {
        public LFLDbContext(DbContextOptions<LFLDbContext> options) : base(options)
        {

        }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Match> Matchs { get; set; }
        public DbSet<Player> Players { get ; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Team> Teams { get; set; } 
        public DbSet<User> Users { get; set; }
    }
}
