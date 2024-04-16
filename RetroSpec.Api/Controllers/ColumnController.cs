using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetroSpec.Application.Abstractions;
using RetroSpec.Application.DTOs;
using Swashbuckle.AspNetCore.Annotations;

namespace RetroSpec.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ColumnController(IColumnService columnService) : ControllerBase
{
    private readonly IColumnService columnService = columnService;

    /// <summary>
    /// Create a new column on a board.
    /// </summary>
    /// <param name="boardId">The Id of the board to add the column to.</param>
    /// <param name="newColumn">Parameters for creating a column.</param>
    /// <returns>The newly created column.</returns>
    [SwaggerResponse(StatusCodes.Status201Created, "The column was created successfully.", typeof(ColumnDTO))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "One or more of the supplied arguments is invalid. See body for deatils.")]
    [HttpPost("/api/board/{boardId:guid}/[controller]")]
    public async Task<IActionResult> CreateAsync(Guid boardId, [FromBody] ColumnCreateDTO newColumn)
    {
        var result = await columnService.CreateAsync(boardId, newColumn);
        return Created(new Uri(result.Id.ToString(), UriKind.Relative), result);
    }
}
