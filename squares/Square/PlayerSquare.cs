using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace squares
{
    public class PlayerSquare : Square
    {
        private static Color color = new Color(50, 50, 50);        
        private static float MinSize = 30;
        private static float sizeStep = 10;

        public PlayerSquare(Vector2f position, float movementSpeed, IntRect movementBounds) : base(position, movementSpeed, movementBounds) 
        {
            shape.FillColor = color;
        }

        protected override void OnClick()
        {
            Game.score++;

            shape.Size -= new Vector2f(sizeStep, sizeStep);

            if(shape.Size.X < MinSize)
            {
                IsActive = false;
                return;
            }

            UpdateMovementTarget();
            shape.Position = movementTarget;
        }

    }
}
