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

[CustomEditor(typeof(UIScrollView))]
public class UIScrollViewEditor : Editor
{
	public override void OnInspectorGUI ()
	{
		NGUIEditorTools.SetLabelWidth(130f);

		GUILayout.Space(3f);
		serializedObject.Update();

		SerializedProperty sppv = serializedObject.FindProperty("contentPivot");
		UIWidget.Pivot before = (UIWidget.Pivot)sppv.intValue;

		NGUIEditorTools.DrawProperty("Content Origin", sppv, false);

		SerializedProperty sp = NGUIEditorTools.DrawProperty("Movement", serializedObject, "movement");

		if (((UIScrollView.Movement)sp.intValue) == UIScrollView.Movement.Custom)
		{
			NGUIEditorTools.SetLabelWidth(20f);

			GUILayout.BeginHorizontal();
			GUILayout.Space(114f);
			NGUIEditorTools.DrawProperty("X", serializedObject, "customMovement.x", GUILayout.MinWidth(20f));
			NGUIEditorTools.DrawProperty("Y", serializedObject, "customMovement.y", GUILayout.MinWidth(20f));
			GUILayout.EndHorizontal();
		}

		NGUIEditorTools.SetLabelWidth(130f);

		NGUIEditorTools.DrawProperty("Drag Effect", serializedObject, "dragEffect");
		NGUIEditorTools.DrawProperty("Scroll Wheel Factor", serializedObject, "scrollWheelFactor");
		NGUIEditorTools.DrawProperty("Momentum Amount", serializedObject, "momentumAmount");

		NGUIEditorTools.DrawProperty("Restrict Within Panel", serializedObject, "restrictWithinPanel");
		NGUIEditorTools.DrawProperty("Cancel Drag If Fits", serializedObject, "disableDragIfFits");
		NGUIEditorTools.DrawProperty("Smooth Drag Start", serializedObject, "smoothDragStart");
		NGUIEditorTools.DrawProperty("IOS Drag Emulation", serializedObject, "iOSDragEmulation");

		NGUIEditorTools.SetLabelWidth(100f);

		if (NGUIEditorTools.DrawHeader("Scroll Bars"))
		{
			NGUIEditorTools.BeginContents();
			NGUIEditorTools.DrawProperty("Horizontal", serializedObject, "horizontalScrollBar");
			NGUIEditorTools.DrawProperty("Vertical", serializedObject, "verticalScrollBar");
			NGUIEditorTools.DrawProperty("Show Condition", serializedObject, "showScrollBars");
			NGUIEditorTools.EndContents();
		}
		serializedObject.ApplyModifiedProperties();

		if (before != (UIWidget.Pivot)sppv.intValue)
		{
			(target as UIScrollView).ResetPosition();
		}
	}
}
