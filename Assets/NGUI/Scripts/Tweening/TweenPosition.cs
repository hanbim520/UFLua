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
/// Tween the object's position.
/// </summary>

[AddComponentMenu("NGUI/Tween/Tween Position")]
public class TweenPosition : UITweener
{
	public Vector3 from;
	public Vector3 to;

	[HideInInspector]
	public bool worldSpace = false;

	Transform mTrans;
	UIRect mRect;

	public Transform cachedTransform { get { if (mTrans == null) mTrans = transform; return mTrans; } }

	[System.Obsolete("Use 'value' instead")]
	public Vector3 position { get { return this.value; } set { this.value = value; } }

	/// <summary>
	/// Tween's current value.
	/// </summary>

	public Vector3 value
	{
		get
		{
			return worldSpace ? cachedTransform.position : cachedTransform.localPosition;
		}
		set
		{
			if (mRect == null || !mRect.isAnchored || worldSpace)
			{
				if (worldSpace) cachedTransform.position = value;
				else cachedTransform.localPosition = value;
			}
			else
			{
				value -= cachedTransform.localPosition;
				NGUIMath.MoveRect(mRect, value.x, value.y);
			}
		}
	}

	void Awake () { mRect = GetComponent<UIRect>(); }

	/// <summary>
	/// Tween the value.
	/// </summary>

	protected override void OnUpdate (float factor, bool isFinished) { value = from * (1f - factor) + to * factor; }

	/// <summary>
	/// Start the tweening operation.
	/// </summary>

	static public TweenPosition Begin (GameObject go, float duration, Vector3 pos)
	{
		TweenPosition comp = UITweener.Begin<TweenPosition>(go, duration);
		comp.from = comp.value;
		comp.to = pos;

		if (duration <= 0f)
		{
			comp.Sample(1f, true);
			comp.enabled = false;
		}
		return comp;
	}

	/// <summary>
	/// Start the tweening operation.
	/// </summary>

	static public TweenPosition Begin (GameObject go, float duration, Vector3 pos, bool worldSpace)
	{
		TweenPosition comp = UITweener.Begin<TweenPosition>(go, duration);
		comp.worldSpace = worldSpace;
		comp.from = comp.value;
		comp.to = pos;

		if (duration <= 0f)
		{
			comp.Sample(1f, true);
			comp.enabled = false;
		}
		return comp;
	}

	[ContextMenu("Set 'From' to current value")]
	public override void SetStartToCurrentValue () { from = value; }

	[ContextMenu("Set 'To' to current value")]
	public override void SetEndToCurrentValue () { to = value; }

	[ContextMenu("Assume value of 'From'")]
	void SetCurrentValueToStart () { value = from; }

	[ContextMenu("Assume value of 'To'")]
	void SetCurrentValueToEnd () { value = to; }
}
