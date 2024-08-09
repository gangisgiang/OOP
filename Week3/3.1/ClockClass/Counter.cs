using System;
namespace ClockClass
{
	public class Counter
	{
        private int _count;
        private int _rollover;

        public Counter(int rollover)
        {
            _rollover = rollover;
            _count = 0;
        }

        public void Increment()
        {
            _count++;
            if (_count >= _rollover)
            {
                _count = 0;
            }
        }

        public void Reset()
        {
            _count = 0;
        }

        public void Set(int value)
        {
            if (value >= 0 && value < _rollover)
            {
                _count = value;
            }
        }

        public int Tick()
        {
            return _count;
        }
    }
}