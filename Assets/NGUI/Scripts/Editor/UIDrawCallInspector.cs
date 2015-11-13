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

/// <summary>
/// Inspector class used to view UIDrawCalls.
/// </summary>

[CustomEditor(typeof(UIDrawCall))]
public class UIDrawCallInspector : Editor
{
	/// <summary>
	/// Draw the inspector widget.
	/// </summary>

	public override void OnInspectorGUI ()
	{
		if (Event.current.type == EventType.Repaint || Event.current.type == EventType.Layout)
		{
			UIDrawCall dc = target as UIDrawCall;

			if (dc.manager != null)
			{
				EditorGUILayout.LabelField("Render Queue", dc.renderQueue.ToString());
				EditorGUILayout.LabelField("Owner Panel", NGUITools.GetHierarchy(dc.manager.gameObject));
				EditorGUILayout.LabelField("Triangles", dc.triangles.ToString());
			}
			else if (Event.current.type == EventType.Repaint)
			{
				Debug.LogWarning("Orphaned UIDrawCall detected!\nUse [Selection -> Force Delete] to get rid of it.");
			}
		}
	}
}
