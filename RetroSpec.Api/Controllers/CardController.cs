using Microsoft.AspNetCore.Mvc;
using RetroSpec.Application.Abstractions;
using RetroSpec.Application.DTOs;
using Swashbuckle.AspNetCore.Annotations;

namespace RetroSpec.Api.Controllers;

[Route("api/{boardId:guid}/[controller]")]
[ApiController]
public class CardController(ICardService cardService) : ControllerBase
{
    private readonly ICardService cardService = cardService;

    /// <summary>
    /// Create a new card in a column on a board.
    /// </summary>
    /// <param name="boardId">The Id of the board to add to the card to.</param>
    /// <param name="newCard">Parameters for creating a card.</param>
    /// <returns>The newly created card.</returns>
    [HttpPost]
    [SwaggerResponse(StatusCodes.Status201Created, "The card was created successfully.", typeof(CardDTO))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "One or more of the supplied arguments is invalid. See body for deatils.")]
    public async Task<IActionResult> CreateAsync(Guid boardId, [FromBody]CardCreateDTO newCard)
    {
        var result = await cardService.CreateAsync(boardId, newCard);
        return Created(new Uri(result.Id.ToString(), UriKind.Relative), result);
    }

    /// <summary>
    /// Filter all cards in a board for a page of results.
    /// </summary>
    /// <param name="boardId">The Id of the board to filter cards from.</param>
    /// <param name="cardFilter">Parameters for creating the page of filtered cards.</param>
    /// <returns>A page of filtered cards.</returns>
    [HttpGet]
    public async Task<IActionResult> FilterAsync(Guid boardId, [FromQuery] CardFilterDTO cardFilter)
    {
        var result = await cardService.FilterAsync(boardId, cardFilter);
        return Ok(result);
    }
}
