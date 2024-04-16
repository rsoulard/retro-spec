using RetroSpec.Core.Abstractions;
using RetroSpec.Core.BoardModels;

namespace RetroSpec.Core.TeamModels;

public class Team : EntityBase<Guid>, IAggregateRoot
{
    public Guid OrganizationId { get; init; }
    public string Name { get; private set; } = null!;

    private Team(Guid id, Guid organizationId, string name) : base(id)
    {
        OrganizationId = organizationId;
        Name = name;
    }

    internal static Team Create(Guid organizationId,  string name)
    {
        return new Team(Guid.NewGuid(), organizationId, name);
    }

    public Board CreateBoard(string name)
    {
        return Board.Create(Id, name);
    }
}
