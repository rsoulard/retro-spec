using Microsoft.AspNetCore.Mvc;
using RetroSpec.Application.Abstractions;
using RetroSpec.Application.DTOs;
using Swashbuckle.AspNetCore.Annotations;

namespace RetroSpec.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BoardController(IBoardService boardService) : ControllerBase
{
    private readonly IBoardService boardService = boardService;

    /// <summary>
    /// Create a new board.
    /// </summary>
    /// <param name="newBoard">Parameters for creating a board.</param>
    /// <returns>The newly created board.</returns>
    [SwaggerResponse(StatusCodes.Status201Created, "The board was created successfully.", typeof(BoardDTO))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "One or more of the supplied arguments is invalid. See body for deatils.")]
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] BoardCreateDTO newBoard)
    {
        var result = await boardService.CreateAsync(newBoard);
        return Created(new Uri(result.Id.ToString(), UriKind.Relative), result);
    }

    /// <summary>
    /// Retireve a board by its Id.
    /// </summary>
    /// <param name="id">The Id of the board to retrieve.</param>
    /// <returns>The requested board as a DTO.</returns>
    [SwaggerResponse(StatusCodes.Status200OK, "The board was retrieved successfully.", typeof(BoardDTO))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The board with the provided Id does not exist.")]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> RetrieveAsync(Guid id)
    {
        var result = await boardService.RetrieveAsync(id);
        return result is null ? NotFound() : Ok(result);
    }
}
