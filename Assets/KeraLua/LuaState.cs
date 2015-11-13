using System;
using System.Collections.Generic;
using System.Text;
/** wine整理，Q710605420 UFLua 意为免费使用的unityLua，插件部分需要付费的，请自行付费，如有版权问题，整理者概不负责！Q群:479355429**/
namespace KeraLua
{
	public struct LuaState
	{
		public LuaState (IntPtr ptrState)
			: this ()
		{
			state = ptrState;
		}

		static public implicit operator LuaState (IntPtr ptr)
		{
			return new LuaState (ptr);
		}

		static public implicit operator IntPtr (LuaState luastate)
		{
			return luastate.state;
		}

		IntPtr state;
	}
}
