using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoZelda.Enemies.EnemyStateMachines;
using PixelPushers.MonoZelda.Sprites;

namespace MonoZelda.Enemies
{
    public class Keese : IEnemy
    {
        private readonly KeeseStateMachine stateMachine;
        private int horDelay;
        private int vertDelay;
        private readonly Random rnd = new();
        private Point pos = new Point(250, 250);
        private SpriteDict keeseSpriteDict;
        private KeeseStateMachine.VertDirection vertDirection = KeeseStateMachine.VertDirection.None;
        private KeeseStateMachine.HorDirection horDirection = KeeseStateMachine.HorDirection.None;

        public Keese(SpriteDict spriteDict)
        {
            stateMachine = new KeeseStateMachine();
            keeseSpriteDict = spriteDict;
            keeseSpriteDict.SetSprite("walk_down"); //using link sprites for now

            horDelay = 100;
            vertDelay = 0;
        }

        public void SetOgPos()
        {
            pos.X = 250;
            pos.Y = 250;
        }

        public void Attack()
        {
            throw new NotImplementedException();
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
            if (horDelay >= rnd.Next(50, 100))
            {
                switch (rnd.Next(1, 3))
                {
                    case 1:
                        horDirection = KeeseStateMachine.HorDirection.Left;
                        break;
                    case 2:
                        horDirection = KeeseStateMachine.HorDirection.Right;
                        break;
                }

                ChangeHorDirection();
                horDelay = 0;
            }

            if (vertDelay >= rnd.Next(50, 100))
            {
                switch (rnd.Next(1, 3))
                {
                    case 1:
                        vertDirection = KeeseStateMachine.VertDirection.Up;
                        break;
                    case 2:
                        vertDirection = KeeseStateMachine.VertDirection.Down;
                        break;
                }

                ChangeVertDirection();
                vertDelay = 0;
            }

            horDelay += rnd.Next(3);
            vertDelay += rnd.Next(3);

            pos = stateMachine.Update(pos);
            keeseSpriteDict.Position = pos;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            keeseSpriteDict.Draw(spriteBatch, gameTime);
        }
    }
}
