using Microsoft.AspNetCore.Mvc;
using RetroSpec.Application.Abstractions;
using RetroSpec.Application.DTOs;
using Swashbuckle.AspNetCore.Annotations;

namespace RetroSpec.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController(ITeamService teamService) : ControllerBase
    {
        private readonly ITeamService teamService = teamService;

        /// <summary>
        /// Create a new team within an organization.
        /// </summary>
        /// <param name="organizationId">The id of the organization to create the team in.</param>
        /// <param name="newTeam">Parameters for creating a team.</param>
        /// <returns>The newly created team.</returns>
        [SwaggerResponse(StatusCodes.Status201Created, "The team was created successfully.", typeof(TeamDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "One or more of the supplied arguments is invalid. See body for details.")]
        [HttpPost("/api/organization/{organizationId:guid}/[controller]")]
        public async Task<IActionResult> CreateAsync(Guid organizationId, [FromBody] TeamCreateDTO newTeam)
        {
            var result = await teamService.CreateAsync(organizationId, newTeam);
            return Created(new Uri(result.Id.ToString(), UriKind.Relative), result);
        }
    }
}
