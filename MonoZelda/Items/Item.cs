using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PixelPushers.MonoZelda.Sprites;

namespace PixelPushers.MonoZelda.Items;

public class Item : IItem
{
	private ItemList currentItem;

	public ItemList CurrentItem
	{
		get
		{
			return currentItem;
		}
		set
		{
			currentItem = value;
		}
	}

    // Constructor to initialize default item: Compass
    public Item()
	{
		currentItem = ItemList.Compass;
	}

	public void SetSpriteItemDict(SpriteDict ItemDict,SpriteBatch spriteBatch,GameTime gameTime)
	{
	    if (currentItem == ItemList.Compass)
		{
			ItemDict.SetSprite("compass");
		}
		else if (currentItem == ItemList.Map)
		{
			ItemDict.SetSprite("map");
		}
		else if (currentItem == ItemList.Key)
		{
			ItemDict.SetSprite("key");
		}
		else if (currentItem == ItemList.HeartContainer)
		{
			ItemDict.SetSprite("heart_containter");
		}
		else if (currentItem == ItemList.TriforcePiece)
		{
			ItemDict.SetSprite("triforce_piece");
		}
		else if (currentItem == ItemList.Boomerang)
		{
			ItemDict.SetSprite("wooden_boomerang");
		}
        else if (currentItem == ItemList.Bow)
        {
            ItemDict.SetSprite("bow");
        }
        else if (currentItem == ItemList.Heart)
        {
            ItemDict.SetSprite("heart");
        }
        else if (currentItem == ItemList.Rupee)
        {
            ItemDict.SetSprite("rupee");
        }
        else if (currentItem == ItemList.Arrow)
        {
            ItemDict.SetSprite("arrow");
        }
        else if (currentItem == ItemList.Bomb)
        {
            ItemDict.SetSprite("bomb");
        }
        else if (currentItem == ItemList.Fairy)
        {
			ItemDict.SetSprite("fairy");
		}
		else if (currentItem == ItemList.Clock)
		{
		    ItemDict.SetSprite("clock");
		}
		else if (currentItem == ItemList.BlueCandle)
		{
			ItemDict.SetSprite("blue_candle");
		}
		else if (currentItem == ItemList.BluePotion)
		{
			ItemDict.SetSprite("blue_potion");
		}
	}

}

