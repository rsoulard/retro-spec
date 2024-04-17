using RetroSpec.Application.DTOs;

namespace RetroSpec.Application.Abstractions;

public interface ITeamService
{
    Task<TeamDTO> CreateAsync(Guid organizationId, TeamCreateDTO newTeam);
    Task<TeamDTO?> RetrieveAsync(Guid id);
}