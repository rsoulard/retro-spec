﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetroSpec.Application.Abstractions;
using RetroSpec.Application.DTOs;
using Swashbuckle.AspNetCore.Annotations;

namespace RetroSpec.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
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
    [SwaggerResponse(StatusCodes.Status201Created, "The card was created successfully.", typeof(CardDTO))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "One or more of the supplied arguments is invalid. See body for details.")]
    [HttpPost("/api/board/{boardId:guid}/[controller]")]
    public async Task<IActionResult> CreateAsync(Guid boardId, [FromBody]CardCreateDTO newCard)
    {
        var result = await cardService.CreateAsync(boardId, newCard);
        return Created(new Uri(result.Id.ToString(), UriKind.Relative), result);
    }

    /// <summary>
    /// List all cards in a board.
    /// </summary>
    /// <param name="boardId">The Id of the board to filter cards from.</param>
    /// <returns>A list of cards.</returns>
    [SwaggerResponse(StatusCodes.Status200OK, "The cards were retrieved successfully.", typeof(IReadOnlyCollection<CardDTO>))]
    [HttpGet("/api/board/{boardId:guid}/[controller]")]
    public async Task<IActionResult> ListAsync(Guid boardId)
    {
        var result = await cardService.ListAsync(boardId);
        return Ok(result);
    }

    /// <summary>
    /// Move a card to another column in the board.
    /// </summary>
    /// <param name="cardId">The Id of the card to move.</param>
    /// <param name="cardMove">The card move parameters.</param>
    [SwaggerResponse(StatusCodes.Status200OK, "The card was moved successfully.")]
    [HttpPost("{cardId:guid}/move")]
    public async Task<IActionResult> MoveAsync(Guid cardId, [FromBody]CardMoveDTO cardMove)
    {
        await cardService.MoveAsync(cardId, cardMove);
        return Ok();
    }
}
