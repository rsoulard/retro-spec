using RetroSpec.Core.BoardModels;

namespace RetroSpec.UnitTests.Core;

public class BoardTests
{
    [Test]
    public void Create_ValidInput_ReturnsCreated()
    {
        var result = Board.Create("Test");

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.Not.EqualTo(default));
            Assert.That(result.Name, Is.EqualTo("Test"));
        });
    }

    [Test]
    public void AddColumn_ValidInput_ReturnsCreated()
    {
        var board = Board.Create("Test");

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
        var board = Board.Create("Test");
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
        var board = Board.Create("Test");
        var column = board.AddColumn("Test");

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
}
