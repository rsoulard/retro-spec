using RetroSpec.Core.CardModels;

namespace RetroSpec.Application.DTOs;

public record CardDTO
{
    public Guid Id { get; init; }
    public int ColumnId { get; init; }
    public string Body { get; init; } = null!;

    public static CardDTO FromCard(Card card)
    {
        return new()
        {
            Id = card.Id,
            ColumnId = card.ColumnId,
            Body = card.Body
        };
    }
}
