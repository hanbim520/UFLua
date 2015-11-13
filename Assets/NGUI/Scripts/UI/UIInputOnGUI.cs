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

#if !UNITY_EDITOR && (UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8 || UNITY_BLACKBERRY || UNITY_WINRT)
#define MOBILE
#endif

using UnityEngine;

/// <summary>
/// This class is added by UIInput when it gets selected in order to be able to receive input events properly.
/// The reason it's not a part of UIInput is because it allocates 336 bytes of GC every update because of OnGUI.
/// It's best to only keep it active when it's actually needed.
/// </summary>

[RequireComponent(typeof(UIInput))]
public class UIInputOnGUI : MonoBehaviour
{
#if !MOBILE
	[System.NonSerialized] UIInput mInput;

	void Awake () { mInput = GetComponent<UIInput>(); }

	/// <summary>
	/// Unfortunately Unity 4.3 and earlier doesn't offer a way to properly process events outside of OnGUI.
	/// </summary>

	void OnGUI ()
	{
		if (Event.current.rawType == EventType.KeyDown)
			mInput.ProcessEvent(Event.current);
	}
#endif
}
