using RetroSpec.Core.BoardModels;
using RetroSpec.Core.CardModels;
using RetroSpec.Core.OrganizationModels;
using RetroSpec.Core.TeamModels;

namespace RetroSpec.Application.Abstractions;

public interface IUnitOfWork
{
    ICommandRepository<Board> BoardRepository { get; }
    ICommandRepository<Card> CardRepository { get; }
    ICommandRepository<Organization> OrganizationRepository { get; }
    ICommandRepository<Team> TeamRepository { get; }

    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
    Task SaveChangesAsync();
}
