using System.Numerics;
using SwinAdventure;

namespace LookCommandTests;

public class LookCommandTest
{
    private Player _player;
    private LookCommand _look;
    private Item _gem;
    private Bag _bag;

    [SetUp]
    public void Setup()
    {
        _player = new Player("Giang", "inventory");
        _look = new LookCommand();
        _gem = new Item(new string[] { "gem" }, "gem", "bright red gem");
        _bag = new Bag(new string[] { "bag" }, "bag", "green bag");
    }

    [Test]
    public void LookAtMe()
    {
        string result = _look.Execute(_player, new string[] { "look", "at", "inventory" });
        Assert.AreEqual("You are Giang the inventory. You are carrying:\n", result);
    }

    [Test]
    public void LookAtGem()
    {
        _player.Inventory.Put(_gem);
        string result = _look.Execute(_player, new string[] { "look", "at", "gem" });
        Assert.AreEqual("This is a bright red gem", result);
    }

    [Test]
    public void LookAtUnknown()
    {
        string result = _look.Execute(_player, new string[] { "look", "at", "gem" });
        Assert.AreEqual("I cannot find the gem", result);
    }

    [Test]
    public void LookAtGemInMe()
    {
        _player.Inventory.Put(_gem);
        string result = _look.Execute(_player, new string[] { "look", "at", "gem", "in", "inventory" });
        Assert.AreEqual("This is a bright red gem", result);
    }

    [Test]
    public void LookAtGemInBag()
    {
        _player.Inventory.Put(_bag);
        _bag.Inventory.Put(_gem);
        string result = _look.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" });
        Assert.AreEqual("This is a bright red gem", result);
    }

    [Test]
    public void LookAtGemInNoBag()
    {
        string result = _look.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" });
        Assert.AreEqual("I cannot find the bag", result);
    }

    [Test]
    public void LookAtNoGemInBag()
    {
        _player.Inventory.Put(_bag);
        string result = _look.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" });
        Assert.AreEqual("I cannot find the gem", result);
    }

    [Test]
    public void InvalidLook()
    {
        string result = _look.Execute(_player, new string[] { "look", "around" });
        Assert.AreEqual("I don't know how to look like that", result);

        result = _look.Execute(_player, new string[] { "hello", "104828510" });
        Assert.AreEqual("I don't know how to look like that", result);

        result = _look.Execute(_player, new string[] { "look", "at", "Giang" });
        Assert.AreEqual("I cannot find the Giang", result);
    }
}