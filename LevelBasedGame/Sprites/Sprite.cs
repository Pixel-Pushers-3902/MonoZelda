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

        public Sprite(Rectangle sourceRect, AnchorType anchor = AnchorType.center, int frameCount = 1, float size = 1f, bool animating = true) {
            SourceRect = sourceRect;
            Anchor = anchor;
            FrameCount = frameCount;
            Size = size;
            Animating = animating;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Texture2D texture) {
            float fps = 2;
            int sourceX = Animating ? (int) ((gameTime.TotalGameTime.TotalSeconds * fps) % FrameCount) * SourceRect.Width : 0;
            Rectangle currentSource = new(sourceX, SourceRect.Y, SourceRect.Width, SourceRect.Height);
            spriteBatch.Draw(texture, new Rectangle(100, 100, 64, 64), currentSource, Color.White);
        }
    }
}
