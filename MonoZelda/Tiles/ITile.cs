using Microsoft.Xna.Framework;

namespace PixelPushers.MonoZelda.Tiles;

internal interface ITile
{
    Point Position { get; set; }
    bool IsPassable { get; set; }
    void SetSprite(string t);
}
