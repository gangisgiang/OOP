using System;
using SplashKitSDK;

namespace ShapeDrawing
{
    public class MyCircle : Shape
    {

        private int _radius;

        public MyCircle() : this(61, Color.Blue)
        {
        }

        public MyCircle(int radius, Color color) : base(color)
        {
            _radius = radius;
            _color = color;
        }

        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public override void Draw()
        {
            if (_selected)
            {
                DrawOutline();
            }

            SplashKit.FillCircle(Color, _x, _y, _radius);
        }

        public override void DrawOutline()
        {
            int value = 2;
            SplashKit.FillCircle(Color.Black, _x, _y, _radius + value);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInCircle(pt.X, pt.Y, _x, _y, _radius);
        }
    }
}
    