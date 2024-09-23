using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MonoZelda.Enemies.GoriyaFolder;
using PixelPushers.MonoZelda;
using PixelPushers.MonoZelda.Sprites;

namespace MonoZelda.Enemies.StalfosFolder
{
    public class Stalfos : IEnemy
    {
        private readonly StalfosStateMachine stateMachine;
        private Point pos;
        private readonly Random rnd = new();
        private SpriteDict stalfosSpriteDict;
        private StalfosStateMachine.Direction direction = StalfosStateMachine.Direction.Left;
        private readonly GraphicsDeviceManager graphics;
        private readonly int spawnX;
        private readonly int spawnY;

        private double startTime = 0;

        public Stalfos(SpriteDict spriteDict, GraphicsDeviceManager graphics)
        {
            stalfosSpriteDict = spriteDict;
            stateMachine = new StalfosStateMachine();
            this.graphics = graphics;
            spawnX = 3 * graphics.PreferredBackBufferWidth / 5;
            spawnY = 3 * graphics.PreferredBackBufferHeight / 5;
            pos = new(spawnX, spawnY);
        }

        public void SetOgPos()
        {
            pos.X = spawnX;
            pos.Y = spawnY;
            stalfosSpriteDict.SetSprite("stalfos");
        }

        public void ChangeDirection()
        {
            stateMachine.ChangeDirection(direction);
        }

        public void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalSeconds >= startTime + 1)
            {
                switch (rnd.Next(1, 5))
                {
                    case 1:
                        direction = StalfosStateMachine.Direction.Left;
                        break;
                    case 2:
                        direction = StalfosStateMachine.Direction.Right;
                        break;
                    case 3:
                        direction = StalfosStateMachine.Direction.Up;
                        break;
                    case 4:
                        direction = StalfosStateMachine.Direction.Down;
                        break;
                }

                startTime = gameTime.TotalGameTime.TotalSeconds;
                ChangeDirection();
            }
            pos = stateMachine.Update(pos, graphics);
            stalfosSpriteDict.Position = pos;
        }
    }
}
