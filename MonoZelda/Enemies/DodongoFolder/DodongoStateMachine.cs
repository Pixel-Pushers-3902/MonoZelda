using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoZelda.Enemies.DodongoFolder
{
    public class DodongoStateMachine
    {
        public enum Direction { Left, Right, Up, Down }

        private Direction dodongoDirection;

        public void ChangeDirection(Direction newDirection)
        {
            dodongoDirection = newDirection;
        }

        public Point Update(Point position, GraphicsDeviceManager graphics)
        {
            switch (dodongoDirection)
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
