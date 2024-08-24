﻿using SplashKitSDK;

namespace ShapeDrawing
{
    public abstract class Shape
    {
        public Color _color;
        public float _x, _y;
        public bool _selected;

        public Shape() : this(Color.Yellow)
        {
        }

        public Shape(Color color)
        {
            _color = color;
            _x = 0.0f;
            _y = 0.0f;
        }

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public abstract void Draw();

        public abstract void DrawOutline();

        public abstract bool IsAt(Point2D pt);

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteColor(_color);
            writer.WriteLine(_x);
            writer.WriteLine(_y);
            writer.WriteLine(_selected);
        }
    }
}

