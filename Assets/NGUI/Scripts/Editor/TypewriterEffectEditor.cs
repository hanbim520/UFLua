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
[CustomEditor(typeof(TypewriterEffect))]
public class TypewriterEffectEditor : Editor
{
	public override void OnInspectorGUI ()
	{
		GUILayout.Space(6f);
		NGUIEditorTools.SetLabelWidth(120f);

		serializedObject.Update();

		NGUIEditorTools.DrawProperty(serializedObject, "charsPerSecond");
		NGUIEditorTools.DrawProperty(serializedObject, "fadeInTime");
		NGUIEditorTools.DrawProperty(serializedObject, "delayOnPeriod");
		NGUIEditorTools.DrawProperty(serializedObject, "delayOnNewLine");
		NGUIEditorTools.DrawProperty(serializedObject, "scrollView");
		NGUIEditorTools.DrawProperty(serializedObject, "keepFullDimensions");

		TypewriterEffect tw = target as TypewriterEffect;
		NGUIEditorTools.DrawEvents("On Finished", tw, tw.onFinished);

		serializedObject.ApplyModifiedProperties();
	}
}
