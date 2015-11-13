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
[CustomEditor(typeof(UISnapshotPoint), true)]
public class UISnapshotPointEditor : Editor
{
	enum Type
	{
		Manual,
		Automatic,
	}

	Type mType = Type.Automatic;

	void OnEnable ()
	{
		mType = (target as UISnapshotPoint).thumbnail == null ? Type.Automatic : Type.Manual;
	}

	public override void OnInspectorGUI ()
	{
		mType = (Type)EditorGUILayout.EnumPopup("Type", mType);

		serializedObject.Update();

		if (mType == Type.Manual)
		{
			NGUIEditorTools.DrawProperty("Thumbnail", serializedObject, "thumbnail");
		}
		else
		{
			SerializedProperty sp = NGUIEditorTools.DrawProperty("Orthographic", serializedObject, "isOrthographic");

			if (sp.hasMultipleDifferentValues)
			{
				NGUIEditorTools.DrawProperty("Ortho Size", serializedObject, "orthoSize");
				NGUIEditorTools.DrawProperty("Field of View", serializedObject, "fieldOfView");
			}
			else if (sp.boolValue)
			{
				NGUIEditorTools.DrawProperty("Ortho Size", serializedObject, "orthoSize");
			}
			else NGUIEditorTools.DrawProperty("Field of View", serializedObject, "fieldOfView");

			NGUIEditorTools.DrawProperty("Near Clip", serializedObject, "nearClip");
			NGUIEditorTools.DrawProperty("Far Clip", serializedObject, "farClip");
		}

		serializedObject.ApplyModifiedProperties();

		GameObject prefab = GetPrefab();

		if (prefab == null)
		{
			EditorGUILayout.HelpBox("This script should be attached to a prefab that you expect to place into the Prefab Toolbar. " +
				"It simply makes it easier to adjust the snapshot camera's settings.", MessageType.Info);
		}
		else if (GUILayout.Button("Update Snapshot"))
		{
			// Invalidate this prefab's preview
			if (UIPrefabTool.instance != null)
			{
				UISnapshotPoint snapshot = target as UISnapshotPoint;

				if (snapshot.isOrthographic) target.name = "NGUI Snapshot Point " + snapshot.orthoSize;
				else target.name = "NGUI Snapshot Point " + snapshot.nearClip + " " + snapshot.farClip + " " + snapshot.fieldOfView;

				UIPrefabTool.instance.RegenerateTexture(prefab, snapshot);
				UIPrefabTool.instance.Repaint();
			}
		}
	}

	GameObject GetPrefab ()
	{
		UISnapshotPoint point = target as UISnapshotPoint;

		// Root object of this prefab instance
		Transform t = point.transform.parent;
		GameObject go = PrefabUtility.FindPrefabRoot(t == null ? point.gameObject : t.gameObject);
		if (go == null) return null;

		// Actual prefab
		return PrefabUtility.GetPrefabParent(go) as GameObject;
	}
}
