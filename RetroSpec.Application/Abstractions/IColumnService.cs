using RetroSpec.Application.DTOs;

namespace RetroSpec.Application.Abstractions;

public interface IColumnService
{
    Task<ColumnDTO> CreateAsync(Guid boardId, ColumnCreateDTO newColumn);
}
