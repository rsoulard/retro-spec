using RetroSpec.Application.DTOs;
using RetroSpec.Application.Models;
using RetroSpec.Core.CardModels;
using System.Linq.Expressions;

namespace RetroSpec.Application.Abstractions;

public interface ICardQueryRepository
{
    Task<PaginatedCollection<CardDTO>> QueryPageAsync(Expression<Func<Card, bool>> predicate, int pageSize, int pageIndex);
}
