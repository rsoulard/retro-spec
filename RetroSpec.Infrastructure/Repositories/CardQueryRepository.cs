using Microsoft.EntityFrameworkCore;
using RetroSpec.Application.Abstractions;
using RetroSpec.Application.DTOs;
using RetroSpec.Application.Models;
using RetroSpec.Core.CardModels;
using RetroSpec.Infrastructure.DataAccess;
using System.Linq.Expressions;

namespace RetroSpec.Infrastructure.Repositories;

internal class CardQueryRepository(RetroDbContext retroDbContext) : ICardQueryRepository
{
    private readonly RetroDbContext retroDbContext = retroDbContext;

    public async Task<PaginatedCollection<CardDTO>> QueryPageAsync(Expression<Func<Card, bool>> predicate, int pageSize, int pageIndex)
    {
        var result = await retroDbContext.Set<Card>()
            .AsNoTracking()
            .Where(predicate)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .Select(card => new CardDTO
            {
                Id = card.Id,
                ColumnId = card.ColumnId,
                Body = card.Body
            })
            .ToListAsync();

        var totalCount = await retroDbContext.Set<Card>()
            .CountAsync();

        return new(pageSize, pageIndex, totalCount, [.. result]);
    }
}
