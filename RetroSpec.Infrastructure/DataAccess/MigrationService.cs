using Microsoft.EntityFrameworkCore;
using RetroSpec.Infrastructure.Abstractions;

namespace RetroSpec.Infrastructure.DataAccess;

internal class MigrationService(RetroDbContext dbContext) : IMigrationService
{
    private readonly RetroDbContext dbContext = dbContext;

    public void Migrate()
    {
        dbContext.Database.Migrate();
    }
}
