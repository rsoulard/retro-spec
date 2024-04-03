using RetroSpec.Application.Abstractions;
using RetroSpec.Application.DTOs;
using RetroSpec.Core.BoardModels;

namespace RetroSpec.Application.DomainServices;

public class BoardService(IUnitOfWork unitOfWork, IBoardQueryRepository boardQueryRepository) : IBoardService
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IBoardQueryRepository boardQueryRepository = boardQueryRepository;

    public async Task<BoardDTO> CreateAsync(BoardCreateDTO newBoard)
    {
        try
        {
            await unitOfWork.BeginTransactionAsync();

            var board = Board.Create(newBoard.Name);
            await unitOfWork.BoardRepository.AddAsync(board);
            await unitOfWork.SaveChangesAsync();

            await unitOfWork.CommitTransactionAsync();

            return BoardDTO.FromBoard(board);
        }
        catch
        {
            await unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task<BoardDTO?> RetrieveAsync(Guid boardId)
    {
        return await boardQueryRepository.FirstOrDefaultAsync(board => board.Id == boardId);
    }
}
