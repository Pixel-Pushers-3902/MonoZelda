using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MonoZelda.Enemies.EnemyStateMachines;
using PixelPushers.MonoZelda.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoZelda.Enemies
{
    internal class Goriya : IEnemy
    {
        private readonly GoriyaStateMachine stateMachine;
        private int horDelay;
        private int vertDelay;
        private int attackDelay;
        private int attacking = 0;
        private readonly Random rnd = new();
        private Point pos;
        private SpriteDict goriyaSpriteDict;
        private GoriyaStateMachine.VertDirection vertDirection = GoriyaStateMachine.VertDirection.None;
        private GoriyaStateMachine.HorDirection horDirection = GoriyaStateMachine.HorDirection.Right;

        public Goriya(SpriteDict spriteDict)
        {
            this.goriyaSpriteDict = spriteDict;
            stateMachine = new GoriyaStateMachine();
            goriyaSpriteDict.SetSprite("walk_left"); //using link sprites for now

            horDelay = 0;
            vertDelay = 0;
            attackDelay = 0;
            pos = new Point(250, 250);
        }

        public void SetOgPos()
        {
            pos.X = 250;
            pos.Y = 250;
        }

        public void Attack()
        {
            
            if (attacking <= 100)
            {
                horDelay = 0;
                vertDelay = 0;
                attacking++;
            }
            else
            {
                attacking = 0;
                attackDelay = 0;
                horDirection = GoriyaStateMachine.HorDirection.Left;
            }
            
        }

        public void ChangeHorDirection()
        {
            stateMachine.ChangeHorDirection(horDirection);
        }

        public void ChangeVertDirection()
        {
            stateMachine.ChangeVertDirection(vertDirection);
        }

        public void Update()
        {
            if (attackDelay >= 200)
            {
                attackDelay = 0;
                stateMachine.Attack();
                Attack();
            }
            if (horDelay >= rnd.Next(50, 100))
            {
                if (vertDirection == GoriyaStateMachine.VertDirection.None)
                {
                    switch (rnd.Next(1, 4))
                    {
                        case 1:
                            horDirection = GoriyaStateMachine.HorDirection.None;
                            switch (rnd.Next(1, 3))
                            {
                                case 1:
                                    vertDirection = GoriyaStateMachine.VertDirection.Up;
                                    break;
                                case 2:
                                    vertDirection = GoriyaStateMachine.VertDirection.Down;
                                    break;
                            }
                            break;
                        case 2:
                            horDirection = GoriyaStateMachine.HorDirection.Right;
                            break;
                        case 3:
                            horDirection = GoriyaStateMachine.HorDirection.Left;
                            break;
                    }
                    ChangeHorDirection();
                    horDelay = 0;
                }

            }

            if (vertDelay >= rnd.Next(50, 100))
            {
                if (horDirection == GoriyaStateMachine.HorDirection.None)
                {
                    switch (rnd.Next(1, 4))
                    {
                        case 1:
                            vertDirection = GoriyaStateMachine.VertDirection.None;
                            switch (rnd.Next(1,3))
                            {
                                case 1:
                                    horDirection = GoriyaStateMachine.HorDirection.Left;
                                    break;
                                case 2:
                                    horDirection = GoriyaStateMachine.HorDirection.Right;
                                    break;
                            }
                            break;
                        case 2:
                            vertDirection = GoriyaStateMachine.VertDirection.Up;
                            break;
                        case 3:
                            vertDirection = GoriyaStateMachine.VertDirection.Down;
                            break;
                    }
                    ChangeVertDirection();
                    vertDelay = 0;
                }
            }

            horDelay += rnd.Next(3);
            vertDelay += rnd.Next(3);
            attackDelay++;

            stateMachine.UpdateSprite(goriyaSpriteDict);
            pos = stateMachine.Update(pos);
            goriyaSpriteDict.Position = pos;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            goriyaSpriteDict.Draw(spriteBatch, gameTime);
        }
    }
}
