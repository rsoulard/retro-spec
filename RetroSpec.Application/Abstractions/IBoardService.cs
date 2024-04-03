using RetroSpec.Application.DTOs;

namespace RetroSpec.Application.Abstractions;

public interface IBoardService
{
    Task<BoardDTO> CreateAsync(BoardCreateDTO newBoard);
    Task<BoardDTO?> RetrieveAsync(Guid boardId);
}
