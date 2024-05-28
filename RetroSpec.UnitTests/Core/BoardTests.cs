using RetroSpec.Core.OrganizationModels;
using RetroSpec.Core.TeamModels;

namespace RetroSpec.UnitTests.Core;

public class BoardTests
{
    private Team team;

    [SetUp]
    public void SetUp()
    {
        var organization = Organization.Create("Organization");
        team = organization.CreateTeam("Team");
    }

    [Test]
    public void AddColumn_ValidInput_ReturnsCreated()
    {
        var board = team.CreateBoard("Board");

        var result = board.AddColumn("Test");

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.Zero);
            Assert.That(result.Name, Is.EqualTo("Test"));
        });
    }

    [Test]
    public void AddColumn_ExistingColumnWithValidInput_ReturnsCreatedWithCorrectId()
    {
        var board = team.CreateBoard("Board");
        var column1 = board.AddColumn("Test1");

        var result = board.AddColumn("Test2");

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(column1.Id + 1));
            Assert.That(result.Name, Is.EqualTo("Test2"));
        });
    }

    [Test]
    public void CreateCard_ValidInput_ReturnsCreated()
    {
        var board = team.CreateBoard("Board");
        board.AddColumn("Test");

        var result = board.CreateCard(0, "Test");

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.Not.EqualTo(default));
            Assert.That(result.BoardId, Is.EqualTo(board.Id));
            Assert.That(result.ColumnId, Is.EqualTo(0));
            Assert.That(result.Body, Is.EqualTo("Test"));
        });
    }

    [Test]
    public void CreateCard_InvalidColumnId_ThrowsException()
    {
        var board = team.CreateBoard("Board");
        board.AddColumn("Test");

        Assert.Throws<Exception>(() => board.CreateCard(int.MaxValue, "Test"));
    }

    [Test]
    public void MoveCard_ValidInput_UpdatesCardColumnId()
    {
        var board = team.CreateBoard("Board");
        board.AddColumn("Column1");
        board.AddColumn("Column2");
        var card = board.CreateCard(0, "Test");

        board.MoveCard(card, 1);

        Assert.That(card.ColumnId, Is.EqualTo(1));
    }

    [Test]
    public void MoveCard_InvalidColumnId_ThrowsException()
    {
        var board = team.CreateBoard("Board");
        board.AddColumn("Test");
        var card = board.CreateCard(0, "Test");

        Assert.Throws<Exception>(() => board.MoveCard(card, int.MaxValue));
    }
}
