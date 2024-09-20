using Microsoft.Xna.Framework;
using PixelPushers.MonoZelda.Sprites;
using System;

namespace PixelPushers.MonoZelda.Tiles;

internal class TileCycleDemo : TileBase, ICycleable
{
    private int _currentTileIndex;
    private BlockType[] _tileTypes;
    private Point _position;
    private ITile DemoTile;

    public TileCycleDemo(SpriteDict spriteDict, Point position) : base(spriteDict)
    {
        _tileTypes = Enum.GetValues(typeof(BlockType)) as BlockType[];

        _currentTileIndex = 0;
        _position = position;

        DemoTile = TileFactory.CreateTile<DoorTile>(spriteDict, BlockType.tile_block1, _position);
    }

    public void Next()
    {
        // Increment the current tile index
        if (_currentTileIndex == _tileTypes.Length - 1)
        {
            _currentTileIndex = 0;
        }
        else
        {
            _currentTileIndex++;
        }

        // Update the demo sprite sprite
        DemoTile.SetSprite(_tileTypes[_currentTileIndex].ToString());
    }

    public void Previous()
    {
        // Increment the current tile index
        if (_currentTileIndex == 0)
        {
            _currentTileIndex = _tileTypes.Length - 1;
        }
        else
        {
            _currentTileIndex--;
        }

        // Update the demo sprite sprite
        DemoTile.SetSprite(_tileTypes[_currentTileIndex].ToString());
    }
}