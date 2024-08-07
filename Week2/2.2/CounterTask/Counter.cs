namespace CounterTask;

public class Counter
{
    private int _count;
    private string _name;

    public Counter(string name)
    {
        _name = name;
        _count = 0;
    }

    public void Increment()
    {
        _count++;
    }

    public void Reset()
    {
        _count = 0;
    }

    //public void ResetByDefault()
    //{
    //    _count = 2147483647510;
    //}

    //The code could not run as the issue with using 2147483647510 is that the value
    //exceeds the maximum limit for an int type in C#

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }

    public int Ticks
    {
        get
        {
            return _count;
        }
    }
}