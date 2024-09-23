using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PixelPushers.MonoZelda.Sprites;

namespace PixelPushers.MonoZelda.Items;

public interface IItem
{
    public ItemList CurrentItem { get; set; }

    void SetSpriteItemDict(SpriteDict ItemsDict, SpriteBatch spriteBatch, GameTime gameTime);

    //void PlaceItem();
}

