using System.Collections.Generic;

namespace PixelPushers.MonoZelda.Items;

internal static class ItemDictionary
{
	public static Dictionary<ItemList,string> ItemPairs = new Dictionary<ItemList, string>()
	{
		{ItemList.Compass,"compass" },
		{ItemList.Map, "map" },
		{ItemList.Key, "key" },
		{ItemList.HeartContainer,"heart_container" },
		{ItemList.TriforcePiece,"triforce_piece" },
		{ItemList.Boomerang,"wooden_boomerang" },
		{ItemList.Bow,"bow" },
		{ItemList.Heart,"heart" },
		{ItemList.Rupee,"rupee" },
		{ItemList.Arrow,"arrow" },
		{ItemList.Bomb,"bomb" },
		{ItemList.Fairy,"fairy" },
		{ItemList.Clock,"clock" },
		{ItemList.BlueCandle,"blue_candle" },
		{ItemList.BluePotion,"blue_potion" }
	};

}
