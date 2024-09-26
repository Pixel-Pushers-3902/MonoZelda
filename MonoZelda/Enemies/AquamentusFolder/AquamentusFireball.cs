using System;
using PixelPushers.MonoZelda.Sprites;
using PixelPushers.MonoZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoZelda.Enemies.AquamentusFolder
{
    public class AquamentusFireball
    {
        private Point pos;
        private readonly MonoZeldaGame myGame;
        public SpriteDict FireballSpriteDict { get; private set; }

        private int speed = 4;
        private double angle;

        public AquamentusFireball(Point pos, MonoZeldaGame game, int newAngle)
        {
            this.pos = pos;
            string enemyCsvFileName = "Content/Source Rect CSVs/Sprite Source Rects - Enemies.csv";
            FireballSpriteDict = new(game.Content.Load<Texture2D>("Sprites/enemies"), enemyCsvFileName, 0, new Point(100, 100));
            FireballSpriteDict.SetSprite("fireball");
            angle = newAngle;
            if (angle <= 180)
            {
                if (angle <= 90)
                {
                    angle = angle / 180 - 2;
                }
                else
                {
                    angle = angle / 180 - 1;
                }
            }
            else
            {
                angle /= 180;
            }
        }

        public void Follow(Point newPos)
        {
            pos.X = newPos.X;
            pos.Y = newPos.Y - 48;
        }

        public void Update()
        {
            pos.X -= speed;
            if (angle >= 1.5)
            {
                angle = Math.Ceiling(angle);
            }
            else
            {
                angle = Math.Floor(angle);
            }

            pos.Y -= (int)angle;

            FireballSpriteDict.Position = pos;
        }
    }
}
