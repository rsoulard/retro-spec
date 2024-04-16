using RetroSpec.Application.Abstractions;
using RetroSpec.Application.DTOs;

namespace RetroSpec.Application.DomainServices;

public class TeamService(IUnitOfWork unitOfWork) : ITeamService
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<TeamDTO> CreateAsync(Guid organizationId, TeamCreateDTO newTeam)
    {
        try
        {
            var organization = await unitOfWork.OrganizationRepository.FirstAsync(organization => organization.Id == organizationId);

            await unitOfWork.BeginTransactionAsync();

            var team = organization.CreateTeam(newTeam.Name);
            await unitOfWork.TeamRepository.AddAsync(team);
            await unitOfWork.SaveChangesAsync();

            await unitOfWork.CommitTransactionAsync();

            return TeamDTO.FromTeam(team);
        }
        catch
        {
            await unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }
}
