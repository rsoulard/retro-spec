using RetroSpec.Application.DTOs;

namespace RetroSpec.Application.Abstractions;

public interface IBoardService
{
    Task<BoardDTO> CreateAsync(Guid teamId, BoardCreateDTO newBoard);
    Task<IReadOnlyCollection<BoardListDTO>> ListAsync(Guid teamId);
    Task<BoardDTO?> RetrieveAsync(Guid boardId);
}
