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
/// Equip the specified items on the character when the script is started.
/// </summary>

[AddComponentMenu("NGUI/Examples/Equip Items")]
public class EquipItems : MonoBehaviour
{
	public int[] itemIDs;

	void Start ()
	{
		if (itemIDs != null && itemIDs.Length > 0)
		{
			InvEquipment eq = GetComponent<InvEquipment>();
			if (eq == null) eq = gameObject.AddComponent<InvEquipment>();

			int qualityLevels = (int)InvGameItem.Quality._LastDoNotUse;

			for (int i = 0, imax = itemIDs.Length; i < imax; ++i)
			{
				int index = itemIDs[i];
				InvBaseItem item = InvDatabase.FindByID(index);

				if (item != null)
				{
					InvGameItem gi = new InvGameItem(index, item);
					gi.quality = (InvGameItem.Quality)Random.Range(0, qualityLevels);
					gi.itemLevel = NGUITools.RandomRange(item.minItemLevel, item.maxItemLevel);
					eq.Equip(gi);
				}
				else
				{
					Debug.LogWarning("Can't resolve the item ID of " + index);
				}
			}
		}
		Destroy(this);
	}
}
