using RetroSpec.Application.DTOs;
using RetroSpec.Application.Models;

namespace RetroSpec.Application.Abstractions;

public interface ICardService
{
    Task<CardDTO> CreateAsync(Guid boardId, CardCreateDTO newCard);
    Task<PaginatedCollection<CardDTO>> FilterAsync(Guid boardId, CardFilterDTO filter);
}
