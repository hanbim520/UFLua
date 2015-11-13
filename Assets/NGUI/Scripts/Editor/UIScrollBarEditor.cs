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
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(UIScrollBar))]
public class UIScrollBarEditor : UIProgressBarEditor
{
	protected override void DrawLegacyFields ()
	{
		UIScrollBar sb = target as UIScrollBar;

		float val = EditorGUILayout.Slider("Value", sb.value, 0f, 1f);
		float size = EditorGUILayout.Slider("Size", sb.barSize, 0f, 1f);
		float alpha = EditorGUILayout.Slider("Alpha", sb.alpha, 0f, 1f);

		if (sb.value != val ||
			sb.barSize != size ||
			sb.alpha != alpha)
		{
			NGUIEditorTools.RegisterUndo("Scroll Bar Change", sb);
			sb.value = val;
			sb.barSize = size;
			sb.alpha = alpha;
			NGUITools.SetDirty(sb);

			for (int i = 0; i < UIScrollView.list.size; ++i)
			{
				UIScrollView sv = UIScrollView.list[i];

				if (sv.horizontalScrollBar == sb || sv.verticalScrollBar == sb)
				{
					NGUIEditorTools.RegisterUndo("Scroll Bar Change", sv);
					sv.UpdatePosition();
				}
			}
		}
	}
}
