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
/// This script can be used to restrict camera rendering to a specific part of the screen by specifying the two corners.
/// </summary>

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("NGUI/UI/Viewport Camera")]
public class UIViewport : MonoBehaviour
{
	public Camera sourceCamera;
	public Transform topLeft;
	public Transform bottomRight;
	public float fullSize = 1f;

	Camera mCam;

	void Start ()
	{
#if UNITY_4_3 || UNITY_4_5 || UNITY_4_6
		mCam = camera;
#else
		mCam = GetComponent<Camera>();
#endif
		if (sourceCamera == null) sourceCamera = Camera.main;
	}

	void LateUpdate ()
	{
		if (topLeft != null && bottomRight != null)
		{
			if (topLeft.gameObject.activeInHierarchy)
			{
				Vector3 tl = sourceCamera.WorldToScreenPoint(topLeft.position);
				Vector3 br = sourceCamera.WorldToScreenPoint(bottomRight.position);

				Rect rect = new Rect(tl.x / Screen.width, br.y / Screen.height,
					(br.x - tl.x) / Screen.width, (tl.y - br.y) / Screen.height);

				float size = fullSize * rect.height;

				if (rect != mCam.rect) mCam.rect = rect;
				if (mCam.orthographicSize != size) mCam.orthographicSize = size;
				mCam.enabled = true;
			}
			else mCam.enabled = false;
		}
	}
}
