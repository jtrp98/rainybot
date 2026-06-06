using Microsoft.EntityFrameworkCore;
using RainyBot.Domain.Entities;

namespace RainyBot.Infrastructure.Persistence;

public sealed class RainyBotDbContext : DbContext
{
    public RainyBotDbContext(DbContextOptions<RainyBotDbContext> options)
        : base(options)
    {
    }

    public DbSet<AgentExecution> AgentExecutions => Set<AgentExecution>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AgentExecution>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.AgentName).IsRequired().HasMaxLength(128);
            entity.Property(e => e.Event).HasMaxLength(1000);
            entity.Property(e => e.CreatedAtUtc).IsRequired();
        });
    }
}
