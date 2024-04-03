﻿using RetroSpec.Core.Abstractions;
using RetroSpec.Core.CardModels;

namespace RetroSpec.Core.BoardModels;

public class Board : EntityBase<Guid>, IAggregateRoot
{
    public string Name { get; private set; } = null!;

    private List<Column> columns = new();
    public IReadOnlyCollection<Column> Columns => columns;

    private Board(Guid id, string name) : base(id)
    {
        Name = name;
    }

    public static Board Create(string name)
    {
        return new(Guid.NewGuid(), name);
    }

    public Column AddColumn(string name)
    {
        var nextColumnId = columns.OrderBy(column => column.Id)
            .LastOrDefault()?.Id + 1 ?? 0;

        var column = Column.Create(nextColumnId, name);
        columns.Add(column);

        return column;
    }

    public Card CreateCard(int columnId, string body)
    {
        if (!columns.Any(column => column.Id == columnId))
        {
            throw new Exception($"Board with id {Id} does not have column with id {columnId}");
        }

        return Card.Create(Id, columnId, body);
    }
}
