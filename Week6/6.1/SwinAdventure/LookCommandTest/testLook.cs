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
        _player = new Player("Giang", "the inventory");
        _look = new LookCommand();
        _gem = new Item(new string[] { "gem" }, "a gem", "a bright red gem");
        _bag = new Bag(new string[] { "bag" }, "a bag", "a green bag");
    }

    [Test]
    public void LookAtMe()
    {
        string result = _look.Execute(_player, new string[] { "look", "at", "inventory" });
        Assert.Equal("You are Giang the inventory. You are carrying:/n", result);
    }

    [Test]
    public void LookAtGem()
    {
        _player.Inventory.Put(_gem);
        string result = _look.Execute(_player, new string[] {"look", "at", "gem"});
        Assert.Equal("a bright red gem", result);
    }

    [Test]
    public void LookAtUnknown()
    {
        string result = _look.Execute(_player, new string[] {"look", "at", "gem"});
        Assert.Equal("I can't find the gem", result);
    }

    [Test]
    public void LookAtGemInMe()
    {
        _player.Inventory.Put(_gem);
        string result = _look.Execute(_player, new string[] {"look", "at", "gem", "in", "inventory"});
        Assert.Equal("a bright red gem", result);
    }

    [Test]
    public void LookAtGemInBag()
    {
        _bag,Inventory.Put(_gem);
        _player.Inventory.Put(_bag);
        string result = _look.Execute(_player, new string[] {"look", "at", "gem", "in", "bag"});
        Assert.Equal("a bright red gem", result);
    }

    [Test]
    public void LookAtGemInNoBag()
    {
        string result = _look.Execute(_player, new string[] {"look", "at", "gem", "in", "bag"});
        Assert.Equal("I can't find the bag", result);
    }

    [Test]
    public void LookAtNoGemInBag()
    {
        _player.Inventory.Put(_bag);
        string result = _look.Execute(_player, new string[] {"look", "at", "gem", "in", "bag"});
        Assert.Equal("I can't find the gem", result);
    }

    [Test]
    public void InvalidLook()
    {
        string result = _look.Execute(_player, new string[] {"look", "around"});
        Assert.Equal("I don't know how to look like that", result);

        result = _look.Execute(_player, new string[] {"hello", "104828510"});
        Assert.Equal("I don't know how to look like that", result);

        result = _look.Execute(_player, new string[] {"look", "at", "Giang"});
        Assert.Equal("I can't find the Giang", result);
    }
}
