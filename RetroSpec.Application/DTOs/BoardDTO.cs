using RetroSpec.Core.BoardModels;

namespace RetroSpec.Application.DTOs;

public record BoardDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public IReadOnlyCollection<ColumnDTO> Columns { get; init; } = null!;

    public static BoardDTO FromBoard(Board board)
    {
        return new()
        {
            Id = board.Id,
            Name = board.Name,
            Columns = board.Columns.Select(column => ColumnDTO.FromColumn(column)).ToArray()
        };
    }
}
