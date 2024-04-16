using RetroSpec.Core.OrganizationModels;

namespace RetroSpec.UnitTests.Core;

public class TeamTests
{
    private Organization organization;

    [SetUp]
    public void SetUp()
    {
        organization = Organization.Create("Organization");
    }

    [Test]
    public void CreateBoard_ValidInput_ReturnsNewBoard()
    {
        var team = organization.CreateTeam("Team");

        var result = team.CreateBoard("Test");

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.Not.EqualTo(default));
            Assert.That(result.Name, Is.EqualTo("Test"));
        });
    }
}
