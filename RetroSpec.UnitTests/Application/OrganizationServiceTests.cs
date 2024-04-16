using NSubstitute;
using RetroSpec.Application.Abstractions;
using RetroSpec.Application.DomainServices;
using RetroSpec.Application.DTOs;
using RetroSpec.Core.OrganizationModels;

namespace RetroSpec.UnitTests.Application;

public class OrganizationServiceTests
{
    private ICommandRepository<Organization> organizationCommandRepository;
    private IUnitOfWork unitOfWork;
    private IOrganizationService organizationService;

    [SetUp]
    public void SetUp()
    {
        organizationCommandRepository = Substitute.For<ICommandRepository<Organization>>();
        unitOfWork = Substitute.For<IUnitOfWork>();
        unitOfWork.OrganizationRepository.Returns(organizationCommandRepository);

        organizationService = new OrganizationService(unitOfWork);
    }

    [Test]
    public async Task CreateAsync_ValidInput_CallsRepositorySavesAndReturnsCreated()
    {
        var newOrganization = new OrganizationCreateDTO
        {
            Name = "Test"
        };

        var result = await organizationService.CreateAsync(newOrganization);

        Assert.Multiple(() =>
        {
            organizationCommandRepository.Received()
                .AddAsync(Arg.Is<Organization>(organization => organization.Id != Guid.Empty && organization.Name == "Test"));

            unitOfWork.Received()
                .SaveChangesAsync();

            unitOfWork.Received()
                .CommitTransactionAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.Not.EqualTo(default));
            Assert.That(result.Name, Is.EqualTo("Test"));
        });
    }
}
