using System;
using System.ComponentModel.Design;
using Microsoft.Xna.Framework;
using MonoZelda.Enemies.StalfosFolder;
using PixelPushers.MonoZelda;
using PixelPushers.MonoZelda.Sprites;

namespace MonoZelda.Enemies.GoriyaFolder
{
    public class Goriya : IEnemy
    {
        private readonly GoriyaStateMachine stateMachine;
        private Point pos; // will change later
        private readonly Random rnd = new();
        private SpriteDict goriyaSpriteDict;
        private GoriyaStateMachine.Direction direction = GoriyaStateMachine.Direction.Left;
        private readonly GraphicsDeviceManager graphics;
        private readonly int spawnX;
        private readonly int spawnY;

        private double startTime = 0;
        private double attackDelay = 0;
        private double attackTime = 0;

        public Goriya(SpriteDict spriteDict, GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
            this.goriyaSpriteDict = spriteDict;
            stateMachine = new GoriyaStateMachine();
            spawnX = 3 * graphics.PreferredBackBufferWidth / 5;
            spawnY = 3 * graphics.PreferredBackBufferHeight / 5;
            pos = new(spawnX, spawnY);
        }


        public void SetOgPos() //sets to spawn position (eventually could be used for re-entering rooms)
        {
            pos.X = spawnX;
            pos.Y = spawnY;
            goriyaSpriteDict.SetSprite("goriya_red_left");
        }

        public void ChangeDirection()
        {
            stateMachine.ChangeDirection(direction);
        }

        public void Attack(GameTime gameTime)
        {
            stateMachine.Attack();
            if (gameTime.TotalGameTime.TotalSeconds >= attackDelay + 6)
            {
                attackDelay = gameTime.TotalGameTime.TotalSeconds;
            }
        }

        public void Update(GameTime gameTime) //might eventually split this into multiple methods, controlling random movement is more extensive than I thought.
        {
            if (gameTime.TotalGameTime.TotalSeconds < attackDelay + 3)
            {
                if (gameTime.TotalGameTime.TotalSeconds >= startTime + 1)
                {
                    switch (rnd.Next(1, 5))
                    {
                        case 1:
                            direction = GoriyaStateMachine.Direction.Left;
                            break;
                        case 2:
                            direction = GoriyaStateMachine.Direction.Right;
                            break;
                        case 3:
                            direction = GoriyaStateMachine.Direction.Up;
                            break;
                        case 4:
                            direction = GoriyaStateMachine.Direction.Down;
                            break;
                    }

                    startTime = gameTime.TotalGameTime.TotalSeconds;
                    ChangeDirection();
                    stateMachine.UpdateSprite(goriyaSpriteDict);
                }

                pos = stateMachine.Update(pos, goriyaSpriteDict, graphics);
                goriyaSpriteDict.Position = pos;
            }
            else
            {
                Attack(gameTime);
            }
        }
    }
}
