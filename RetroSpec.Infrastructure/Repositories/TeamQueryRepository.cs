using Microsoft.EntityFrameworkCore;
using RetroSpec.Application.Abstractions;
using RetroSpec.Application.DTOs;
using RetroSpec.Core.TeamModels;
using RetroSpec.Infrastructure.DataAccess;
using System.Linq.Expressions;

namespace RetroSpec.Infrastructure.Repositories;

internal class TeamQueryRepository(RetroDbContext retroDbContext) : ITeamQueryRepository
{
    private readonly RetroDbContext retroDbContext = retroDbContext;

    public async Task<TeamDTO?> FirstOrDefaultAsync(Expression<Func<Team, bool>> predicate)
    {
        return await retroDbContext.Set<Team>()
            .AsNoTracking()
            .Where(predicate)
            .Select(team => new TeamDTO
            {
                Id = team.Id,
                Name = team.Name
            })
            .FirstOrDefaultAsync();
    }
}
