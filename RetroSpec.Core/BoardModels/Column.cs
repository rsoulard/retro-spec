using RetroSpec.Core.Abstractions;

namespace RetroSpec.Core.BoardModels;

public class Column : EntityBase<int>
{
    public string Name { get; private set; } = null!;

    private Column(int id, string name) : base(id)
    {
        Name = name;
    }

    internal static Column Create(int id, string name)
    {
        return new(id,  name);
    }
}
