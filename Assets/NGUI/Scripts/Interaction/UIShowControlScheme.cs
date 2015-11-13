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
/// Show or hide the widget based on whether the control scheme is appropriate.
/// </summary>

public class UIShowControlScheme : MonoBehaviour
{
	public GameObject target;
	public bool mouse = false;
	public bool touch = false;
	public bool controller = true;

	void OnEnable () { UICamera.onSchemeChange += OnScheme; OnScheme(); }
	void OnDisable () { UICamera.onSchemeChange -= OnScheme; }

	void OnScheme ()
	{
		if (target != null)
		{
			UICamera.ControlScheme scheme = UICamera.currentScheme;
			if (scheme == UICamera.ControlScheme.Mouse) target.SetActive(mouse);
			else if (scheme == UICamera.ControlScheme.Touch) target.SetActive(touch);
			else if (scheme == UICamera.ControlScheme.Controller) target.SetActive(controller);
		}
	}
}
