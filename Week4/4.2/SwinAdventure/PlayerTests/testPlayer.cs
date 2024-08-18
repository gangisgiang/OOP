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
        Item _item = new Item(new string[] { "id1", "id2" }, "name", "desc");

    }

    [Test]
    public void IdentPlayer()
    {
        Assert.IsTrue(_player.AreYou("me"));
        Assert.IsTrue(_player.AreYou("inventory"));
        Assert.IsFalse(_player.AreYou("name"));
        Assert.IsFalse(_player.AreYou("desc"));
        Assert.IsFalse(_player.AreYou("id3"));
    }
