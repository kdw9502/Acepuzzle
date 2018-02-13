using UnityEngine;

//using for DllImport
using System.Runtime.InteropServices;


public class GoogleLoginScript : MonoBehaviour 
{
	
	static GoogleLoginScript _instance;
	public static string strLog = "sample";
#if UNITY_IOS
	[DllImport("__Internal")]

	private static extern void 	iOSPluginOpenGoogle();
	private static extern string iOSGetNameFromGoogle();
#endif 
#if UNITY_ANDROID
	private AndroidJavaObject curActivity;

#endif
	public static GoogleLoginScript GetInstance()
	{
		if( _instance == null )
		{
			_instance = new GoogleLoginScript();
		}
		return _instance;
	}
	void Awake()
	{
		GoogleLoginScript.GetInstance ();
#if UNITY_ANDROID
		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		curActivity = jc.GetStatic<AndroidJavaObject>("currentActivity");
#endif

	}
	public void openGoogleLogin(){
#if UNITY_IOS
		CalliOSFunc ();
#endif 

#if UNITY_ANDROID
		CallJavaFunc("signIn");
#endif
	}
#if UNITY_IOS
	public void CalliOSFunc()
	{
		Debug.Log("UnityLog1");

		iOSPluginOpenGoogle();
		iOSGetNameFromGoogle ();

		Debug.Log("UnityLog2");
	}
#endif 
#if UNITY_ANDROID
	public void CallJavaFunc( string strFuncName )
	{
		if( curActivity == null )
			return;
		curActivity.Call( strFuncName);
	}

#endif
}
