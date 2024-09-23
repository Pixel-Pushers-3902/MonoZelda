using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using PixelPushers.MonoZelda.Sprites;

namespace MonoZelda.Enemies.ZolFolder
{
    public class Zol : IEnemy
    {
        private readonly ZolStateMachine stateMachine;
        private Point pos = new(250, 250); // will change later
        private readonly Random rnd = new();
        private readonly SpriteDict zolSpriteDict;
        private ZolStateMachine.Direction direction = ZolStateMachine.Direction.Left;
        private readonly GraphicsDeviceManager graphics;

        private double startTime = 0;
        private bool readyToJump = true;

        public Zol(SpriteDict spriteDict, GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
            this.zolSpriteDict = spriteDict;
            stateMachine = new ZolStateMachine();
        }


        public void SetOgPos() //sets to spawn position (eventually could be used for re-entering rooms)
        {
            pos.X = 250;
            pos.Y = 250;
            zolSpriteDict.SetSprite("zol_green");
        }

        public void ChangeDirection()
        {
            stateMachine.ChangeDirection(direction);
        }


        public void Update(GameTime gameTime) //might eventually split this into multiple methods, controlling random movement is more extensive than I thought.
        {
            if (readyToJump)
            {
                switch (rnd.Next(1, 5))
                {
                    case 1:
                        direction = ZolStateMachine.Direction.Left;
                        break;
                    case 2:
                        direction = ZolStateMachine.Direction.Right;
                        break;
                    case 3:
                        direction = ZolStateMachine.Direction.Up;
                        break;
                    case 4:
                        direction = ZolStateMachine.Direction.Down;
                        break;
                }

                startTime = gameTime.TotalGameTime.TotalSeconds;
                readyToJump = false;
                ChangeDirection();
            }
            else
            {
                if (gameTime.TotalGameTime.TotalSeconds >= startTime + 1)
                {
                    direction = ZolStateMachine.Direction.None;
                    ChangeDirection();
                    if (gameTime.TotalGameTime.TotalSeconds >= startTime + 2)
                    {
                        readyToJump = true;
                    }
                }
            }

            pos = stateMachine.Update(pos, graphics);
            zolSpriteDict.Position = pos;
        }
    }
}
