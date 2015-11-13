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
#if UNITY_3_5
[CustomEditor(typeof(UIButtonKeys))]
#else
[CustomEditor(typeof(UIButtonKeys), true)]
#endif
public class UIButtonKeysEditor : UIKeyNavigationEditor
{
	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI();
		EditorGUILayout.HelpBox("This component has been replaced by UIKeyNavigation.", MessageType.Warning);

		if (GUILayout.Button("Auto-Upgrade"))
		{
			NGUIEditorTools.ReplaceClass(serializedObject, typeof(UIKeyNavigation));
			Selection.activeGameObject = null;
		}
	}
}
