using System;
namespace ShapeDrawing
{
	public class MyRectangle : Shape
	{

        private int _width, _height;
        private Color _color;
        private float _x, _y;

        public MyRectangle(int width, int height, Color color, float x, float y)
        {
            _width = width;
            _height = height;
            _color = color;
            _x = x;
            _y = y;
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
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

