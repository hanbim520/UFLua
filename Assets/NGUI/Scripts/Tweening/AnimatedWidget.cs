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
/// Makes it possible to animate the widget's width and height using Unity's animations.
/// </summary>

[ExecuteInEditMode]
public class AnimatedWidget : MonoBehaviour
{
	public float width = 1f;
	public float height = 1f;

	UIWidget mWidget;

	void OnEnable ()
	{
		mWidget = GetComponent<UIWidget>();
		LateUpdate();
	}

	void LateUpdate ()
	{
		if (mWidget != null)
		{
			mWidget.width = Mathf.RoundToInt(width);
			mWidget.height = Mathf.RoundToInt(height);
		}
	}
}
