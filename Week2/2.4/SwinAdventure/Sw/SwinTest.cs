using System.Data.Common;
using System.Xml.Serialization;
using SwinAdventure;

namespace SwinTest;

public class IdentifiableObjectTest

{
    private IdentifiableObject _identifs;

    [SetUp]
    public void Setup()
    {
        _identifs = new IdentifiableObject(new string[] { "104828510", "Uyen Giang", "Thai" });
    }

    [Test]
    public void TestAreYou()
    {
        Assert.IsTrue(_identifs.AreYou("104828510"));
        Assert.IsTrue(_identifs.AreYou("Uyen Giang"));
    }

    [Test]
    public void TestNotAreYou()
    {
        Assert.IsFalse(_identifs.AreYou("1O482851O"));
    }

    [Test]
    public void TestCaseSensitive()
    {
        Assert.IsTrue(_identifs.AreYou("UYeN GiANG"));
        Assert.IsTrue(_identifs.AreYou("thAi"));
    }

    [Test]
    public void TestFirstId()
    {
        Assert.AreEqual("104828510", _identifs.FirstId);
    }

    [Test]
    public void TestFirstIdNoIDs()
    {
        IdentifiableObject _id0ids = new IdentifiableObject(new string[] { });
        Assert.AreEqual("", _id0ids.FirstId);
    }

    [Test]
    public void TestAddID()
    {
        _identifs.AddIdentifier("Wren");
        Assert.IsTrue(_identifs.AreYou("Wren"));
    }

    [Test]
    public void TestPrivilegeEscalation()
    {
        IdentifiableObject _idpries = new IdentifiableObject(new string[] { "007", "James" });
        _idpries.PrivilegeEscalation("8510");
        Assert.AreEqual("104828510", _idpries.FirstId);
    }
}