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
/// Plays the specified sound.
/// </summary>

[AddComponentMenu("NGUI/Interaction/Play Sound")]
public class UIPlaySound : MonoBehaviour
{
	public enum Trigger
	{
		OnClick,
		OnMouseOver,
		OnMouseOut,
		OnPress,
		OnRelease,
		Custom,
		OnEnable,
		OnDisable,
	}

	public AudioClip audioClip;
	public Trigger trigger = Trigger.OnClick;

	[Range(0f, 1f)] public float volume = 1f;
	[Range(0f, 2f)] public float pitch = 1f;

	bool mIsOver = false;

	bool canPlay
	{
		get
		{
			if (!enabled) return false;
			UIButton btn = GetComponent<UIButton>();
			return (btn == null || btn.isEnabled);
		}
	}

	void OnEnable ()
	{
		if (trigger == Trigger.OnEnable)
			NGUITools.PlaySound(audioClip, volume, pitch);
	}

	void OnDisable ()
	{
		if (trigger == Trigger.OnDisable)
			NGUITools.PlaySound(audioClip, volume, pitch);
	}

	void OnHover (bool isOver)
	{
		if (trigger == Trigger.OnMouseOver)
		{
			if (mIsOver == isOver) return;
			mIsOver = isOver;
		}

		if (canPlay && ((isOver && trigger == Trigger.OnMouseOver) || (!isOver && trigger == Trigger.OnMouseOut)))
			NGUITools.PlaySound(audioClip, volume, pitch);
	}

	void OnPress (bool isPressed)
	{
		if (trigger == Trigger.OnPress)
		{
			if (mIsOver == isPressed) return;
			mIsOver = isPressed;
		}

		if (canPlay && ((isPressed && trigger == Trigger.OnPress) || (!isPressed && trigger == Trigger.OnRelease)))
			NGUITools.PlaySound(audioClip, volume, pitch);
	}

	void OnClick ()
	{
		if (canPlay && trigger == Trigger.OnClick)
			NGUITools.PlaySound(audioClip, volume, pitch);
	}

	void OnSelect (bool isSelected)
	{
		if (canPlay && (!isSelected || UICamera.currentScheme == UICamera.ControlScheme.Controller))
			OnHover(isSelected);
	}

	public void Play ()
	{
		NGUITools.PlaySound(audioClip, volume, pitch);
	}
}
