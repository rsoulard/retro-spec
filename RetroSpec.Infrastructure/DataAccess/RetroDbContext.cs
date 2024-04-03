using Microsoft.EntityFrameworkCore;
using RetroSpec.Infrastructure.DataAccess.Configurations;

namespace RetroSpec.Infrastructure.DataAccess;

internal class RetroDbContext : DbContext
{
    public RetroDbContext(DbContextOptions<RetroDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CardConfiguration).Assembly);
    }
}
