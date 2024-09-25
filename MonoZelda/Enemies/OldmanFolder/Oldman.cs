using Microsoft.Xna.Framework;
using MonoZelda.Enemies.StalfosFolder;
using PixelPushers.MonoZelda.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoZelda.Enemies.OldmanFolder
{
    public class Oldman : IEnemy
    {
        private Point pos;
        private SpriteDict oldmanSpriteDict;
        private readonly int spawnX;
        private readonly int spawnY;

        public Oldman(SpriteDict spriteDict, GraphicsDeviceManager graphics)
        {
            oldmanSpriteDict = spriteDict;
            spawnX = 3 * graphics.PreferredBackBufferWidth / 5;
            spawnY = 3 * graphics.PreferredBackBufferHeight / 5;
            pos = new(spawnX, spawnY);

        }
        public void SetOgPos()
        {
            pos.X = spawnX;
            pos.Y = spawnY;
            oldmanSpriteDict.SetSprite("oldman");
        }

        public void ChangeDirection()
        {
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
