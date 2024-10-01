using NUnit.Framework;
using SwinAdventure;

namespace PathTest;
public class Tests
{
    private Location _location;
    private Path _path;
    private Player _player;

    [SetUp]
    public void Setup()
    {
        _location = new Location(new string[] { "location" }, "Location", "A location");
        _path = new Path(new string[] { "path" }, "A path", _location);
        _player = new Player("Player", "A player");
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}