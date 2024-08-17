using System;
using SplashKitSDK;

namespace ShapeDrawing
{
    public class MyLine : Shape
    {

        private float _endX, _endY;

        public MyLine() : this(Color.Red, 300, 300)
        {
        }

        public MyLine(Color color, float endX, float endY) : base(color)
        {
            _endX = endX;
            _endY = endY;
            _color = color;
        }

        public float EndX
        {
            get { return _endX; }
            set { _endX = value; }
        }

        public float EndY
        {
            get { return _endY; }
            set { _endY = value; }
        }

        public override void Draw()
        {
            if (_selected)
            {
                DrawOutline();
            }

            SplashKit.DrawLine(_color, X, Y, _endX, _endY);
        }

        public override void DrawOutline()
        {
            int value = 2;
            SplashKit.FillCircle(Color.Black, X, Y, value);
            SplashKit.FillCircle(Color.Black, _endX, _endY, value);
        }

        public override bool IsAt(Point2D pt)
        {
            Line line = SplashKit.LineFrom(X, Y, _endX, _endY);
            return SplashKit.PointOnLine(pt, line);
        }
    }
}
