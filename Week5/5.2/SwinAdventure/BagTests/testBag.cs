namespace BagTests;
using NUnit.Framework;
using SwinAdventure;

public class Tests
{
    private Bag _bag, b1, b2;
    private Item _item;

    [SetUp]
    public void Setup()
    {
        _bag = new Bag(new string[] { "id1", "id2" }, "name", "desc");
        _item = new Item(new string[] { "id1", "id2" }, "name", "desc");
        b1 = new Bag(new string[] { "id1", "id2"}, "name", "desc");
        b2 = new Bag(new string[] { "uyen", "giang"}, "name", "desc");
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

    [Test]
    public void BaginBag()
    {
        b1.Inventory.Put(b2);
        Assert.AreEqual(b2, b1.Locate("id1"));
        Assert.AreEqual(b2, b1.Locate("id2"));
        Assert.IsNull(b1.Locate("uyen"));
        Assert.IsNull(b1.Locate("giang"));
    }

    [Test]
    public void PrivilegeItem()
    {
        b1.Inventory.Put(b2);
        b2.PrivilegeEscalation("8510");
        Assert.AreEqual(b2, b1.Locate("104828510"));
    }
}