using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PixelPushers.MonoZelda.Sprites;

namespace PixelPushers.MonoZelda.Items;

public interface IItem
{
    Point Position { get; set; }
    void SetSprite(string name);
}

