using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PixelPushers.MonoZelda;
using PixelPushers.MonoZelda.Sprites;

namespace MonoZelda.Enemies.EnemyStateMachines
{
    public class KeeseStateMachine
    {
        public enum VertDirection { Up, Down, None }
        public enum HorDirection { Left, Right, None }
        public VertDirection CurrentVert { get; private set; } = VertDirection.None;
        public HorDirection CurrentHor { get; private set; } = HorDirection.None;
        public bool IsAttacking { get; private set; } = true;


        public KeeseStateMachine()
        {
        }

        public void ChangeVertDirection(VertDirection newVert)
        {
            CurrentVert = newVert;
        }

        public void ChangeHorDirection(HorDirection newHor)
        {
            CurrentHor = newHor;
        }

        public static void Attack() //not used
        {
        }

        public Point Update(Point position)
        {
            if (CurrentVert == VertDirection.None)
            {
                if (CurrentHor == HorDirection.Right)
                {
                    position.X += 1;
                }
                else if (CurrentHor == HorDirection.Left)
                {
                    position.X -= 1;
                }
            }
            else if (CurrentVert == VertDirection.Up)
            {
                if (CurrentHor == HorDirection.Right)
                {
                    position.Y -= 1;
                    position.X += 1;
                }
                else if (CurrentHor == HorDirection.Left)
                {
                    position.Y -= 1;
                    position.X -= 1;
                }
                else
                {
                    position.Y -= 1;
                }
            }
            else
            {
                if (CurrentHor == HorDirection.Right)
                {
                    position.Y += 1;
                    position.X += 1;
                }
                else if (CurrentHor == HorDirection.Left)
                {
                    position.Y += 1;
                    position.X -= 1;
                }
                else
                {
                    position.Y += 1;
                }
            }

            return position;

        }
    }
}
