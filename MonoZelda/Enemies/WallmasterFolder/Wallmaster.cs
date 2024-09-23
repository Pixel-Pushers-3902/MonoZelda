using Microsoft.Xna.Framework;
using PixelPushers.MonoZelda.Sprites;
using PixelPushers.MonoZelda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoZelda.Enemies.WallmasterFolder
{
    public class Wallmaster : IEnemy
    {
        private readonly WallmasterStateMachine stateMachine;
        private Point pos = new(250, 250); // will change later
        private readonly Random rnd = new();
        private SpriteDict wallmasterSpriteDict;
        private WallmasterStateMachine.Direction direction = WallmasterStateMachine.Direction.Left;
        private readonly GraphicsDeviceManager graphics;

        private double startTime = 0;

        public Wallmaster(SpriteDict spriteDict, GraphicsDeviceManager graphics)
        {
            wallmasterSpriteDict = spriteDict;
            stateMachine = new WallmasterStateMachine();
            this.graphics = graphics;
        }

        public void SetOgPos()
        {
            pos.X = 250;
            pos.Y = 250;
            wallmasterSpriteDict.SetSprite("wallmaster");
        }

        public void ChangeDirection()
        {
            stateMachine.ChangeDirection(direction);
        }

        //Just using stalfos movement for now since wallmaster moves kind of weird
        public void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalSeconds >= startTime + 1)
            {
                switch (rnd.Next(1, 5))
                {
                    case 1:
                        direction = WallmasterStateMachine.Direction.Left;
                        break;
                    case 2:
                        direction = WallmasterStateMachine.Direction.Right;
                        break;
                    case 3:
                        direction = WallmasterStateMachine.Direction.Up;
                        break;
                    case 4:
                        direction = WallmasterStateMachine.Direction.Down;
                        break;
                }

                startTime = gameTime.TotalGameTime.TotalSeconds;
                ChangeDirection();
            }
            pos = stateMachine.Update(pos, graphics);
            wallmasterSpriteDict.Position = pos;
        }
    }
}
