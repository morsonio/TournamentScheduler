using Microsoft.EntityFrameworkCore;
using Scheduler.Domain.Entities;

namespace Scheduler.Infrastructure.Persistence
{
    public class SchedulerDbContext : DbContext
    {
        public SchedulerDbContext(DbContextOptions<SchedulerDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mecz ma dwie relacje do Drużyny (gospodarz i gość)
            modelBuilder.Entity<Match>()
               .HasOne(m => m.HomeTeam)
               .WithMany(t => t.HomeMatches)
               .HasForeignKey(m => m.HomeTeamId)
               .OnDelete(DeleteBehavior.Restrict); // Zapobiega kaskadowemu usuwaniu

            modelBuilder.Entity<Match>()
               .HasOne(m => m.AwayTeam)
               .WithMany(t => t.AwayMatches)
               .HasForeignKey(m => m.AwayTeamId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
