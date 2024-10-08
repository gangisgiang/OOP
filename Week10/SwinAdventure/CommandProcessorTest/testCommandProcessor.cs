using NUnit.Framework;
using System;
using SwinAdventure;

namespace CommandProcessorTest;

public class Tests
{
    private CommandProcessor _cmdProcessor;
    private Player _player;
    private Location _location;
    private LookCommand _look;
    private MoveCommand _move;

    [SetUp]
    public void Setup()
    {
        _cmdProcessor = new CommandProcessor();
        _player = new Player("player", "description", _location);
        _location = new Location(new string[] { "bedroom" }, "bedroom", "pinky bedroom");
        _player.Location = _location;

        _look = new LookCommand();
        _move = new MoveCommand();

        _cmdProcessor.AddCommand(_look);
        _cmdProcessor.AddCommand(_move);
    }

    [Test]
    public void TestLookCommand()
    {
        string result = _cmdProcessor.ExecuteCommand(_player, "look");
        Assert.AreEqual("You are in the bedroom. You can see: pinky bedroom", result);
    }

    [Test]
    public void TestMoveCommand()
    {
        string result = _cmdProcessor.ExecuteCommand(_player, "move north");
        // You are at " + Name + ". " + ShortDescription + ".\n
        Assert.AreEqual("You are at bedroom. pinky bedroom.\n", result);
    }
}