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
/// This script automatically changes the color of the specified sprite based on the value of the slider.
/// </summary>

[AddComponentMenu("NGUI/Examples/Slider Colors")]
public class UISliderColors : MonoBehaviour
{
	public UISprite sprite;

	public Color[] colors = new Color[] { Color.red, Color.yellow, Color.green };

	UIProgressBar mBar;
	UIBasicSprite mSprite;

	void Start ()
	{
		mBar = GetComponent<UIProgressBar>();
		mSprite = GetComponent<UIBasicSprite>();
		Update();
	}

	void Update ()
	{
		if (sprite == null || colors.Length == 0) return;

		float val = (mBar != null) ? mBar.value : mSprite.fillAmount;
		val *= (colors.Length - 1);
		int startIndex = Mathf.FloorToInt(val);

		Color c = colors[0];

		if (startIndex >= 0)
		{
			if (startIndex + 1 < colors.Length)
			{
				float factor = (val - startIndex);
				c = Color.Lerp(colors[startIndex], colors[startIndex + 1], factor);
			}
			else if (startIndex < colors.Length)
			{
				c = colors[startIndex];
			}
			else c = colors[colors.Length - 1];
		}

		c.a = sprite.color.a;
		sprite.color = c;
	}
}
