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

[CustomEditor(typeof(ActiveAnimation))]
public class ActiveAnimationEditor : Editor
{
	public override void OnInspectorGUI ()
	{
		NGUIEditorTools.SetLabelWidth(80f);
		ActiveAnimation aa = target as ActiveAnimation;
		GUILayout.Space(3f);
		NGUIEditorTools.DrawEvents("On Finished", aa, aa.onFinished);
	}
}
