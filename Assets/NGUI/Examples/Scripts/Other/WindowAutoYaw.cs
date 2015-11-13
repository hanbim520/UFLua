/*
wine整理，Q710605420 UFLua 意为免费使用的unityLua，插件部分需要付费的，请自行付费，如有版权问题，整理者概不负责！Q群:479355429
插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;

/// <summary>
/// Attaching this script to an object will make it turn as it gets closer to left/right edges of the screen.
/// Look at how it's used in Example 6.
/// </summary>

[AddComponentMenu("NGUI/Examples/Window Auto-Yaw")]
public class WindowAutoYaw : MonoBehaviour
{
	public int updateOrder = 0;
	public Camera uiCamera;
	public float yawAmount = 20f;

	Transform mTrans;

	void OnDisable ()
	{
		mTrans.localRotation = Quaternion.identity;
	}

	void OnEnable ()
	{
		if (uiCamera == null) uiCamera = NGUITools.FindCameraForLayer(gameObject.layer);
		mTrans = transform;
	}

	void Update ()
	{
		if (uiCamera != null)
		{
			Vector3 pos = uiCamera.WorldToViewportPoint(mTrans.position);
			mTrans.localRotation = Quaternion.Euler(0f, (pos.x * 2f - 1f) * yawAmount, 0f);
		}
	}
}
