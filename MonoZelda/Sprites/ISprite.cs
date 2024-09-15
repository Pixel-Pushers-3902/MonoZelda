using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PixelPushers.MonoZelda.Sprites;

interface ISprite
{

    public Texture2D Texture { get; set; }
    public int Columns { get; set; }

    void Update();
    void Draw(SpriteBatch spriteBatch, Vector2 location);
}
