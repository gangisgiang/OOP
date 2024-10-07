using SwinAdventure;

namespace TestPath;

public class Tests
{
    private Player _player;
    private Location _location;
    private Location _location1;
    private SwinAdventure.Path _path;
    private MoveCommand _moveCommand;

    [SetUp]
    public void Setup()
    {
        _location = new Location(new string[] { "location" }, "location", "location");
        _location1 = new Location(new string[] { "location2" }, "location2", "location2");
        _path = new SwinAdventure.Path(new string[] { "south" }, "path", _location1);
        _player = new Player("player", "player", _location);
        _moveCommand = new MoveCommand();
        _location.AddPath(_path);
        _player.Location = _location;
    }

    [Test]
    public void TestPlayerMovesToValidPath()
    {
        string direction = _moveCommand.Execute(_player, new string[] { "move", "south" });
        Assert.That(_player.Location, Is.EqualTo(_location1));
        Assert.That(direction, Is.EqualTo("You head south\npath\nYou have arrived at location2"));
    }

    [Test]
    public void TestPlayerRemainsInLocationWithInvalidPath()
    {
        string nodirection = _moveCommand.Execute(_player, new string[] { "move", "north" });
        Assert.That(_player.Location, Is.EqualTo(_location));
        Assert.That(nodirection, Is.EqualTo("You can't move in that direction."));
    }

    [Test]
    public void TestGetPathFromLocation()
    {
        var locatedPath = _location.GetPath("south");

        // Ensure that the located path is not null
        Assert.NotNull(locatedPath, "Path could not be found in the location.");

        // Compare key properties to verify they are logically equal
        Assert.AreEqual(_path.Description, locatedPath.Description, "The description of the located path does not match.");
        Assert.AreEqual(_path.Destination, locatedPath.Destination, "The destination of the located path does not match.");
        Assert.AreEqual(_path.FirstId, locatedPath.FirstId, "The identifier of the located path does not match.");
    }
}
