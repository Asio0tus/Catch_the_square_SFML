using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace squares
{
    public class Square
    {
        public bool IsActive = true;

        protected RectangleShape shape;
        protected float movementSpeed;
        protected Vector2f movementTarget;
        protected IntRect movementBounds;

        public static Vector2f defaultSize = new Vector2f(100, 100);


        public Square(Vector2f position, float movementSpeed, IntRect movementBounds)
        {
            shape = new RectangleShape(defaultSize);
            shape.Position = position;

            this.movementSpeed = movementSpeed;
            this.movementBounds = movementBounds;

            UpdateMovementTarget();
        }

        public void Move()
        {
            shape.Position = Mathf.MoveTowards(shape.Position, movementTarget, movementSpeed);
            
            if(shape.Position == movementTarget)
            {                
                OnReachedTarget();
                UpdateMovementTarget();
            }
        }

        public void CheckMousePosition(Vector2i mousePos)
        {
            if (IsActive == false) return;

            if (mousePos.X > shape.Position.X && mousePos.X < shape.Position.X + shape.Size.X && 
                mousePos.Y > shape.Position.Y && mousePos.Y < shape.Position.Y + shape.Size.Y) OnClick();
        }

        public void Draw(RenderWindow window)
        {
            if (IsActive == false) return;

            window.Draw(shape);
        }

        protected void UpdateMovementTarget()
        {
            
            movementTarget.X = Mathf.Random.Next(movementBounds.Left, movementBounds.Left + movementBounds.Width);
            movementTarget.Y = Mathf.Random.Next(movementBounds.Top, movementBounds.Top + movementBounds.Height);
        }

        protected virtual void OnClick() { }
        protected virtual void OnReachedTarget() { }
    }
}
