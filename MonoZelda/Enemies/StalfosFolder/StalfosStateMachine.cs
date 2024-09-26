using Microsoft.Xna.Framework;

namespace MonoZelda.Enemies.StalfosFolder
{
    public class StalfosStateMachine
    {
        public enum Direction { Left, Right, Up, Down }

        private Direction stalfosDirection;

        public void ChangeDirection(Direction newDirection)
        {
            stalfosDirection = newDirection;
        }

        public Point Update(Point position, GraphicsDeviceManager graphics)
        {
            switch (stalfosDirection)
            {
                case Direction.Left:
                    if (position.X >= 0 + 64)
                    {
                        position.X -= 1;
                    }
                    break;
                case Direction.Right:
                    if (position.X <= graphics.PreferredBackBufferWidth - 64)
                    {
                        position.X += 1;
                    }
                    break;
                case Direction.Up:
                    if (position.Y >= 0 + 32)
                    {
                        position.Y -= 1;
                    }
                    break;
                case Direction.Down:
                    if (position.Y <= graphics.PreferredBackBufferHeight - 32)
                    {
                        position.Y += 1;
                    }
                    break;
            }
            return position;
        }
    }
}
