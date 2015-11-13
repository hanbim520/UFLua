/*
wine整理，Q710605420 UFLua 意为免费使用的unityLua，插件部分需要付费的，请自行付费，如有版权问题，整理者概不负责！Q群:479355429
插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;

/// <summary>
/// Attach this script to a child of a draggable window to make it tilt as it's dragged.
/// Look at how it's used in Example 6.
/// </summary>

[AddComponentMenu("NGUI/Examples/Window Drag Tilt")]
public class WindowDragTilt : MonoBehaviour
{
	public int updateOrder = 0;
	public float degrees = 30f;

	Vector3 mLastPos;
	Transform mTrans;
	float mAngle = 0f;

	void OnEnable ()
	{
		mTrans = transform;
		mLastPos = mTrans.position;
	}

	void Update ()
	{
		Vector3 deltaPos = mTrans.position - mLastPos;
		mLastPos = mTrans.position;

		mAngle += deltaPos.x * degrees;
		mAngle = NGUIMath.SpringLerp(mAngle, 0f, 20f, Time.deltaTime);

		mTrans.localRotation = Quaternion.Euler(0f, 0f, -mAngle);
	}
}
