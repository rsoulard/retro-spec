namespace RetroSpec.Application.DTOs;

public record CardFilterDTO : PaginatedRequestDTO
{
    public int ColumnId { get; init; }
}
