using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);
            Drawing myDrawing = new Drawing();
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    
                }

                

                SplashKit.RefreshScreen();
            }

            while (!window.CloseRequested);

            
        }
    }
}
