using SplashKitSDK;

namespace ShapeDrawer 
{
    public class Drawing 
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        public Color Background 
        {
            get { return _background; }
            set { _background = value; }
        }

        public Drawing(Color background) 
        {
            _background = background;
            _shapes = new List<Shape>();
        }

        public Drawing() : this(Color.White) 
        {
            
        }

        public SelectedShape 
        {
            get 
            {
                foreach (Shape s in _shapes) 
                {
                    if (s.Selected) 
                    {
                        return s;
                    }
                }
                return null;
            }
        }

        public int ShapeCount 
        {
            get { return _shapes.Count; }
        }

        public void AddShape(Shape s) 
        {
            _shapes.Add(s);
        }

        public void Draw() 
        {
            SplashKit.ClearScreen(_background);
            foreach (Shape s in _shapes) 
            {
                s.Draw();
            }
        }

        public void RemoveShape(Shape s) 
        {
            _shapes.Remove(s);
        }
    }
}