using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PixelPushers.MonoZelda.Sprites;

namespace PixelPushers.MonoZelda.Items;

public class Item : IItem
{
    public Point Position { get; set; }

    private SpriteDict spriteDict;

    public Item()
    {

    }

    public Item(SpriteDict itemDict)
    {
        spriteDict = itemDict;
    }

    public void SetSprite(string name)
    {
        if (spriteDict != null)
        {
            spriteDict.SetSprite(name);
        }

    }
}

