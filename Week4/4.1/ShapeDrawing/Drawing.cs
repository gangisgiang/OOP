using SplashKitSDK;

namespace ShapeDrawing
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        public Color Background 
        {
        }

        public Drawing(Color background) 
        {
            _background = background;
            _shapes = new List<Shape>();
        }

        public Drawing() : this(Color.White) 
        {
            
        }

        public List<Shape> SelectedShapes 
        {
            get 
            {
                List<Shape> result = new List<Shape>();
                foreach (Shape s in _shapes) 
                {
                    if (s.Selected) 
                    {
                        result.Add(s);
                    }
                }
                return result;
            }
        }

        public int ShapeCount 
        {
            get { return _shapes.Count; }
        }

        public void Draw() 
        {
            SplashKit.ClearScreen(_background);
            foreach (Shape s in _shapes) 
            {
                s.Draw();
            }
        }

        public void SelectShapesAt (Point2D pt) 
        {
            foreach (Shape s in _shapes)
            {
                if (s.IsAt(pt)) 
                {
                    s.Selected = true;
                }
                else 
                {
                    s.Selected = false;
                }
            }
        }

        public void AddShape(Shape s) 
        {
            _shapes.Add(s);
        }

        public void RemoveShape(Shape s) 
        {
            _shapes.Remove(s);
        }
    }
}