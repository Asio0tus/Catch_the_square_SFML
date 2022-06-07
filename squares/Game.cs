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
        private int bestResult;
        public static bool IsLost;

        private SquaresList squares;
        private Font font;
        private Text scoreText;
        private Text loseText;

        public Game()
        {
            squares = new SquaresList();
            font = new Font("comic.ttf");

            scoreText = new Text();
            scoreText.Font = font;
            scoreText.FillColor = Color.Black;
            scoreText.CharacterSize = 16;
            scoreText.Position = new Vector2f(10, 10);

            loseText = new Text();
            loseText.Font = font;
            loseText.FillColor = Color.Black;
            loseText.CharacterSize = 25;
            loseText.Position = new Vector2f(200, 250);
            loseText.DisplayedString = "                Ты проиграл :(" + "\nНажми R чтобы перезапустить игру!";


            Reset();
        }

        private void Reset()
        {
            squares.Reset();
            score = 0;
            IsLost = false;

            squares.SpawnPlayerSquare();
            squares.SpawnPlayerSquare();
            squares.SpawnPlayerSquare();

            squares.SpawnEnemySquare();
            squares.SpawnEnemySquare();
        }

        public void Update(RenderWindow window)
        {
            if (IsLost == false)
            {
                squares.Update(window);

                if (squares.squareHasRemoved == true)
                {
                    if (squares.RemovedSquare is PlayerSquare) squares.SpawnPlayerSquare();
                    if (squares.RemovedSquare is EnemySquare) squares.SpawnEnemySquare();

                }
            }

            if(IsLost == true)
            {
                window.Draw(loseText);

                if (bestResult < score) bestResult = score;
                
                if (Keyboard.IsKeyPressed(Keyboard.Key.R) == true)
                {
                    Reset();
                }
            }

            scoreText.DisplayedString = "Score: " + score.ToString() + "\nBest Result: " + bestResult.ToString();
            window.Draw(scoreText);
        }

    }
}
