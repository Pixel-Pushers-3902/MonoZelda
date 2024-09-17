using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using PixelPushers.MonoZelda.Sprites;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoZelda.Enemies.EnemyStateMachines
{
    public class GoriyaStateMachine
    {
        public enum VertDirection {Up, Down, None}
        public enum HorDirection { Left, Right, None }
        public VertDirection CurrentVert { get; private set; } = VertDirection.None;
        public HorDirection CurrentHor { get; private set; } = HorDirection.Right;
        public bool IsAttacking { get; private set; } = true;

        public GoriyaStateMachine()
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

        public void Attack() //not used
        {
            CurrentVert = VertDirection.None;
            CurrentHor = HorDirection.None;
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
            } else if (CurrentVert == VertDirection.Up)
            {
                position.Y -= 1;
            }
            else
            {
                position.Y += 1;
            }

            return position;

        }

        public void UpdateSprite(SpriteDict goriyaSpriteDict)
        {
            if (CurrentHor == HorDirection.None)
            {
                switch (CurrentVert)
                {
                    case VertDirection.Up:
                        goriyaSpriteDict.SetSprite("walk_up");
                        break;
                    case VertDirection.Down:
                        goriyaSpriteDict.SetSprite("walk_down");
                        break;
                }
            }
            else
            {
                switch (CurrentHor)
                {
                    case HorDirection.Left:
                        goriyaSpriteDict.SetSprite("walk_left");
                        break;
                    case HorDirection.Right:
                        goriyaSpriteDict.SetSprite("walk_right");
                        break;
                }
            }
        }
    }
}
