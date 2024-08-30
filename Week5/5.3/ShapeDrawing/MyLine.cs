using System;
using MyGame;
using ShapeDrawing;
using SplashKitSDK;

namespace ShapeDrawing
{
    public class MyLine : Shape
    {

        private float _endX, _endY;

        public MyLine() : this(Color.Red, 0, 0, 0, 0)
        {
        }

        public MyLine(Color color, float startX, float startY, float endX, float endY) : base(color)
        {
            startX = X;
            startY = Y;
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
            int value = 5;
            SplashKit.FillCircle(Color.Black, X, Y, value);
            SplashKit.FillCircle(Color.Black, _endX, _endY, value);
        }

        public override bool IsAt(Point2D pt)
        {
            Line line = SplashKit.LineFrom(X, Y, _endX, _endY);
            return SplashKit.PointOnLine(pt, line);
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(_endX);
            writer.WriteLine(_endY);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            EndX = reader.ReadInteger();
            EndY = reader.ReadInteger();
        }
    }
}