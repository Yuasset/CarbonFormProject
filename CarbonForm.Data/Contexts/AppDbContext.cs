using CarbonForm.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarbonForm.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Transportation> Transportations { get; set; }
        public DbSet<HomeEnergy> HomeEnergies { get; set; }
        public DbSet<Consumption> Consumptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>()
                .HasOne(s => s.UserInfo)
                .WithOne(u => u.Survey)
                .HasForeignKey<UserInfo>(u => u.SurveyId);

            modelBuilder.Entity<Survey>()
                .HasOne(s => s.Transportation)
                .WithOne(t => t.Survey)
                .HasForeignKey<Transportation>(t => t.SurveyId);

            modelBuilder.Entity<Survey>()
                .HasOne(s => s.HomeEnergy)
                .WithOne(h => h.Survey)
                .HasForeignKey<HomeEnergy>(h => h.SurveyId);

            modelBuilder.Entity<Survey>()
                .HasOne(s => s.Consumption)
                .WithOne(c => c.Survey)
                .HasForeignKey<Consumption>(c => c.SurveyId);

            base.OnModelCreating(modelBuilder);
        }
    }
}