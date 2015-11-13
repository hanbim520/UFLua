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
/// When Drag & Drop event begins in UIDragDropItem, it will re-parent itself to the UIDragDropRoot instead.
/// It's useful when you're dragging something out of a clipped panel: you will want to reparent it before
/// it can be dragged outside.
/// </summary>

[AddComponentMenu("NGUI/Interaction/Drag and Drop Root")]
public class UIDragDropRoot : MonoBehaviour
{
	static public Transform root;

	void OnEnable () { root = transform; }
	void OnDisable () { if (root == transform) root = null; }
}
