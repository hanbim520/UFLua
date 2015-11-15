using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using NLua;
using System.IO;
using PluginsUI;
using ITween;

/** wine整理，Q710605420 UFLua 意为免费使用的unityLua，插件部分需要付费的，请自行付费，如有版权问题，整理者概不负责！Q群:479355429**/
public class ExampleBehaviour : MonoBehaviour {
    
    Lua env;
    public GameObject cube;
    public Text text;
    public Button btnObj;
    public GameObject Sphere;
    bool isLoadFinished = false;
    static string getPath()
    {
#if UNITY_ANDROID
        { return Application.streamingAssetsPath + "/"; }
#elif UNITY_IPHONE
		{ return "file://" +Application.streamingAssetsPath + "/"; }
#elif UNITY_STANDALONE_WIN || UNITY_EDITOR
        { return "file:///" + Application.streamingAssetsPath + "/"; }
#else
       return string.Empty;
#endif
    }
    IEnumerator loadLua()
    {
        isLoadFinished = false;
        WWW www = new WWW(getPath() + "/example.lua");
        yield return www;
        if(www.error != null)
        {
            yield break;
        }

        string source =  www.text;
        try
        {
            env.DoString(source);
#if UNITY_IPHONE
            LuaBinder.RegisterNLuaDelegate(env);
#endif
        }
        catch (NLua.Exceptions.LuaException e)
        {
            Debug.LogError(FormatException(e), gameObject);
        }
        isLoadFinished = true;
        Call("Start");
        Debug.Log("Start");
    }

    void Awake() {
		env = new Lua();
		env.LoadCLRPackage();
		
		env["this"] = this; // Give the script access to the gameobject.
		env["transform"] = transform;
        env["cube"] = cube;
        env["btnObj"] = btnObj;
        env["Sphere"] = Sphere;
        StartCoroutine(loadLua());
               
	}

	void Start () {
//         for (int i = 0; i < 10; i++)
//         {
//             GameObject go = GameObject.Instantiate(cube);
//             go.transform.parent = null;
//         }
    }
	
	void Update () {
		Call("Update");

//         Vector3 b = Sphere.transform.forward;
//         Sphere.GetComponent<Rigidbody>().AddForce(new Vector3(b.x,b.y * (-10),b.z));
	}

	void OnGUI() {
		Call("OnGUI");
	}

	public System.Object[] Call(string function, params System.Object[] args) {
		System.Object[] result = new System.Object[0];
        if (env == null && !isLoadFinished) return result;
		LuaFunction lf = env.GetFunction(function);
		if(lf == null) return result;
		try {
			// Note: calling a function that does not 
			// exist does not throw an exception.
			if(args != null) {
				result = lf.Call(args);
			} else {
				result = lf.Call();
			}
		} catch(NLua.Exceptions.LuaException e) {
			Debug.LogError(FormatException(e), gameObject);
		}
		return result;
	}

	public System.Object[] Call(string function) {
		return Call(function, null);
	}

	public static string FormatException(NLua.Exceptions.LuaException e) {
		string source = (string.IsNullOrEmpty(e.Source)) ? "<no source>" : e.Source.Substring(0, e.Source.Length - 2);
		return string.Format("{0}\nLua (at {2})", e.Message, string.Empty, source);
	}
}
