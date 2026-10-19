using Microsoft.EntityFrameworkCore;
using ReportingService.Domain.Entities;

namespace ReportingService.Infrastructure.Persistence
{
    public class ReportingDbContext : DbContext
    {
        public ReportingDbContext(DbContextOptions<ReportingDbContext> options) : base(options)
        {
        }

        public DbSet<Trade> Trades { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Trade>(b =>
            {
                b.HasKey(t => t.Id);
                b.Property(t => t.Price).HasColumnType("decimal(18,2)");
                b.Property(t => t.Currency).IsRequired().HasMaxLength(10);
                b.Property(t => t.TraderName).IsRequired().HasMaxLength(100);
            });
        }
    }
}
