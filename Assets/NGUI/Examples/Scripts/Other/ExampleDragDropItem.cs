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

[AddComponentMenu("NGUI/Examples/Drag and Drop Item (Example)")]
public class ExampleDragDropItem : UIDragDropItem
{
	/// <summary>
	/// Prefab object that will be instantiated on the DragDropSurface if it receives the OnDrop event.
	/// </summary>

	public GameObject prefab;

	/// <summary>
	/// Drop a 3D game object onto the surface.
	/// </summary>

	protected override void OnDragDropRelease (GameObject surface)
	{
		if (surface != null)
		{
			ExampleDragDropSurface dds = surface.GetComponent<ExampleDragDropSurface>();

			if (dds != null)
			{
				GameObject child = NGUITools.AddChild(dds.gameObject, prefab);
				child.transform.localScale = dds.transform.localScale;

				Transform trans = child.transform;
				trans.position = UICamera.lastWorldPosition;

				if (dds.rotatePlacedObject)
				{
					trans.rotation = Quaternion.LookRotation(UICamera.lastHit.normal) * Quaternion.Euler(90f, 0f, 0f);
				}
				
				// Destroy this icon as it's no longer needed
				NGUITools.Destroy(gameObject);
				return;
			}
		}
		base.OnDragDropRelease(surface);
	}
}
