using NSubstitute;
using RetroSpec.Application.Abstractions;
using RetroSpec.Application.DomainServices;
using RetroSpec.Application.DTOs;
using RetroSpec.Core.OrganizationModels;
using RetroSpec.Core.TeamModels;
using System.Linq.Expressions;

namespace RetroSpec.UnitTests.Application;

public class TeamServiceTests
{
    private ICommandRepository<Organization> organizationCommandRepository;
    private ICommandRepository<Team> teamCommandRepository;
    private IUnitOfWork unitOfWork;
    private ITeamQueryRepository teamQueryRepository;
    private ITeamService teamService;

    [SetUp]
    public void SetUp()
    {
        var organization = Organization.Create("Organization");

        organizationCommandRepository = Substitute.For<ICommandRepository<Organization>>();
        organizationCommandRepository.FirstAsync(organization => organization.Id == Guid.Empty)
            .ReturnsForAnyArgs(organization);

        teamCommandRepository = Substitute.For<ICommandRepository<Team>>();

        unitOfWork = Substitute.For<IUnitOfWork>();
        unitOfWork.OrganizationRepository.Returns(organizationCommandRepository);
        unitOfWork.TeamRepository.Returns(teamCommandRepository);

        teamQueryRepository = Substitute.For<ITeamQueryRepository>();
        teamQueryRepository.FirstOrDefaultAsync(team => team.Id == Guid.Empty)
            .ReturnsForAnyArgs(new TeamDTO()
            {
                Id = Guid.Empty,
                Name = "Test"
            });

        teamService = new TeamService(unitOfWork, teamQueryRepository);
    }

    [Test]
    public async Task CreateAsync_ValidInput_CallsRepositorySavesAndReturnsCreated()
    {
        var newTeam = new TeamCreateDTO
        {
            Name = "Test"
        };

        var result = await teamService.CreateAsync(Guid.Empty, newTeam);

        Assert.Multiple(() =>
        {
            organizationCommandRepository.Received()
                .FirstAsync(Arg.Any<Expression<Func<Organization, bool>>>());

            teamCommandRepository.Received()
                .AddAsync(Arg.Is<Team>(team => team.Id != Guid.Empty && team.Name == "Test"));

            unitOfWork.Received()
                .SaveChangesAsync();

            unitOfWork.Received()
                .CommitTransactionAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.Not.EqualTo(default));
            Assert.That(result.Name, Is.EqualTo("Test"));
        });
    }

    [Test]
    public async Task Retrieve_ValidInput_CallsRepository()
    {
        var result = await teamService.RetrieveAsync(Guid.Empty);

        Assert.Multiple(() =>
        {
            teamQueryRepository.Received()
                .FirstOrDefaultAsync(Arg.Any<Expression<Func<Team, bool>>>());

            Assert.That(result, Is.Not.Null);
            Assert.That(result?.Id, Is.EqualTo(Guid.Empty));
            Assert.That(result?.Name, Is.EqualTo("Test"));
        });
    }
}
