namespace RetroSpec.Application.DTOs;

public record CardCreateDTO
{
    public int ColumnId { get; init; }
    public string Body { get; init; } = null!;
}
