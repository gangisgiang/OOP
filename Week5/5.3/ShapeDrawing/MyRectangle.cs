using System;
using ShapeDrawing;
using SplashKitSDK;

namespace ShapeDrawing
{
    public class MyRectangle : Shape
    {
        private int _width, _height;

        public MyRectangle() : this(110, 110, Color.Green, 0.0f, 0.0f)
        {
        }

        public MyRectangle(int width, int height, Color color, float x, float y) : base(color)
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

        public override void Draw()
        {
            if (_selected)
            {
                DrawOutline();
            }

            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }

        public override void DrawOutline()
        {
            int value = 2;
            SplashKit.FillRectangle(Color.Black, _x - value, _y - value,
                                    _width + value * 2, _height + value * 2);
        }

        public override bool IsAt(Point2D pt)
        {
            return (pt.X >= _x && pt.X <= _x + _width)
                && (pt.Y >= _y && pt.Y <= _y + _height);
        }
    }
}

