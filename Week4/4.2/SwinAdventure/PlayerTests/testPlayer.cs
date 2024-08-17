using SwinAdventure;

namespace PlayerTests;

public class PlayerTest
{
    private Player _player;
    private Item _item;
    [SetUp]
    public void Setup()
    {
        _player = new Player("name", "desc");
        Item _item = new Item(new string[] { "id1", "id2" }, "name", "desc");

    }

    [Test]
    public void FindItem()
    {
        _player.Inventory.Put(item);
        Assert.AreEqual(_item, _player.Locate("id1"));
        Assert.AreEqual(_item, _player.Locate("id2"));
        Assert.AreEqual(null, _player.Locate("id3"));
    }

    [Test]
    public void NoItemFound()
    {
        Assert.AreEqual(null, _player.Locate("id1"));
    }
}
