using RetroSpec.Core.Abstractions;
using RetroSpec.Core.TeamModels;

namespace RetroSpec.Core.OrganizationModels;

public class Organization : EntityBase<Guid>, IAggregateRoot
{
    public string Name { get; private set; } = null!;
    
    private Organization(Guid id, string name) : base(id)
    {
        Name = name;
    }

    public static Organization Create(string name)
    {
        return new(Guid.NewGuid(), name);
    }

    public Team CreateTeam(string name)
    {
        return Team.Create(Id, name);
    }
}
