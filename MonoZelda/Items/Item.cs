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
		// storing current item as a string
		string itemName = ItemDictionary.ItemPairs[currentItem];

		// set sprite to be drawn
		ItemDict.SetSprite(itemName);
	}

	/*void PlaceItem()
	{
		To-do: add working code. Used to place items like bombs
    }	*/

}

