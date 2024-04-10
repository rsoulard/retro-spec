using Microsoft.EntityFrameworkCore;
using RetroSpec.Application.Abstractions;
using RetroSpec.Application.DTOs;
using RetroSpec.Core.CardModels;
using RetroSpec.Infrastructure.DataAccess;
using System.Linq.Expressions;

namespace RetroSpec.Infrastructure.Repositories;

internal class CardQueryRepository(RetroDbContext retroDbContext) : ICardQueryRepository
{
    private readonly RetroDbContext retroDbContext = retroDbContext;

    public async Task<IReadOnlyCollection<CardDTO>> QueryAsync(Expression<Func<Card, bool>> predicate)
    {
        return await retroDbContext.Set<Card>()
            .AsNoTracking()
            .Where(predicate)
            .Select(card => new CardDTO
            {
                Id = card.Id,
                ColumnId = card.ColumnId,
                Body = card.Body
            })
            .ToListAsync();
    }
}
