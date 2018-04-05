/* This file must not be modified.
 * 2013-11-28 by hife
 * 2015-02-25 by TH Jo
 */

using UnityEngine;
using System.Collections;

public interface C2SOfferwallCallback {
	void onOfferwallCallback(int result);
}

public interface C2SOfferwallRewardCallback{
	void onOfferwallRewardCallback(int error, string errorMessage, int result, string eventID, string assetCode, int assetAmount);
}

public class C2SOfferwallPlugin : MonoBehaviour {
	
	// Callback result type
	public const int OFFERWALL_OPEN					= -11;
	public const int OFFERWALL_CLOSE				= -12;
	public const int OFFERWALL_ACTIVATION			= -14;
	public const int OFFERWALL_DEACTIVATION			= -15;
	
	// Rewawrd Callback
	public const int	OFFERWALL_REWARD_CANCEL         = 1;
	public const int	OFFERWALL_REWARD_FINISH         = 2;
	public const int	OFFERWALL_REWARD_IN_PROGRESS    = 3;
	public const int	OFFERWALL_REWARD_SUCCESS        = 4;
	
	private C2SOfferwallCallback 		offercallbackCB;
	private C2SOfferwallRewardCallback	offerwallRewardCallbackCB;
	
	
	#if !UNITY_ANDROID && UNITY_EDITOR
	public void createPlugin() {}
	public void initialize(string uid, bool isUsingStaging, C2SOfferwallCallback offerwallCallback) {}
	public void initializeEx(string uid, bool isUsingStaging, C2SOfferwallCallback offerwallCallback, C2SOfferwallRewardCallback	offerwallRewardCallback){} 
	public void show() {}
	public void showEx(string additionalInfo) {}
	public int getOfferwallState() {return 0;}
	public void setLogged(bool b) {}
	public string getVersion() {return "";}
	public void onActivityResumed() {}
	public void onActivityPaused() {}
	public void destroy() {}
	public void rewardFinish() {}
	#endif
	
	#if UNITY_ANDROID
	private AndroidJavaObject offerwallPlugin = null;	
	
	public void createPlugin() {
		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = jc.GetStatic<AndroidJavaObject>("currentActivity");
		
		offerwallPlugin = new AndroidJavaObject("com.com2us.module.offerwall.unityplugin.OfferwallUnityPlugin", currentActivity);
	}
	public void initialize(string uid, bool isUsingStaging, C2SOfferwallCallback offerwallCallback) {
		offercallbackCB = offerwallCallback;
		offerwallPlugin.Call("initializeBridge", uid, isUsingStaging, gameObject.name);
	}
	public void initializeEx(string uid, bool isUsingStaging, C2SOfferwallCallback offerwallCallback, C2SOfferwallRewardCallback offerwallRewardCallback) {
		offercallbackCB = offerwallCallback;
		offerwallRewardCallbackCB = offerwallRewardCallback;
		offerwallPlugin.Call("initializeBridge", uid, isUsingStaging, gameObject.name);
	}
	public void show() {
		offerwallPlugin.Call("show");
	}
	public void showEx(string additionalInfo) {
		offerwallPlugin.Call("showEx", additionalInfo);
	}
	public int getOfferwallState(){
		return offerwallPlugin.Call<int>("getOfferwallState");
	}
	public void setLogged(bool b) {
		offerwallPlugin.Call("setLogged", b);
	}
	public string getVersion() {
		return offerwallPlugin.Call<string>("getVersion");
	}
	public void onActivityResumed() {
		offerwallPlugin.Call("onActivityResumed");
	}
	public void onActivityPaused() {
		offerwallPlugin.Call("onActivityPaused");
	}
	public void destroy() {
		offerwallPlugin.Call("destroy");
	}
	public void rewardFinish() {
		offerwallPlugin.Call("rewardFinish");
	}
	#endif
	
	void offerwallCallbackBridge(string resultStr) {
		int result = int.Parse(resultStr);
		if(offercallbackCB != null) offercallbackCB.onOfferwallCallback(result);
	}
	
	void offerwallRewardCallbackBridge(string rewardInfoString){
		
		string[] strTokens;
		
		strTokens = ((string)rewardInfoString).Split('\t');
		Debug.Log ("strTokens.Length : " + strTokens.Length);
		
		int error 		= int.Parse(strTokens[0]);
		int result 		= int.Parse(strTokens[2]);
		int assetAmount = int.Parse(strTokens[5]);
		
		if(offerwallRewardCallbackCB != null) offerwallRewardCallbackCB.onOfferwallRewardCallback(error, strTokens[1], result, strTokens[3], strTokens[4], assetAmount);
	}
}