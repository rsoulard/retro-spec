using RetroSpec.Application.Abstractions;
using RetroSpec.Application.DTOs;

namespace RetroSpec.Application.DomainServices;

public class ColumnService(IUnitOfWork unitOfWork) : IColumnService
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<ColumnDTO> CreateAsync(Guid boardId, ColumnCreateDTO newColumn)
    {
        try
        {
            var board = await unitOfWork.BoardRepository.FirstAsync(board => board.Id == boardId, includedProperties: "Columns");

            await unitOfWork.BeginTransactionAsync();

            var column = board.AddColumn(newColumn.Name);

            await unitOfWork.SaveChangesAsync();

            await unitOfWork.CommitTransactionAsync();

            return ColumnDTO.FromColumn(column);
        }
        catch
        {
            await unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }
}
