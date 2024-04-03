using Microsoft.EntityFrameworkCore;
using RetroSpec.Application.Abstractions;
using RetroSpec.Application.DTOs;
using RetroSpec.Core.BoardModels;
using RetroSpec.Infrastructure.DataAccess;
using System.Linq.Expressions;

namespace RetroSpec.Infrastructure.Repositories;

internal class BoardQueryRepository(RetroDbContext retroDbContext) : IBoardQueryRepository
{
    private readonly RetroDbContext retroDbContext = retroDbContext;

    public async Task<BoardDTO?> FirstOrDefaultAsync(Expression<Func<Board, bool>> predicate)
    {
        return await retroDbContext.Set<Board>()
            .AsNoTracking()
            .Include(board => board.Columns)
            .Where(predicate)
            .Select(board => new BoardDTO
            {
                Id = board.Id,
                Name = board.Name,
                Columns = board.Columns.Select(column => new ColumnDTO
                {
                    Id = column.Id,
                    Name = column.Name
                })
                .ToArray()
            })
            .FirstOrDefaultAsync();
    }
}
