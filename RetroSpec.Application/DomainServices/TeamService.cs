using RetroSpec.Application.Abstractions;
using RetroSpec.Application.DTOs;

namespace RetroSpec.Application.DomainServices;

public class TeamService(IUnitOfWork unitOfWork, ITeamQueryRepository teamQueryRepository) : ITeamService
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly ITeamQueryRepository teamQueryRepository = teamQueryRepository;

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

    public async Task<TeamDTO?> RetrieveAsync(Guid id)
    {
        return await teamQueryRepository.FirstOrDefaultAsync(team => team.Id == id);
    }
 }
