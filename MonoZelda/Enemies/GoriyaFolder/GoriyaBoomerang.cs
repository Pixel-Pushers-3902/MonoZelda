using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PixelPushers.MonoZelda;
using PixelPushers.MonoZelda.Sprites;

namespace MonoZelda.Enemies.GoriyaFolder
{
    public class GoriyaBoomerang
    {
        private Point pos;
        private readonly MonoZeldaGame myGame;
        public SpriteDict BoomerangSpriteDict {get; private set; }

        private int speed = 4;
        public GoriyaBoomerang(Point pos, MonoZeldaGame game)
        {
            this.pos = pos;
            string enemyCsvFileName = "Content/Source Rect CSVs/Sprite Source Rects - Enemies.csv";
            BoomerangSpriteDict = new(game.Content.Load<Texture2D>("Sprites/enemies"), enemyCsvFileName, 0, new Point(100, 100));
            BoomerangSpriteDict.SetSprite("boomerang");
        }

        public void Follow(Point newPos)
        {
            pos = newPos;
        }

        public void Update(GameTime gameTime, GoriyaStateMachine.Direction attackDirection, double attackTime)
        {
            if (gameTime.TotalGameTime.TotalSeconds <= attackTime + 4)
            {
                switch (attackDirection)
                {
                    case GoriyaStateMachine.Direction.Left:
                        pos.X -= speed;
                        break;
                    case GoriyaStateMachine.Direction.Right:
                        pos.X += speed;
                        break;
                    case GoriyaStateMachine.Direction.Up:
                        pos.Y -= speed;
                        break;
                    case GoriyaStateMachine.Direction.Down:
                        pos.Y += speed;
                        break;
                }
            }else if (gameTime.TotalGameTime.TotalSeconds <= attackTime + 5)
            {
                switch (attackDirection)
                {
                    case GoriyaStateMachine.Direction.Left:
                        pos.X += speed;
                        break;
                    case GoriyaStateMachine.Direction.Right:
                        pos.X -= speed;
                        break;
                    case GoriyaStateMachine.Direction.Up:
                        pos.Y += speed;
                        break;
                    case GoriyaStateMachine.Direction.Down:
                        pos.Y -= speed;
                        break;
                }
            }
            BoomerangSpriteDict.Position = pos;
        }
    }
}
