/*
wine整理，Q710605420 UFLua 意为免费使用的unityLua，插件部分需要付费的，请自行付费，如有版权问题，整理者概不负责！Q群:479355429

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2015 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Turns the popup list it's attached to into a language selection list.
/// </summary>

[RequireComponent(typeof(UIPopupList))]
[AddComponentMenu("NGUI/Interaction/Language Selection")]
public class LanguageSelection : MonoBehaviour
{
	UIPopupList mList;

	void Awake ()
	{
		mList = GetComponent<UIPopupList>();
		Refresh();
	}

	void Start () { EventDelegate.Add(mList.onChange, delegate() { Localization.language = UIPopupList.current.value; }); }

	/// <summary>
	/// Immediately refresh the list of known languages.
	/// </summary>

	public void Refresh ()
	{
		if (mList != null && Localization.knownLanguages != null)
		{
			mList.Clear();

			for (int i = 0, imax = Localization.knownLanguages.Length; i < imax; ++i)
				mList.items.Add(Localization.knownLanguages[i]);

			mList.value = Localization.language;
		}
	}
}
