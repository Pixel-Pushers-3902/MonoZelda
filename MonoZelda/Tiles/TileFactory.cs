using Microsoft.Xna.Framework;
using PixelPushers.MonoZelda.Sprites;

namespace PixelPushers.MonoZelda.Tiles;

internal static class TileFactory 
{
    public static ITile CreateTile(SpriteDict d, TileType type, Point position) 
    {
        ITile tile = null;
        switch (type)
        {
            case TileType.fire:
                tile = new FireTile(d);
                break;
        }

        if(tile != null)
        {
            tile.Position = position;
        }

        d.SetSprite(type.ToString());

        return tile;
    }
}