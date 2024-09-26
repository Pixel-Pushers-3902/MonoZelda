using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoZelda.Enemies.RopeFolder
{
    public class RopeStateMachine
    {
        public enum Direction { Left, Right, Up, Down }

        private Direction ropeDirection;
        private int speed = 1;

        public void ChangeDirection(Direction newDirection)
        {
            ropeDirection = newDirection;
        }

        public Point Update(Point position, GraphicsDeviceManager graphics)
        {
            if (position.X <= 0 + 32)
            {
                position.X = 33;
            }
            if (position.X >= graphics.PreferredBackBufferWidth - 32)
            {
                position.X = graphics.PreferredBackBufferWidth - 33;
            }
            if (position.Y <= 0 + 32)
            {
                position.Y = 33;
            }
            if (position.Y >= graphics.PreferredBackBufferHeight - 32)
            {
                position.Y = graphics.PreferredBackBufferHeight - 33;
            }
            switch (ropeDirection)
            {
                case Direction.Left:
                    position.X -= 1;
                    break;
                case Direction.Right:
                    position.X += 1;
                    break;
                case Direction.Up:
                    position.Y -= 1;
                    break;
                case Direction.Down:
                    position.Y += 1;
                    break;
            }
            return position;
        }
    }
}
