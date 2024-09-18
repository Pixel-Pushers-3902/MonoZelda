using Microsoft.Xna.Framework;
using PixelPushers.MonoZelda.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
