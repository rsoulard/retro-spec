using RetroSpec.Core.Abstractions;

namespace RetroSpec.Core.CardModels;

public class Card : EntityBase<Guid>, IAggregateRoot
{
    public Guid BoardId { get; init; }
    public int ColumnId { get; private set; }
    public string Body { get; private set; } = null!;

    private Card(Guid id, Guid boardId, int columnId, string body) : base(id)
    {
        BoardId = boardId;
        ColumnId = columnId;
        Body = body;
    }

    internal static Card Create(Guid boardId, int columnId, string body)
    {
        return new(Guid.NewGuid(), boardId, columnId, body);
    }

    internal void MoveTo(int columnId)
    {
        ColumnId = columnId;
    }
}
