using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace squares
{
    public class SquaresList
    {
        private List<Square> squares;
        public bool squareHasRemoved;

        public SquaresList()
        {
            squares = new List<Square>();
        }

        public void Update(RenderWindow window)
        {
            if(Mouse.IsButtonPressed(Mouse.Button.Left) == true)
            {
                for(int i = 0; i < squares.Count; i++)
                {
                    squares[i].CheckMousePosition(Mouse.GetPosition(window));
                }
            }

            for (int i = 0; i < squares.Count; i++)
            {
                squares[i].Move();
                squares[i].Draw(window);                
            }
        }

        public void SpawnPlayerSquare()
        {
            squares.Add(new PlayerSquare(new Vector2f(Mathf.Random.Next(0,800), Mathf.Random.Next(0, 600)), 5, new IntRect(0, 0, 800, 600)));
        }

        public void SpawnEnemySquare()
        {
            squares.Add(new EnemySquare(new Vector2f(Mathf.Random.Next(0, 800), Mathf.Random.Next(0, 600)), 5, new IntRect(0, 0, 800, 600)));
        }
    }
}
