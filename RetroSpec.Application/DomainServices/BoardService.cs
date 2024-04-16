using RetroSpec.Application.Abstractions;
using RetroSpec.Application.DTOs;

namespace RetroSpec.Application.DomainServices;

public class BoardService(IUnitOfWork unitOfWork, IBoardQueryRepository boardQueryRepository) : IBoardService
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IBoardQueryRepository boardQueryRepository = boardQueryRepository;

    public async Task<BoardDTO> CreateAsync(Guid teamId, BoardCreateDTO newBoard)
    {
        try
        {
            var team = await unitOfWork.TeamRepository.FirstAsync(team => team.Id == teamId);

            await unitOfWork.BeginTransactionAsync();

            var board = team.CreateBoard(newBoard.Name);
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
