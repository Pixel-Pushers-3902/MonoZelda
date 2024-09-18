﻿using Microsoft.Xna.Framework;
using PixelPushers.MonoZelda.Sprites;

namespace PixelPushers.MonoZelda.Tiles;

internal abstract class TileBase : ITile
{
    public Point Position { get; set; }
    public bool IsPassable { get; set; }

    private SpriteDict _spriteDict;

    public TileBase(SpriteDict tileSprite)
    {
        _spriteDict = tileSprite;
    }

    public void SetSprite(string name)
    {
        _spriteDict.SetSprite(name);
    }
}