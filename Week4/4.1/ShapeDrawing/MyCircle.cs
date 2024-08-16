using System;
namespace ShapeDrawing
{
	public class MyCircle : Shape
	{

        private int _radius;

        public MyCircle(int radius, Color color, float x, float y)
        {
            _radius = radius;
            _color = color;
            _x = x;
            _y = y;
        }

        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public void Draw()
        {
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }

        public void DrawOutline()
        {
            int value = 5;
            SplashKit.FillRectangle(Color.Black, _x - value, _y - value,
                                    _width + value * 2, _height + value * 2);
        }

        public bool IsAt(Point2D pt)
        {
            return (pt.X >= _x && pt.X <= _x + _width)
                && (pt.Y >= _y && pt.Y <= _y + _height);
        }
	}
}

