using RetroSpec.Application.Abstractions;
using RetroSpec.Application.DTOs;
using RetroSpec.Application.Models;

namespace RetroSpec.Application.DomainServices;

public class CardService(IUnitOfWork unitOfWork, ICardQueryRepository cardQueryRepository) : ICardService
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly ICardQueryRepository cardQueryRepository = cardQueryRepository;

    public async Task<CardDTO> CreateAsync(Guid boardId, CardCreateDTO newCard)
    {
        try
        {
            var board = await unitOfWork.BoardRepository.FirstAsync(board => board.Id == boardId, includedProperties: "Columns");

            await unitOfWork.BeginTransactionAsync();

            var card = board.CreateCard(newCard.ColumnId, newCard.Body);
            await unitOfWork.CardRepository.AddAsync(card);
            await unitOfWork.SaveChangesAsync();

            await unitOfWork.CommitTransactionAsync();

            return CardDTO.FromCard(card);
        }
        catch
        {
            await unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task<IReadOnlyCollection<CardDTO>> ListAsync(Guid boardId)
    {
        return await cardQueryRepository.QueryAsync(card => card.BoardId == boardId);
    }
}
