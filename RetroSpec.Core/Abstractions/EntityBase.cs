namespace RetroSpec.Core.Abstractions;

public class EntityBase<TId> where TId : notnull
{
    public TId Id { get; init; }

    protected EntityBase(TId id)
    {
        Id = id;
    }
}
