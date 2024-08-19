using System;
using SplashKitSDK;

namespace ShapeDrawing
{
    public class Program
    {

        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        public static void Main()
        {

            ShapeKind kindToAdd = ShapeKind.Circle;

            Window window = new Window("Shape Drawing", 800, 600);
            Drawing myDrawing = new Drawing();
            int lines = 0;
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }

                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape = null;

                    switch (kindToAdd)
                    {
                        case ShapeKind.Circle:
                            newShape = new MyCircle();
                            break;

                        case ShapeKind.Line:
                            if (lines < 5)
                            {
                                MyLine myLine = new MyLine();
                                myLine.X = SplashKit.MouseX();
                                myLine.Y = SplashKit.MouseY();
                                myLine.EndX = myLine.X + 110;
                                myLine.EndY = myLine.Y;
                                myDrawing.AddShape(myLine);
                                lines++;
                            }
                            break;

                        default:
                            newShape = new MyRectangle();
                            break;
                    }

                    if (newShape != null)
                    {
                        newShape.X = SplashKit.MouseX();
                        newShape.Y = SplashKit.MouseY();
                        myDrawing.AddShape(newShape);
                    }
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    Point2D pt = SplashKit.MousePosition();
                    myDrawing.SelectShapesAt(pt);
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomRGBColor(255);
                }

                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    foreach (Shape s in myDrawing.SelectedShapes)
                    {
                        myDrawing.RemoveShape(s);
                    }
                }

                myDrawing.Draw();
                SplashKit.RefreshScreen();
            }

            while (!window.CloseRequested);

        }
    }
}