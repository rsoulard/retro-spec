using RetroSpec.Application.DTOs;
using RetroSpec.Core.CardModels;
using System.Linq.Expressions;

namespace RetroSpec.Application.Abstractions;

public interface ICardQueryRepository
{
    Task<IReadOnlyCollection<CardDTO>> QueryAsync(Expression<Func<Card, bool>> predicate);
}
