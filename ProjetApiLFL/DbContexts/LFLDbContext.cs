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
        public DbSet<Team> Teams { get; set; } 
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasOne(m => m.RedTeam)
                .WithMany(t => t.MatchesAsRedTeam)
                .HasForeignKey(m => m.RedTeamId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.BlueTeam)
                .WithMany(t => t.MatchesAsBlueTeam)
                .HasForeignKey(m => m.BlueTeamId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}
