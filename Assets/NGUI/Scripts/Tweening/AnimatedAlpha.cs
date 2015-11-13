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
/// Makes it possible to animate alpha of the widget or a panel.
/// </summary>

[ExecuteInEditMode]
public class AnimatedAlpha : MonoBehaviour
{
	[Range(0f, 1f)]
	public float alpha = 1f;

	UIWidget mWidget;
	UIPanel mPanel;

	void OnEnable ()
	{
		mWidget = GetComponent<UIWidget>();
		mPanel = GetComponent<UIPanel>();
		LateUpdate();
	}

	void LateUpdate ()
	{
		if (mWidget != null) mWidget.alpha = alpha;
		if (mPanel != null) mPanel.alpha = alpha;
	}
}
