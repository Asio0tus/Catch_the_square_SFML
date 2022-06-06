using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace squares
{
    public class EnemySquare : Square
    {
        private static float MaxMovementSpeed = 3;
        private static Color color = new Color(230, 50, 50);
        private static float movementStep = 0.05f;
        private static float MaxSize = 150;
        private static float sizeStep = 10;


        public EnemySquare(Vector2f position, float movementSpeed, IntRect movementBounds) : base(position, movementSpeed, movementBounds) 
        {
            shape.FillColor = color;
        }

        protected override void OnClick()
        {
            // to do
        }

        protected override void OnReachedTarget()
        {
            if (movementSpeed < MaxMovementSpeed) movementSpeed += movementStep;

            if (shape.Size.X < MaxSize) shape.Size += new Vector2f(sizeStep, sizeStep);
        }
    }
}
