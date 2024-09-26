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
        private int angle;

        public AquamentusFireball(Point pos, MonoZeldaGame game, int angle)
        {
            this.pos = pos;
            string enemyCsvFileName = "Content/Source Rect CSVs/Sprite Source Rects - Enemies.csv";
            FireballSpriteDict = new(game.Content.Load<Texture2D>("Sprites/enemies"), enemyCsvFileName, 0, new Point(100, 100));
            FireballSpriteDict.SetSprite("fireball");
            this.angle = angle;
        }

        public void Follow(Point newPos)
        {
            pos.X = newPos.X;
            pos.Y = newPos.Y - 48;
        }

        public void Update()
        {
            pos.X -= speed;
            if (angle <= 180)
            {
                pos.Y -= angle / 180 - 1;
            }
            else
            {
                pos.Y -= angle / 180;
            }

            FireballSpriteDict.Position = pos;
        }
    }
}
