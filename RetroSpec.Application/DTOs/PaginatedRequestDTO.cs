namespace RetroSpec.Application.DTOs;

public record PaginatedRequestDTO
{
    public int PageSize { get; init; } = 10;
    public int PageIndex { get; init; } = 0;
}
