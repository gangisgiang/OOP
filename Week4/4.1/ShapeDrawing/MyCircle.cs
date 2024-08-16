using System;
namespace ShapeDrawing
{
	public class MyCircle : Shape
	{

        private int _radius;

        public MyCircle()
        {
            _radius = 110;
            _color = Color.Chocolate;
            _x = 0.0f;
            _y = 0.0f;
        }

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
            SplashKit.FillCircle(_color, _x, _y, _radius);
        }

        public void DrawOutline()
        {
            int value = 5;
            SplashKit.FillCircle(Color.Black, _x, _y, _radius + value);
        }

        public bool IsAt(Point2D pt)
        {
            return SplashKit.PointInCircle(pt, _x, _y, _radius);
        }
	}
}

