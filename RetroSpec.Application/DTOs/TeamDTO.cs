using RetroSpec.Core.TeamModels;

namespace RetroSpec.Application.DTOs;

public record TeamDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;

    public static TeamDTO FromTeam(Team team)
    {
        return new()
        {
            Id = team.Id,
            Name = team.Name
        };
    }
}
