using PixelPushers.MonoZelda.Sprites;
using System;

namespace PixelPushers.MonoZelda.Tiles;

internal class FireTile : TileBase, IInteractiveTile
{
    public FireTile(SpriteDict spriteDict) : base(spriteDict)
    {
        IsPassable = true;
        spriteDict.SetSprite("fire");
    }

    public void Interact(object player)
    {
        throw new NotImplementedException();
    }
}
