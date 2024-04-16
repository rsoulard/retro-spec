using NSubstitute;
using RetroSpec.Application.Abstractions;
using RetroSpec.Application.DomainServices;
using RetroSpec.Application.DTOs;
using RetroSpec.Core.BoardModels;
using RetroSpec.Core.OrganizationModels;
using System.Linq.Expressions;

namespace RetroSpec.UnitTests.Application;

public class ColumnServiceTests
{
    private ICommandRepository<Board> boardCommandRepository;
    private IUnitOfWork unitOfWork;
    private IColumnService columnService;

    [SetUp]
    public void SetUp()
    {
        var organization = Organization.Create("Organization");
        var team = organization.CreateTeam("Team");
        var board = team.CreateBoard("Board");

        boardCommandRepository = Substitute.For<ICommandRepository<Board>>();
        boardCommandRepository.FirstAsync(board => board.Id == Guid.Empty, null, "Columns")
            .ReturnsForAnyArgs(team.CreateBoard("Test"));

        unitOfWork = Substitute.For<IUnitOfWork>();
        unitOfWork.BoardRepository.Returns(boardCommandRepository);
        
        columnService = new ColumnService(unitOfWork);
    }

    [Test]
    public async Task CreateAsync_ValidInput_RetrievesBoardAddsColumnSavesAndReturnsCreated()
    {
        var newColumn = new ColumnCreateDTO
        {
            Name = "Test"
        };

        var result = await columnService.CreateAsync(Guid.Empty, newColumn);

        Assert.Multiple(() =>
        {
            boardCommandRepository.Received()
                .FirstAsync(Arg.Any<Expression<Func<Board, bool>>>(), Arg.Any<Func<IQueryable<Board>, IOrderedQueryable<Board>>?>(), Arg.Is("Columns"));
            unitOfWork.Received()
                .SaveChangesAsync();
            unitOfWork.Received()
                .CommitTransactionAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo("Test"));
            Assert.That(result.Id, Is.EqualTo(0));
        });
    }
}
