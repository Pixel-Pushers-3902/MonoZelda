using Microsoft.Xna.Framework;
using PixelPushers.MonoZelda.Sprites;
using System;
using PixelPushers.MonoZelda.Tiles;

namespace PixelPushers.MonoZelda.Items;

internal class ItemCycleDemo : Item, ICycleable
{
    private int currentItemIndex;
    private ItemList[] itemTypes;
    private Point Itemposition;
    private IItem demoItem;

    public ItemCycleDemo(SpriteDict spriteDict, Point position)
    {
        itemTypes = Enum.GetValues(typeof(ItemList)) as ItemList[];   
        currentItemIndex = 0;
        Itemposition = position;
        demoItem = new Item(spriteDict);
    }

    public void Next()
    {
        // Increment the current tile index
        if (currentItemIndex == itemTypes.Length - 1)
        {
            currentItemIndex = 0;
        }
        else
        {
            currentItemIndex++;
        }

        // Update the demo sprite sprite
        demoItem.SetSprite(itemTypes[currentItemIndex].ToString());
    }

    public void Previous()
    {
        // Increment the current tile index
        if (currentItemIndex == 0)
        {
            currentItemIndex =  itemTypes.Length - 1;
        }
        else
        {
            currentItemIndex--;
        }

        // Update the demo sprite sprite
        demoItem.SetSprite(itemTypes[currentItemIndex].ToString());
    }
}