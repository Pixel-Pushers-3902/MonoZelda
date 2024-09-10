using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LevelBasedGame.Sprites {
    public class Sprite
    {
        public enum AnchorType {
            center,
            topLeft
        }

        public Rectangle SourceRect { get; set; }
        public int FrameCount { get; set; }
        public float Size { get; set; }
        public AnchorType Anchor { get; set; }
        public bool Animating { get; set; }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Texture2D texture) {

        }
    }
}
