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
        private string currentSprite = "";

        public SpriteDict(Texture2D texture, Point position) {
            this.texture = texture;
            Position = position;
        }

        public void Add(Sprite sprite, string name) {
            dict.Add(name, sprite);
            if (currentSprite == "")
                currentSprite = name;
        }

        public void SetSprite(string name) {
            currentSprite = name;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            dict[currentSprite].Draw(spriteBatch, gameTime, texture);
        }
    }
}
