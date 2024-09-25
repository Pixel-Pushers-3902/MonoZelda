using Microsoft.Xna.Framework;
using PixelPushers.MonoZelda.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoZelda.Enemies.AquamentusFolder
{
    public class Aquamentus : IEnemy
    {
        private readonly AquamentusStateMachine stateMachine;
        private Point pos;
        private readonly Random rnd = new();
        private SpriteDict aquamentusSpriteDict;
        private readonly GraphicsDeviceManager graphics;
        private readonly int spawnX;
        private readonly int spawnY;

        private double startTime = 0;
        private int moveDelay;

        public Aquamentus(SpriteDict spriteDict, GraphicsDeviceManager graphics)
        {
            aquamentusSpriteDict = spriteDict;
            stateMachine = new AquamentusStateMachine();
            this.graphics = graphics;
            spawnX = 3 * graphics.PreferredBackBufferWidth / 5;
            spawnY = 3 * graphics.PreferredBackBufferHeight / 5;
            pos = new(spawnX, spawnY);
            moveDelay = rnd.Next(1, 4);
        }

        public void SetOgPos()
        {
            pos.X = spawnX;
            pos.Y = spawnY;
            aquamentusSpriteDict.Position = pos;
            aquamentusSpriteDict.SetSprite("aquamentus_left");
        }
        public void ChangeDirection()
        {
            stateMachine.ChangeDirection();
        }

        public void Update(GameTime gameTime)
        {
            if(pos.X > spawnX || pos.X < spawnX - 150)
            {
                ChangeDirection();
            }
            else
            {
                if(gameTime.TotalGameTime.TotalSeconds >= startTime + moveDelay)
                {
                    ChangeDirection();
                    startTime = gameTime.TotalGameTime.TotalSeconds;
                    moveDelay = rnd.Next(1, 4);
                }
            }
            pos = stateMachine.Update(pos);
            aquamentusSpriteDict.Position = pos;
        }
    }
}
