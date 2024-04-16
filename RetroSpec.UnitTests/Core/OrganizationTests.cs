using RetroSpec.Core.OrganizationModels;

namespace RetroSpec.UnitTests.Core;

public class OrganizationTests
{
    [Test]
    public void Create_ValidInput_ReturnsCreated()
    {
        var result = Organization.Create("Test");

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.Not.EqualTo(default));
            Assert.That(result.Name, Is.EqualTo("Test"));
        });
    }

    [Test]
    public void CreateTeam_ValidInput_ReturnsNewTeam()
    {
        var organization = Organization.Create("Organization");

        var result = organization.CreateTeam("Test");

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.Not.EqualTo(default));
            Assert.That(result.OrganizationId, Is.EqualTo(organization.Id));
            Assert.That(result.Name, Is.EqualTo("Test"));
        });
    }
}
