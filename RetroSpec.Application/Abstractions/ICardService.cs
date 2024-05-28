using RetroSpec.Application.DTOs;
using RetroSpec.Application.Models;

namespace RetroSpec.Application.Abstractions;

public interface ICardService
{
    Task<CardDTO> CreateAsync(Guid boardId, CardCreateDTO newCard);
    Task<IReadOnlyCollection<CardDTO>> ListAsync(Guid boardId);
    Task MoveAsync(Guid cardId, CardMoveDTO cardMove);
}
