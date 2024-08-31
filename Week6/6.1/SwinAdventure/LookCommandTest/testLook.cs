namespace LookCommandTests;

public class LookCommandTest
{
    private Player _player;
    private LookCommand _lookCommand;
    pprivate Item _gem;
    [SetUp]
    public void Setup()
    {
        _player = new Player("Giang", "the inventory");
        _look = new LookCommand();
        _gem = new Item(new string[] { "gem" }, "a gem", "a bright red gem");
    }

    [Test]
    public void LookAtMe()
    {
        string[] text = { "look", "at", "inventory" };
        string result = look.Execute(p, text);
        Assert.AreEqual("You are Giang the inventory. You are carrying:\n", result);
    }

    [Test]
    public void LookAtGem()
    {
        _player.Inventory.Put(gem);
        string[] text = { "look", "at", "gem" };
        string result = look.Execute(p, text);
        Assert.AreEqual("a shiny gem", result);
    }

    [Test]
    public void LookAtUnknown()
    {
        string[] text = { "look", "at", "gem" };
        string result = look.Execute(p, text);
        Assert.AreEqual("I can't find the gem", result);
    }

    [Test]
    public void LookAtGemInMe()
    {
        _player.Inventory.Put(gem);
        string[] text = { "look", "at", "gem", "in", "inventory" };
        string result = look.Execute(p, text);
        Assert.AreEqual("a bright red gem", result);
    }

    [Test]
    public void LookAtGemInBag()
    {
}
