using Microsoft.Xna.Framework;

namespace MonoZelda.Enemies.ZolFolder
{
    public class ZolStateMachine
    {
        public enum Direction { Left, Right, Up, Down, None }

        private Direction zolDirection;

        public void ChangeDirection(Direction newDirection)
        {
            zolDirection = newDirection;
        }

        public Point Update(Point position, GraphicsDeviceManager graphics)
        {
            switch (zolDirection)
            {
                case Direction.Left:
                    if (position.X >= 0 + 32)
                    {
                        position.X -= 1;
                    }
                    break;
                case Direction.Right:
                    if (position.X <= graphics.PreferredBackBufferWidth - 32)
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
