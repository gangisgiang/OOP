using SplashKitSDK;

namespace ShapeDrawing
{
	public class Shape
	{
		private Color _color;
		private float _x, _y;
		private int _width, _height;
        private bool _selected;

		public Shape()
		{
			_color = Color.Chocolate;
			_x = 0.0f;
			_y = 0.0f;
			_width = 110;
			_height = 110;
		}

		public Shape(Color color)
		{
			_color = color;
			_x = 0.0f;
			_y = 0.0f;
			_width = 110;
			_height = 110;
		}

        	public bool Selected 
		{
            		get { return _selected; }
            		set { _selected = value; }
        	}

		public void Draw()
		{
			if (_selected)
			{
				DrawOutline();
			}
			SplashKit.FillRectangle(_color, _x, _y, _width, _height);
		}

		public bool IsAt(Point2D pt)
		{
			return (pt.X >= _x && pt.X <= _x + _width) && (pt.Y >= _y && pt.Y <= _y + _height);
		}

		public Color Color {
			get { return _color; }
			set { _color = value; }
		}

		public float X {
			get { return _x; }
			set { _x = value; }
		}

		public float Y {
			get { return _y; }
			set { _y = value; }
		}

		public int Width {
			get { return _width; }
			set { _width = value; }
		}

		public int Height {
			get { return _height; }
			set { _height = value; }
		}

	        public void DrawOutline()
	        {
			int value = 5;
			SplashKit.FillRectangle(Color.Black, _x - value, _y - value, _width + value * 2, _height + value * 2);
	        }
	}
}

