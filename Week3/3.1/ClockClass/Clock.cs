using System;
namespace ClockClass
{
	public class Clock
	{
		private Counter _hour;
		private Counter _minute;
		private Counter _second;

		public Clock()
		{
			_hour = new Counter(12);
			_minute = new Counter(60);
			_second = new Counter(60);
		}

		public void Tick()
		{
			_second.Increment();
			if (_second.Tick() == 0)
			{
				_minute.Increment();
				if (_minute.Tick() == 0)
				{
					_hour.Increment();
				}
			}
		}

		public void Reset()
		{
			_hour.Reset();
			_minute.Reset();
			_second.Reset();
		}

		public void Set(int hour, int minute, int second)
		{
			_hour.Set(hour);
			_minute.Set(minute);
			_second.Set(second);
		}

		public string Display()
		{
			string hour = _hour.Tick().ToString("D2");   // Ensures two digits
			string minute = _minute.Tick().ToString("D2");
			string second = _second.Tick().ToString("D2");

			return $"{hour}:{minute}:{second}";
		}
	}
}

