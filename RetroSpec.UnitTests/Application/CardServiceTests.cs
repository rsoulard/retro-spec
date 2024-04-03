using NSubstitute;
using RetroSpec.Application.Abstractions;
using RetroSpec.Application.DomainServices;
using RetroSpec.Application.DTOs;
using RetroSpec.Core.BoardModels;
using RetroSpec.Core.CardModels;
using System.Linq.Expressions;

namespace RetroSpec.UnitTests.Application;

public class CardServiceTests
{
    private ICommandRepository<Card> cardCommandRepository;
    private ICommandRepository<Board> boardCommandRepository;
    private IUnitOfWork unitOfWork;
    private ICardQueryRepository cardQueryRepository;
    private ICardService cardService;

    private Guid testBoardId;

    [SetUp]
    public void SetUp()
    {
        var board = Board.Create("Test");
        board.AddColumn("Test");
        testBoardId = board.Id;

        cardCommandRepository = Substitute.For<ICommandRepository<Card>>();
        boardCommandRepository = Substitute.For<ICommandRepository<Board>>();
        boardCommandRepository.FirstAsync(board => board.Id == testBoardId, null, "Columns")
            .ReturnsForAnyArgs(board);

        unitOfWork = Substitute.For<IUnitOfWork>();
        unitOfWork.CardRepository.Returns(cardCommandRepository);
        unitOfWork.BoardRepository.Returns(boardCommandRepository);

        cardQueryRepository = Substitute.For<ICardQueryRepository>();

        cardService = new CardService(unitOfWork, cardQueryRepository);
    }

    [Test]
    public async Task CreateAsync_ValidInput_RetrievesBoardCreatesCardAddsCardSavesAndReturnsCreated()
    {
        var newCard = new CardCreateDTO
        {
            ColumnId = 0,
            Body = "Test"
        };

        var result = await cardService.CreateAsync(Guid.Empty, newCard);

        Assert.Multiple(() =>
        {
            boardCommandRepository.Received()
                .FirstAsync(Arg.Any<Expression<Func<Board, bool>>>(), Arg.Any<Func<IQueryable<Board>, IOrderedQueryable<Board>>?>(), Arg.Is("Columns"));
            cardCommandRepository.Received()
                .AddAsync(Arg.Is<Card>(card => card.Id != default && card.Body == "Test" && card.BoardId == testBoardId && card.ColumnId == 0));
            unitOfWork.Received()
                .SaveChangesAsync();
            unitOfWork.Received()
                .CommitTransactionAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.Not.EqualTo(default));
            Assert.That(result.ColumnId, Is.EqualTo(0));
            Assert.That(result.Body, Is.EqualTo("Test"));
        });
    }

    [Test]
    public async Task FilterAsync_ValidInput_CallsRepository()
    {
        var cardFilter = new CardFilterDTO
        {
            ColumnId = 0,
            PageIndex = 0,
            PageSize = 10
        };

        var result = await cardService.FilterAsync(testBoardId, cardFilter);

        Assert.Multiple(() =>
        {
            cardQueryRepository.Received()
                .QueryPageAsync(Arg.Any<Expression<Func<Card, bool>>>(), Arg.Is(10), Arg.Is(0));

        });
    }
}
