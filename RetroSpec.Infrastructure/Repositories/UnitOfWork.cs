using RetroSpec.Application.Abstractions;
using RetroSpec.Core.BoardModels;
using RetroSpec.Core.CardModels;
using RetroSpec.Core.OrganizationModels;
using RetroSpec.Core.TeamModels;
using RetroSpec.Infrastructure.DataAccess;

namespace RetroSpec.Infrastructure.Repositories;

internal sealed class UnitOfWork(RetroDbContext dbContext) : IUnitOfWork, IDisposable
{
    private readonly RetroDbContext dbContext = dbContext;

    private CommandRepository<Organization>? organizationRepository;
    public ICommandRepository<Organization> OrganizationRepository => organizationRepository ??= new(dbContext);

    private CommandRepository<Team>? teamRepository;
    public ICommandRepository<Team> TeamRepository => teamRepository ??= new(dbContext);

    private CommandRepository<Board>? boardRepository;
    public ICommandRepository<Board> BoardRepository => boardRepository ??= new(dbContext);

    private CommandRepository<Card>? cardRepository;
    public ICommandRepository<Card> CardRepository => cardRepository ??= new(dbContext);

    public async Task BeginTransactionAsync()
    {
        await dbContext.Database.BeginTransactionAsync();
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await dbContext.Database.CommitTransactionAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await dbContext.Database.RollbackTransactionAsync();
    }

    public void Dispose()
    {
        dbContext.Dispose();
        GC.SuppressFinalize(this);
    }
}
