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
        private KeeseStateMachine stateMachine;
        private int horDelay;
        private int vertDelay;
        private Random rnd = new Random();

        public Keese(SpriteDict spriteDict)
        {
            stateMachine = new KeeseStateMachine(spriteDict);

            horDelay = 0;
            vertDelay = 0;
        }

        public void Attack()
        {
            throw new NotImplementedException();
        }

        public void ChangeHorDirection()
        {
            stateMachine.ChangeHorDirection();
        }

        public void ChangeVertDirection()
        {
            stateMachine.ChangeVertDirection();
        }

        public void Update()
        {
            if (horDelay >= rnd.Next(150,300))
            {
                ChangeHorDirection();
                horDelay = 0;
            }

            if (vertDelay >= rnd.Next(150,300))
            {
                ChangeVertDirection();
                vertDelay = 0;
            }

            horDelay += rnd.Next(3);
            vertDelay += rnd.Next(3);

            stateMachine.Update();
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            stateMachine.Draw(spriteBatch, gameTime);
        }
    }
}
