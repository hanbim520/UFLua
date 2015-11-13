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
using System.Collections;

/// <summary>
/// Simple script that shows how to download a remote texture and assign it to be used by a UITexture.
/// </summary>

[RequireComponent(typeof(UITexture))]
public class DownloadTexture : MonoBehaviour
{
	public string url = "http://www.yourwebsite.com/logo.png";
	public bool pixelPerfect = true;

	Texture2D mTex;

	IEnumerator Start ()
	{
		WWW www = new WWW(url);
		yield return www;
		mTex = www.texture;

		if (mTex != null)
		{
			UITexture ut = GetComponent<UITexture>();
			ut.mainTexture = mTex;
			if (pixelPerfect) ut.MakePixelPerfect();
		}
		www.Dispose();
	}

	void OnDestroy ()
	{
		if (mTex != null) Destroy(mTex);
	}
}
