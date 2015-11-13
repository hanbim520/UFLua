/*
wine整理，Q710605420 UFLua 意为免费使用的unityLua，插件部分需要付费的，请自行付费，如有版权问题，整理者概不负责！Q群:479355429
插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;

/// <summary>
/// Want something to spin? Attach this script to it. Works equally well with rigidbodies as without.
/// </summary>

[AddComponentMenu("NGUI/Examples/Spin")]
public class Spin : MonoBehaviour
{
	public Vector3 rotationsPerSecond = new Vector3(0f, 0.1f, 0f);
	public bool ignoreTimeScale = false;

	Rigidbody mRb;
	Transform mTrans;

	void Start ()
	{
		mTrans = transform;
		mRb = GetComponent<Rigidbody>();
	}

	void Update ()
	{
		if (mRb == null)
		{
			ApplyDelta(ignoreTimeScale ? RealTime.deltaTime : Time.deltaTime);
		}
	}

	void FixedUpdate ()
	{
		if (mRb != null)
		{
			ApplyDelta(Time.deltaTime);
		}
	}

	public void ApplyDelta (float delta)
	{
		delta *= Mathf.Rad2Deg * Mathf.PI * 2f;
		Quaternion offset = Quaternion.Euler(rotationsPerSecond * delta);

		if (mRb == null)
		{
			mTrans.rotation = mTrans.rotation * offset;
		}
		else
		{
			mRb.MoveRotation(mRb.rotation * offset);
		}
	}
}
