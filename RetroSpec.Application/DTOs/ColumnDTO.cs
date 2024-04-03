using RetroSpec.Core.BoardModels;

namespace RetroSpec.Application.DTOs;

public record ColumnDTO
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;

    public static ColumnDTO FromColumn(Column column)
    {
        return new()
        {
            Id = column.Id,
            Name = column.Name
        };
    }
}
