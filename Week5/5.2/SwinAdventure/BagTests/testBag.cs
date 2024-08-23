namespace BagTests;
using NUnit.Framework;
using SwinAdventure;

public class Tests
{
    private Bag _bag;
    private Item _item;

    [SetUp]
    public void Setup()
    {
        _bag = new Bag(new string[] { "id1", "id2" }, "name", "desc");
        _item = new Item(new string[] { "id1", "id2" }, "name", "desc");
    }

    [Test]
    public void LocatesItems()
    {
        _bag.Inventory.Put(_item);
        Assert.AreEqual(_item, _bag.Locate("id1"));
        Assert.AreEqual(_item, _bag.Locate("id2"));
    }

    [Test]
    public void LocatesItself()
    {
        Assert.AreEqual(_bag, _bag.Locate("id1"));
        Assert.AreEqual(_bag, _bag.Locate("id2"));
    }

    [Test]
    public void LocatesNothing()
    {
        Assert.IsNull(_bag.Locate("Giang"));
    }

    [Test]
    public void FullDescription()
    {
        _bag.Inventory.Put(_item);
        Assert.AreEqual("In the name you can see:\n\ta name (id1)\n\tdesc\n", _bag.FullDescription);
    }
}
