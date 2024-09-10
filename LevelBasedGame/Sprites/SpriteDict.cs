using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace LevelBasedGame.Sprites {
    internal class SpriteDict
    {
        public Point Position { get; set; }
        public bool Enabled { get; set; }

        private Texture2D texture;
        private Dictionary<string, Sprite> dict = new();

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime) {

        }
    }
}
