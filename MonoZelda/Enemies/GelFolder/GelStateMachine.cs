using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoZelda.Enemies.GelFolder
{
    public class GelStateMachine
    {
        public enum Direction { Left, Right, Up, Down, None}

        private Direction gelDirection;

        public void ChangeDirection(Direction newDirection)
        {
            gelDirection = newDirection;
        }

        public Point Update(Point position, GraphicsDeviceManager graphics)
        {
            switch (gelDirection)
            {
                case Direction.Left:
                    if (position.X >= 0 + 16)
                    {
                        position.X -= 1;
                    }
                    break;
                case Direction.Right:
                    if (position.X <= graphics.PreferredBackBufferWidth - 16)
                    {
                        position.X += 1;
                    }
                    break;
                case Direction.Up:
                    if (position.Y >= 0 + 18)
                    {
                        position.Y -= 1;
                    }
                    break;
                case Direction.Down:
                    if (position.Y <= graphics.PreferredBackBufferHeight - 18)
                    {
                        position.Y += 1;
                    }
                    break;
            }
            return position;
        }
    }
}
