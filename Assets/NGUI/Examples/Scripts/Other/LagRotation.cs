/*
wine整理，Q710605420 UFLua 意为免费使用的unityLua，插件部分需要付费的，请自行付费，如有版权问题，整理者概不负责！Q群:479355429

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;

/// <summary>
/// Attach to a game object to make its rotation always lag behind its parent as the parent rotates.
/// </summary>

[AddComponentMenu("NGUI/Examples/Lag Rotation")]
public class LagRotation : MonoBehaviour
{
	public float speed = 10f;
	public bool ignoreTimeScale = false;

	Transform mTrans;
	Quaternion mRelative;
	Quaternion mAbsolute;

	public void OnRepositionEnd ()
	{
		Interpolate(1000f);
	}

	void Interpolate (float delta)
	{
		if (mTrans != null)
		{
			Transform parent = mTrans.parent;

			if (parent != null)
			{
				mAbsolute = Quaternion.Slerp(mAbsolute, parent.rotation * mRelative, delta * speed);
				mTrans.rotation = mAbsolute;
			}
		}
	}

	void Start ()
	{
		mTrans = transform;
		mRelative = mTrans.localRotation;
		mAbsolute = mTrans.rotation;
	}

	void Update ()
	{
		Interpolate(ignoreTimeScale ? RealTime.deltaTime : Time.deltaTime);
	}
}
