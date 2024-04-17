using NSubstitute;
using RetroSpec.Application.Abstractions;
using RetroSpec.Application.DomainServices;
using RetroSpec.Application.DTOs;
using RetroSpec.Core.BoardModels;
using RetroSpec.Core.OrganizationModels;
using RetroSpec.Core.TeamModels;
using System.Linq.Expressions;

namespace RetroSpec.UnitTests.Application
{
    public class BoardServiceTests
    {
        private ICommandRepository<Team> teamCommandRepository;
        private ICommandRepository<Board> boardCommandRepository;
        private IUnitOfWork unitOfWork;
        private IBoardQueryRepository boardQueryRepository;
        private IBoardService boardService;

        [SetUp]
        public void SetUp()
        {
            var organization = Organization.Create("Organization");
            var team = organization.CreateTeam("Team");

            teamCommandRepository = Substitute.For<ICommandRepository<Team>>();
            teamCommandRepository.FirstAsync(team => team.Id == Guid.Empty)
                .ReturnsForAnyArgs(team);

            boardCommandRepository = Substitute.For<ICommandRepository<Board>>();

            unitOfWork = Substitute.For<IUnitOfWork>();
            unitOfWork.TeamRepository.Returns(teamCommandRepository);
            unitOfWork.BoardRepository.Returns(boardCommandRepository);

            boardQueryRepository = Substitute.For<IBoardQueryRepository>();
            boardQueryRepository.FirstOrDefaultAsync(board => board.Id == Guid.Empty)
                .ReturnsForAnyArgs(new BoardDTO()
                {
                    Id = Guid.Empty,
                    Name = "Test",
                    Columns =
                    [
                        new()
                        {
                            Id = 0,
                            Name = "Test"
                        }
                    ]
                });
            boardQueryRepository.QueryAsync(board => board.TeamId == Guid.Empty)
                .ReturnsForAnyArgs(new List<BoardListDTO>()
                {
                    new ()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Board 1",
                    },
                    new ()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Board 2",
                    },
                    new ()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Board 3",
                    }
                });

            boardService = new BoardService(unitOfWork, boardQueryRepository);
        }

        [Test]
        public async Task CreateAsync_ValidInput_CallsRepositorySavesAndReturnsCreated()
        {
            var newBoard = new BoardCreateDTO
            {
                Name = "Test"
            };

            var result = await boardService.CreateAsync(Guid.Empty, newBoard);

            Assert.Multiple(() =>
            {
                teamCommandRepository.Received()
                    .FirstAsync(Arg.Any<Expression<Func<Team, bool>>>());
                
                boardCommandRepository.Received()
                    .AddAsync(Arg.Is<Board>(board => board.Id != Guid.Empty && board.Name == "Test"));

                unitOfWork.Received()
                    .SaveChangesAsync();

                unitOfWork.Received()
                    .CommitTransactionAsync();

                Assert.That(result, Is.Not.Null);
                Assert.That(result.Id, Is.Not.EqualTo(default));
                Assert.That(result.Columns, Has.None.Count);
                Assert.That(result.Name, Is.EqualTo("Test"));
                
            });
        }

        [Test]
        public async Task List_ValidInput_CallsRepository()
        {
            var result = await boardService.ListAsync(Guid.Empty);

            Assert.Multiple(() =>
            {
                boardQueryRepository.Received()
                    .QueryAsync(Arg.Any<Expression<Func<Board, bool>>>());

                Assert.That(result, Is.Not.Null);
                Assert.That(result, Has.Count.EqualTo(3));
            });
        }

        [Test]
        public async Task Retrieve_ValidInput_CallsRepository()
        {
            var result = await boardService.RetrieveAsync(Guid.Empty);

            Assert.Multiple(() =>
            {
                boardQueryRepository.Received()
                    .FirstOrDefaultAsync(Arg.Any<Expression<Func<Board, bool>>>());

                Assert.That(result, Is.Not.Null);
                Assert.That(result?.Id, Is.EqualTo(Guid.Empty));
                Assert.That(result?.Name, Is.EqualTo("Test"));
            });
        }
    }
}
