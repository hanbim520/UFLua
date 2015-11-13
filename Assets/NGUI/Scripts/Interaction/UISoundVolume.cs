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
/// Very simple script that can be attached to a slider and will control the volume of all sounds played via NGUITools.PlaySound,
/// which includes all of UI's sounds.
/// </summary>

[RequireComponent(typeof(UISlider))]
[AddComponentMenu("NGUI/Interaction/Sound Volume")]
public class UISoundVolume : MonoBehaviour
{
	void Awake ()
	{
		UISlider slider = GetComponent<UISlider>();
		slider.value = NGUITools.soundVolume;
		EventDelegate.Add(slider.onChange, OnChange);
	}

	void OnChange ()
	{
		NGUITools.soundVolume = UISlider.current.value;
	}
}
