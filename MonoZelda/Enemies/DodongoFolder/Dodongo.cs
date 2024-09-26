using Microsoft.Xna.Framework;
using PixelPushers.MonoZelda.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoZelda.Enemies.DodongoFolder
{
    public class Dodongo: IEnemy
    {
        private readonly DodongoStateMachine stateMachine;
        private Point pos;
        private readonly Random rnd = new();
        private SpriteDict dodongoSpriteDict;
        private DodongoStateMachine.Direction direction = DodongoStateMachine.Direction.Left;
        private readonly GraphicsDeviceManager graphics;
        private readonly int spawnX;
        private readonly int spawnY;

        private double startTime = 0;

        public Dodongo(SpriteDict spriteDict, GraphicsDeviceManager graphics)
        {
            dodongoSpriteDict = spriteDict;
            stateMachine = new DodongoStateMachine();
            this.graphics = graphics;
            spawnX = 3 * graphics.PreferredBackBufferWidth / 5;
            spawnY = 3 * graphics.PreferredBackBufferHeight / 5;
            pos = new(spawnX, spawnY);
        }

        public void SetOgPos()
        {
            pos.X = spawnX;
            pos.Y = spawnY;
            dodongoSpriteDict.Position = pos;
            dodongoSpriteDict.SetSprite("dodongo_left");
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
                        direction = DodongoStateMachine.Direction.Left;
                        dodongoSpriteDict.SetSprite("dodongo_left");
                        break;
                    case 2:
                        direction = DodongoStateMachine.Direction.Right;
                        dodongoSpriteDict.SetSprite("dodongo_right");
                        break;
                    case 3:
                        direction = DodongoStateMachine.Direction.Up;
                        dodongoSpriteDict.SetSprite("dodongo_up");
                        break;
                    case 4:
                        direction = DodongoStateMachine.Direction.Down;
                        dodongoSpriteDict.SetSprite("dodongo_down");
                        break;
                }

                startTime = gameTime.TotalGameTime.TotalSeconds;
                ChangeDirection();
            }
            pos = stateMachine.Update(pos, graphics);
            dodongoSpriteDict.Position = pos;
        }
    }
}
