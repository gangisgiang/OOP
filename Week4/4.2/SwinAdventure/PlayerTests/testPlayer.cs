using SwinAdventure;

namespace PlayerTests;

public class PlayerTest
{
    private Player _player;
    private Item _item;
    
    [SetUp]
    public void Setup()
    {
        _player = new Player("me", "inventory");
        _item = new Item(new string[] { "id1", "id2" }, "name", "desc");
    }

    [Test]
    public void IdentifiablePlayer()
    {
        Assert.IsTrue(_player.AreYou("me"));
        Assert.IsTrue(_player.AreYou("inventory"));
        Assert.IsFalse(_player.AreYou("name"));
        Assert.IsFalse(_player.AreYou("desc"));
    }

    [Test]
    public void LocateItems()
    {
        _player.Inventory.Put(_item);
        Assert.AreEqual(_item, _player.Locate("id1"));
        Assert.AreEqual(_item, _player.Locate("id2"));
        Assert.IsNull(_player.Locate("id3"));
    }

    [Test]
    public void LocateItself()
    {
        Assert.AreEqual(_player, _player.Locate("me"));
        Assert.AreEqual(_player, _player.Locate("inventory"));
    }

    [Test]
    public void LocateNothing()
    {
        Assert.IsNull(_player.Locate("Giang"));
    }

    [Test]
    public void PlayerFullDesc()
    {
        _player.Inventory.Put(_item);
        Assert.AreEqual("You are me the inventory. You are carrying:\n\ta name (id1)\n\tdesc\n", _player.FullDescription);
    }
}
