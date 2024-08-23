using NUnit.Framework;
using System;
using System.Collections.Generic;
using SwinAdventure;

namespace ItemTests;

public class ItemTest
{
    private Item _item;
    [SetUp]
    public void Setup()
    {
        _item = new Item(new string[] { "id1", "id2" }, "name", "desc");
    }

    [Test]
    public void IdentifiableItem()
    {
        Assert.IsTrue(_item.AreYou("id1"));
        Assert.IsTrue(_item.AreYou("id2"));
        Assert.IsFalse(_item.AreYou("name"));
        Assert.IsFalse(_item.AreYou("desc"));
        Assert.IsFalse(_item.AreYou("id3"));
    }

    [Test]
    public void ShortDescription()
    {
        Assert.AreEqual("desc", _item.ShortDescription);
    }

    [Test]
    public void FullDescription()
    {
        Assert.AreEqual("This is a desc.", _item.FullDescription);
    }

    [Test]
    public void PrivilegeEscalation()
    {
        _item.PrivilegeEscalation("8510");
        Assert.IsTrue(_item.AreYou("104828510"));
    }
}
