/*
wine整理，Q710605420 UFLua 意为免费使用的unityLua，插件部分需要付费的，请自行付费，如有版权问题，整理者概不负责！Q群:479355429

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;

[RequireComponent(typeof(UIWidget))]
public class SetColorPickerColor : MonoBehaviour
{
	[System.NonSerialized] UIWidget mWidget;

	public void SetToCurrent ()
	{
		if (mWidget == null) mWidget = GetComponent<UIWidget>();
		if (UIColorPicker.current != null)
			mWidget.color = UIColorPicker.current.value;
	}
}
