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
/// Simple example of an OnDrop event accepting a game object. In this case we check to see if there is a DragDropObject present,
/// and if so -- create its prefab on the surface, then destroy the object.
/// </summary>

[AddComponentMenu("NGUI/Examples/Drag and Drop Surface (Example)")]
public class ExampleDragDropSurface : MonoBehaviour
{
	public bool rotatePlacedObject = false;

	//void OnDrop (GameObject go)
	//{
	//    ExampleDragDropItem ddo = go.GetComponent<ExampleDragDropItem>();

	//    if (ddo != null)
	//    {
	//        GameObject child = NGUITools.AddChild(gameObject, ddo.prefab);

	//        Transform trans = child.transform;
	//        trans.position = UICamera.lastWorldPosition;
	//        if (rotatePlacedObject) trans.rotation = Quaternion.LookRotation(UICamera.lastHit.normal) * Quaternion.Euler(90f, 0f, 0f);
	//        Destroy(go);
	//    }
	//}
}
