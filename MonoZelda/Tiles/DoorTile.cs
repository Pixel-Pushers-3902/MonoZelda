using System;

namespace PixelPushers.MonoZelda.Tiles;

internal class DoorTile : TileBase, IInteractiveTile
{
    private TileFacing _facing;
    private bool _isOpen;

    public DoorTile() : base()
    {
        _isOpen = false;
    }

    public DoorTile(TileFacing facing) : base()
        {
        _facing = facing;       
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

