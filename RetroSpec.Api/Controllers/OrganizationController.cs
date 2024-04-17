using Microsoft.AspNetCore.Mvc;
using RetroSpec.Application.Abstractions;
using RetroSpec.Application.DTOs;
using Swashbuckle.AspNetCore.Annotations;

namespace RetroSpec.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrganizationController(IOrganizationService organizationService) : ControllerBase
{
    private readonly IOrganizationService organizationService = organizationService;

    /// <summary>
    /// Create a new organization.
    /// </summary>
    /// <param name="newOrganization">Parameters for creating an organization.</param>
    /// <returns>The newly created organization.</returns>
    [SwaggerResponse(StatusCodes.Status201Created, "The organization was created successfully.", typeof(OrganizationDTO))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "One or more of the supplied arguments is invalid. See body for details.")]
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] OrganizationCreateDTO newOrganization)
    {
        var result = await organizationService.CreateAsync(newOrganization);
        return Created(new Uri(result.Id.ToString(), UriKind.Relative), result);
    }
}
