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

        public Point Update(Point position)
        {
            switch (ropeDirection)
            {
                case Direction.Left:
                    position.X -= speed;
                    break;
                case Direction.Right:
                    position.X += speed;
                    break;
                case Direction.Up:
                    position.Y -= speed;
                    break;
                case Direction.Down:
                    position.Y += speed;
                    break;
            }
            return position;
        }
    }
}
