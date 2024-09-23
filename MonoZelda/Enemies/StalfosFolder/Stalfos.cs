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
        private Point pos = new(250, 250); // will change later
        private readonly Random rnd = new();
        private SpriteDict stalfosSpriteDict;
        private StalfosStateMachine.Direction direction = StalfosStateMachine.Direction.Left;
        private MonoZeldaGame myGame;
        private readonly GraphicsDeviceManager graphics;

        private double startTime = 0;

        public Stalfos(SpriteDict spriteDict, GraphicsDeviceManager graphics)
        {
            stalfosSpriteDict = spriteDict;
            stateMachine = new StalfosStateMachine();
            this.graphics = graphics;
        }

        public void SetOgPos()
        {
            pos.X = 250;
            pos.Y = 250;
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
