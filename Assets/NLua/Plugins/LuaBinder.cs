using UnityEngine;
using System.Collections;
using NLua;
using PluginsUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

class CallbackLuaFunction : NLua.Method.LuaDelegate
{
    void CallFunction()
    {
        object[] args = new object[] { };
        object[] inArgs = new object[] { };
        int[] outArgs = new int[] { };
        base.CallFunction(args, inArgs, outArgs);
    }
}
class CallbackLuaFunction<T> : NLua.Method.LuaDelegate
{
    void CallFunction(T arg1)
    {
        object[] args = new object[] { arg1 };
        object[] inArgs = new object[] { arg1 };
        int[] outArgs = new int[] { };
        base.CallFunction(args, inArgs, outArgs);
    }
}
class CallbackLuaFunction<T, U> : NLua.Method.LuaDelegate
{
    void CallFunction(T arg1, U arg2)
    {
        object[] args = new object[] { arg1, arg2 };
        object[] inArgs = new object[] { arg1, arg2 };
        int[] outArgs = new int[] { };
        base.CallFunction(args, inArgs, outArgs);
    }
}
class CallbackLuaFunction<T, U, V> : NLua.Method.LuaDelegate
{
    void CallFunction(T arg1, U arg2, V arg3)
    {
        object[] args = new object[] { arg1, arg2, arg3 };
        object[] inArgs = new object[] { arg1, arg2, arg3 };
        int[] outArgs = new int[] { };
        base.CallFunction(args, inArgs, outArgs);
    }
}
public class LuaBinder
{
    public static void RegisterNLuaDelegate(Lua context)
    {
        //Only For IOS 
        context.RegisterLuaDelegateType(typeof(EventTriggerListener.VoidDelegate), typeof(CallbackLuaFunction<GameObject>));

        context.RegisterLuaDelegateType(typeof(Action<object>), typeof(CallbackLuaFunction<object>));
        context.RegisterLuaDelegateType(typeof(Action), typeof(CallbackLuaFunction));
        context.RegisterLuaDelegateType(typeof(Callback), typeof(CallbackLuaFunction));
        context.RegisterLuaDelegateType(typeof(Callback<object>), typeof(CallbackLuaFunction<object>));
        context.RegisterLuaDelegateType(typeof(Callback<string, AssetBundle>), typeof(CallbackLuaFunction<string, AssetBundle>));
    }

}
