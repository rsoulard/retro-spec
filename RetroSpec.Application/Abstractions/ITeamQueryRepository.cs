using RetroSpec.Application.DTOs;
using RetroSpec.Core.TeamModels;
using System.Linq.Expressions;

namespace RetroSpec.Application.Abstractions;

public interface ITeamQueryRepository
{
    Task<TeamDTO?> FirstOrDefaultAsync(Expression<Func<Team, bool>> predicate);
}
