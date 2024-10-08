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
    public void TestInvalidPathMoveCommand()
    {
        string result = _cmdProcessor.ExecuteCommand(_player, "move north");
        Assert.AreEqual("You can't move in that direction.", result);
    }

    [Test]
    public void TestValidPathMoveCommand()
    {
        Location destination = new Location(new string[] { "Hanoi" }, "Hanoi", "old Hanoi");
        SwinAdventure.Path path = new SwinAdventure.Path(new string[] { "north" }, "to the north", destination);
        _location.AddPath(path);

        string result = _cmdProcessor.ExecuteCommand(_player, "move north");
        Assert.AreEqual("You head north\nto the north\nYou have arrived at Hanoi", result);
    }

    [Test]
    public void TestInvalidMoveCommand()
    {
        string result = _cmdProcessor.ExecuteCommand(_player, "move to north");
        Assert.AreEqual("I don't understand what you mean by 'move to ...'. Please specify just the direction.", result);
    }

    [Test]
    public void TestValidLookCommand()
    {
        string result = _cmdProcessor.ExecuteCommand(_player, "look at bedroom");
        Assert.AreEqual("You are at bedroom. pinky bedroom.\n", result);
    }

    [Test]
    public void TestInvalidLookCommand()
    {
        string result = _cmdProcessor.ExecuteCommand(_player, "look at");
        Assert.AreEqual("What do you want to look at?", result);
    }

    [Test]
    public void TestInvalidCommand()
    {
        string result = _cmdProcessor.ExecuteCommand(_player, "command");
        Assert.AreEqual("I don't know how to command like that.", result);
    }
}