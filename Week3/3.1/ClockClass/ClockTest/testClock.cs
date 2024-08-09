using ClockClass;

namespace ClockTest;

public class ClockTest
{
    private Clock _clock;
    [SetUp]
    public void Setup()
    {
        _clock = new Clock();
    }

    [Test]
    public void TickTest()
    {
        _clock.Set(0, 0, 0);
        _clock.Tick();
        Assert.AreEqual("00:00:01", _clock.Display());
    }

    [Test]
    public void ResetTest()
    {
        _clock.Set(0, 0, 0);
        _clock.Tick();
        _clock.Reset();
        Assert.AreEqual("00:00:00", _clock.Display());
    }

    [Test]
    public void SetTest()
    {
        _clock.Set(1, 2, 3);
        Assert.AreEqual("01:02:03", _clock.Display());
    }

    [Test]
    public void RolloverTest()
    {
        _clock.Set(11, 59, 59);
        _clock.Tick();
        Assert.AreEqual("00:00:00", _clock.Display());
    }
}
