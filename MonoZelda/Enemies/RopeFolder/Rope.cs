using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using PixelPushers.MonoZelda.Sprites;

namespace MonoZelda.Enemies.RopeFolder
{
    public class Rope : IEnemy
    {
        private readonly RopeStateMachine stateMachine;
        private Point pos;
        private readonly Random rnd = new();
        private SpriteDict ropeSpriteDict;
        private RopeStateMachine.Direction direction = RopeStateMachine.Direction.Left;
        private readonly GraphicsDeviceManager graphics;
        private readonly int spawnX;
        private readonly int spawnY;

        public Rope(SpriteDict spriteDict, GraphicsDeviceManager graphics)
        {
            ropeSpriteDict = spriteDict;
            stateMachine = new RopeStateMachine();
            this.graphics = graphics;
            spawnX = 3 * graphics.PreferredBackBufferWidth / 5;
            spawnY = 3 * graphics.PreferredBackBufferHeight / 5;
            pos = new(spawnX, spawnY);
        }

        public void SetOgPos()
        {
            pos.X = spawnX;
            pos.Y = spawnY;
            ropeSpriteDict.Position = pos;
            ropeSpriteDict.SetSprite("rope_left");
        }

        public void ChangeDirection()
        {
            stateMachine.ChangeDirection(direction);
        }

        public void Update(GameTime gameTime)
        {
            if (pos.X >= graphics.PreferredBackBufferWidth - 32 || pos.X <= 0 + 32)
            {
                switch (rnd.Next(1,3))
                {
                    case 1:
                        direction = RopeStateMachine.Direction.Up;
                        break;
                    case 2:
                        direction = RopeStateMachine.Direction.Down;
                        break;
                }
            }

            if (pos.Y >= graphics.PreferredBackBufferHeight - -32 || pos.Y <= 0 + 32)
            {
                switch (rnd.Next(1, 3))
                {
                    case 1:
                        direction = RopeStateMachine.Direction.Left;
                        ropeSpriteDict.SetSprite("rope_left");
                        break;
                    case 2:
                        direction = RopeStateMachine.Direction.Right;
                        ropeSpriteDict.SetSprite("rope_right");
                        break;
                }
            }

            pos = stateMachine.Update(pos);
            ropeSpriteDict.Position = pos;
        }
    }
}
