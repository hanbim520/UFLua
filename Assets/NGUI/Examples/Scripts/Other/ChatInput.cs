/*
wine整理，Q710605420 UFLua 意为免费使用的unityLua，插件部分需要付费的，请自行付费，如有版权问题，整理者概不负责！Q群:479355429

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;

/// <summary>
/// Very simple example of how to use a TextList with a UIInput for chat.
/// </summary>

[RequireComponent(typeof(UIInput))]
[AddComponentMenu("NGUI/Examples/Chat Input")]
public class ChatInput : MonoBehaviour
{
	public UITextList textList;
	public bool fillWithDummyData = false;

	UIInput mInput;

	/// <summary>
	/// Add some dummy text to the text list.
	/// </summary>

	void Start ()
	{
		mInput = GetComponent<UIInput>();
		mInput.label.maxLineCount = 1;

		if (fillWithDummyData && textList != null)
		{
			for (int i = 0; i < 30; ++i)
			{
				textList.Add(((i % 2 == 0) ? "[FFFFFF]" : "[AAAAAA]") +
					"This is an example paragraph for the text list, testing line " + i + "[-]");
			}
		}
	}

	/// <summary>
	/// Submit notification is sent by UIInput when 'enter' is pressed or iOS/Android keyboard finalizes input.
	/// </summary>

	public void OnSubmit ()
	{
		if (textList != null)
		{
			// It's a good idea to strip out all symbols as we don't want user input to alter colors, add new lines, etc
			string text = NGUIText.StripSymbols(mInput.value);

			if (!string.IsNullOrEmpty(text))
			{
				textList.Add(text);
				mInput.value = "";
				mInput.isSelected = false;
			}
		}
	}
}
