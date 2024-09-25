using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MonoZelda.Enemies.TrapFolder
{
    public class TrapStateMachine
    {
        public enum Direction { Left, Right, Up, Down, None}

        private Direction trapDirection;
        private int speed;

        public void ChangeDirection(Direction newDirection)
        {
            trapDirection = newDirection;
        }

        public void ChangeSpeed(int newSpeed)
        {
            speed = newSpeed;
        }

        public Point Update(Point position, GraphicsDeviceManager graphics)
        {
            switch (trapDirection)
            {
                case Direction.Left:
                    if (position.X >= 0 + 32)
                    {
                        position.X -= speed;
                    }
                    break;
                case Direction.Right:
                    if (position.X <= graphics.PreferredBackBufferWidth - 32)
                    {
                        position.X += speed;
                    }
                    break;
                case Direction.Up:
                    if (position.Y >= 0 + 32)
                    {
                        position.Y -= speed;
                    }
                    break;
                case Direction.Down:
                    if (position.Y <= graphics.PreferredBackBufferHeight - 32)
                    {
                        position.Y += speed;
                    }
                    break;
            }
            return position;
        }
    }
}
