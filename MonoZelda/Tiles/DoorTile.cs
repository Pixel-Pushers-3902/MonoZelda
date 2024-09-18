using PixelPushers.MonoZelda.Sprites;
using System;

namespace PixelPushers.MonoZelda.Tiles;

internal class DoorTile : TileBase, IInteractiveTile
{
    SpriteDict _spriteDict;

    public DoorTile()
    {
    }

    public DoorTile(SpriteDict spriteDict, TileFacing facing) : base(spriteDict)
    {
        _spriteDict = spriteDict;
        // Pick the correct sprite for the door based on the facing
        switch (facing)
        {
            case TileFacing.NORTH:
                spriteDict.SetSprite("door_north");
                break;
            case TileFacing.SOUTH:
                spriteDict.SetSprite("door_south");
                break;
            case TileFacing.EAST:
                spriteDict.SetSprite("door_east");
                break;
            case TileFacing.WEST:
                spriteDict.SetSprite("door_west");
                break;
        }
    }

    public void Interact(object player)
    {
        throw new NotImplementedException();
    }

    public void Destory()
    {
        _spriteDict = null;
    }
}

