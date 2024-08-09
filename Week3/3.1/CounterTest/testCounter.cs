using ClockClass;

namespace CounterTest;

public class CounterTest
{
    private Counter _counter;

    [SetUp]
    public void Setup()
    {
        _counter = new Counter(10);
    }

    [Test]
    public void InitialValue()
    {
        Assert.AreEqual(0, _counter.Tick());
    }

    [Test]
    public void IncrementValue()
    {
        _counter.Increment();
        Assert.AreEqual(1, _counter.Tick());
    }

    [Test]
    public void IncrementMultipleTimes()
    {
        _counter.Increment();
        _counter.Increment();
        _counter.Increment();
        Assert.AreEqual(3, _counter.Tick());
    }

    [Test]
    public void RolloverReset() {
        for (int i = 0; i < 10; i++)
        {
            _counter.Increment();
        }
        Assert.AreEqual(0, _counter.Tick());
    }
}