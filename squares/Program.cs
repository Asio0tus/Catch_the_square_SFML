using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace squares
{
    class Program
    {        
        static void Main(string[] args)
        {
            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "Squares");
            window.Closed += Window_Closed;
            window.SetFramerateLimit(60);

            Game game = new Game();

            while(window.IsOpen == true)
            {
                window.Clear(new Color(230, 230, 230));

                window.DispatchEvents();

                game.Update(window);

                window.Display();
            }
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            ((RenderWindow)sender).Close();
        }
    }
}
