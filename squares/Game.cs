using System;
using System.Collections.Generic;
using System.Diagnostics;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace squares
{
    public class Game
    {
        public static int score;

        private SquaresList squares;

        public Game()
        {
            squares = new SquaresList();

            squares.SpawnPlayerSquare();
            

            squares.SpawnEnemySquare();
            

        }

        public void Update(RenderWindow window)
        {
            squares.Update(window);


            if (squares[i].IsActive == false)
            {
                squares.Remove(squares[i]);
                SpawnPlayerSquare();
            }

        }

    }
}
