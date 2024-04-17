using RetroSpec.Application.DTOs;
using RetroSpec.Core.BoardModels;
using System.Linq.Expressions;

namespace RetroSpec.Application.Abstractions;

public interface IBoardQueryRepository
{
    Task<BoardDTO?> FirstOrDefaultAsync(Expression<Func<Board, bool>> predicate);
    Task<IReadOnlyCollection<BoardListDTO>> QueryAsync(Expression<Func<Board, bool>> predicate);
}
