using NUnit.Framework;
using System;
using System.Collections.Generic;
using SwinAdventure;

namespace InventoryTests;

public class InventoryTest
{

    private Inventory _inventory;
    private Item _item;

    [SetUp]
    public void Setup()
    {
        _inventory = new Inventory();
        _item = new Item(new string[] { "id1", "id2" }, "name", "desc");
    }

    [Test]
    public void FindItem()
    {
        _inventory.Put(_item);
        Assert.IsTrue(_inventory.HasItem("id1"));
        Assert.IsTrue(_inventory.HasItem("id2"));   
    }

    [Test]
    public void NoItemFound()
    {
        Assert.IsFalse(_inventory.HasItem("id1"));
        Assert.IsFalse(_inventory.HasItem("id2"));
    }

    [Test]
    public void FetchItem()
    {
        _inventory.Put(_item);
        Assert.AreEqual(_item, _inventory.Fetch("id1"));
        Assert.AreEqual(_item, _inventory.Fetch("id2"));
        Assert.AreEqual(null, _inventory.Fetch("id3"));
    }

    [Test]
    public void TakeItem()
    {
        _inventory.Put(_item);
        Assert.AreEqual(_item, _inventory.Take("id1"));
        Assert.AreEqual(null, _inventory.Fetch("id1"));
    }

    [Test]
    public void ItemList()
    {
        _inventory.Put(_item);
        Assert.AreEqual("name (id1) - name (id2)", _inventory.ItemList);
    }
}
