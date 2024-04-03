using RetroSpec.Core.BoardModels;
using RetroSpec.Core.CardModels;

namespace RetroSpec.Application.Abstractions;

public interface IUnitOfWork
{
    ICommandRepository<Board> BoardRepository { get; }
    ICommandRepository<Card> CardRepository { get; }

    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
    Task SaveChangesAsync();
}
