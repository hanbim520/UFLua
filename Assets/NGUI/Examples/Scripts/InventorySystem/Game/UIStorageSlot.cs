/*
wine整理，Q710605420 UFLua 意为免费使用的unityLua，插件部分需要付费的，请自行付费，如有版权问题，整理者概不负责！Q群:479355429

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2014 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// A UI script that keeps an eye on the slot in a storage container.
/// </summary>

[AddComponentMenu("NGUI/Examples/UI Storage Slot")]
public class UIStorageSlot : UIItemSlot
{
	public UIItemStorage storage;
	public int slot = 0;

	override protected InvGameItem observedItem
	{
		get
		{
			return (storage != null) ? storage.GetItem(slot) : null;
		}
	}

	/// <summary>
	/// Replace the observed item with the specified value. Should return the item that was replaced.
	/// </summary>

	override protected InvGameItem Replace (InvGameItem item)
	{
		return (storage != null) ? storage.Replace(slot, item) : item;
	}
}
