namespace LocationTest;

public class Tests
{
    private Location _location;
    private Player _player;
    private Item _item1;
    private Item _item2;
    [SetUp]
    public void Setup()
    {
        _location = new Location(new string[] { "location" }, "mylocation", "a location");
        _player = new Player("Giang", "inventory");
        _item1 = new Item(new string[] { "item1" }, "item1", "first item");
        _item2 = new Item(new string[] { "item2" }, "item2", "second item");
    }

    [Test]
    public void LocationIdentifyItself()
    {
        Assert.IsTrue(_location.AreYou("location"));
    }

    [Test]
    public void LocationLocateItems()
    {
        _location.Inventory.Put(_item1);
        _location.Inventory.Put(_item2);
        Assert.AreEqual(_item1, _location.Locate("item1"));
        Assert.AreEqual(_item2, _location.Locate("item2"));
    }

    [Test]
    public void LocationLocateItself()
    {
        Assert.AreEqual(_location, _location.Locate("location"));
    }

    [Test]
    public void LocationLocateNothing()
    {
        Assert.IsNull(_location.Locate("nothing"));
    }

    [Test]
    public void PlayerLocateItself()
    {
        Assert.AreEqual(_player, _player.Locate("Giang"));
    }

    [Test]
    public void PlayerLocateItems()
    {
        _location.Inventory.Put(_item1);
        _location.Inventory.Put(_item2);
        _player.Location = _location;
        Assert.AreEqual(_item1, _player.Locate("item1"));
        Assert.AreEqual(_item2, _player.Locate("item2"));
    }


    [Test]
    public void LocationFullDescription()
    {
        Assert.AreEqual("You are at mylocation. a location.\n", _location.FullDescription);
    }
}
