// C2SActiveUserPlugin.cs version - 2012/09/07
// C2SActiveUserPlugin.cs version - 2013/02/22
// C2SActiveUserPlugin.cs version - 2013/08/06
// C2SActiveUserPlugin.cs version - 2013/09/06
// 2016-01-04 for SandBox (kjkim)
// 2016-01-06 for modified startEx() (UNITY_ANDROID)
// 2016-01-08 for added setEnableRequestStoragePermission() (UNITY_ANDROID)
// 2017-08-11 for added setServerId(), setGameLanguage() / modified showNotice(), getNoticeInfo() : removed parameter 'serverId'
// 2017-12-07 for added setNetworkTimeoutSeconds()

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public abstract class C2SActiveUserPluginInterface : C2SCommonPluginInterface
{

	public const int USER_AGREE_SUCCESS = 0;
	public const int USER_AGREE_TERMS_CLOSE = 1;
	// for iOS

	public const int ACTIVE_USER_GETDID_SUCCESS = 0;
	public const int ACTIVE_USER_GETDID_FAIL = 1;

	public const int USER_AGREE_COLOR_TYPE_WHITE = 0;
	public const int USER_AGREE_COLOR_TYPE_BLACK = 1;

	// for SandBox
	public const int LIVE_SERVER = 0;
	public const int STAGING_SERVER = 1;
	public const int SANDBOX_SERVER = 2;

	public const int POPUP_SHOW = 0;
	public const int POPUP_NOTSHOW = 1;

	// Function
	public abstract void useTestServer ();

	public abstract void start ();

	public abstract void startEx (int serverState);

	public abstract void startWithoutNotice(int serverState, bool showNoticePopup);

	public abstract string getVersion ();

	public abstract void setLogged (bool isLogged);

	public abstract string getDID ();

	public abstract void setUserAgreeCallback (string unityObjName, string unityFuncName);

	public abstract void setActiveUserCallback (string unityObjName, string unityFuncName);

	public abstract void setEnableUserAgreeUI ();

	public abstract void setEnableUserAgreeUI (int colorType);

	public abstract void showUserAgreeTerms ();

	public abstract void showUserAgreeTerms (string url);

	public abstract void resetUserAgree ();
	// for Android
	public abstract void onApplicationResumed ();
	// for Android
	public abstract void onApplicationPaused ();
	// for Android
	public abstract void setEnableRequestStoragePermission ();
    // modified 170811
	public abstract void showNotice (string unityObjName, string unityFuncName);
	// modified 170811
	public abstract void getNoticePopupInfo (string unityObjName, string unityFuncName);
	// added 170811
	public abstract void setServerId (string serverId);
	// added 170811
	public abstract void setGameLanguage (string gameLanguage);
	// added 171207
	public abstract void setNetworkTimeoutSeconds (int seconds);


	#if !UNITY_EDITOR && UNITY_IPHONE
	[DllImport ("__Internal")]
	public static extern void CS_ActiveUserUseTestServer();
	[DllImport ("__Internal")]
	public static extern void CS_ActiveUserStart();
	[DllImport ("__Internal")]
	public static extern void CS_ActiveUserStartEx(int serverState);
	[DllImport ("__Internal")]
	public static extern void CS_ActiveUserStartWithoutNotice(int serverState, bool showNoticePopup);
	[DllImport ("__Internal")]
	public static extern System.IntPtr CS_ActiveUserUnityGetVersion() ;

	[DllImport ("__Internal")]
	public static extern void CS_ActiveUserSetLogged(int isLogged);
	[DllImport ("__Internal")]
	public static extern System.IntPtr CS_ActiveUserGetDID();

	[DllImport ("__Internal")]
	public static extern void CS_UserAgreeUnitySetCallback(string unityObjName, string unityFuncName);
	[DllImport ("__Internal")]
	public static extern void CS_ActiveUserUnitySetCallback(string unityObjName, string unityFuncName);
	[DllImport ("__Internal")]
	public static extern void CS_UserAgreeUnityShowUI();
	[DllImport ("__Internal")]
	public static extern void CS_UserAgreeUnityShowUIEx(int colorType);
	[DllImport ("__Internal")]
	public static extern void CS_UserAgreeUnityShowTermsUI();
	[DllImport ("__Internal")]
	public static extern void CS_UserAgreeReset();
	[DllImport ("__Internal")]
	public static extern void CS_UserAgreeUnityShowTermsUIEx(string url);
	[DllImport ("__Internal")]
	public static extern void CS_UpdateNoticeUnityShowNoticePopup(string unityObjName, string unityFuncName);
	[DllImport ("__Internal")]
	public static extern void CS_UpdateNoticeUnityGetPopupInfo(string unityObjName, string unityFuncName);
	
    [DllImport ("__Internal")]
	public static extern void CS_UnitySetServerId(string serverid);
	[DllImport ("__Internal")]
	public static extern void CS_UnitySetGameLanguage(string gameLanguage);
	[DllImport ("__Internal")]
	public static extern void CS_UnitySetMinTimeoutSeconds(int seconds);
	#endif
}

public class C2SActiveUserPlugin : C2SActiveUserPluginInterface
{

#if UNITY_EDITOR || (!UNITY_IPHONE && !UNITY_ANDROID)
	public C2SActiveUserPlugin()
	{
	}

	public override void useTestServer()
	{
	}

	public override void start()
	{
	}

	public override void startEx(int serverState)
	{
	}

	public override void startWithoutNotice(int serverState, bool showNoticePopup)
	{
	}

	public override string getVersion()
	{
		return "";
	}

	public override void setLogged(bool isLogged)
	{
	}

	public override string getDID()
	{
		return "";
	}

	public override void setUserAgreeCallback(string unityObjName, string unityFuncName)
	{
	}

	public override void setActiveUserCallback(string unityObjName, string unityFuncName)
	{
	}

	public override void setEnableUserAgreeUI()
	{
	}

	public override void setEnableUserAgreeUI(int colorType)
	{
	}

	public override void showUserAgreeTerms()
	{
	}

	public override void showUserAgreeTerms(string url)
	{
	}

	public override void resetUserAgree()
	{
	}

	public override void onApplicationResumed()
	{
	}

	public override void onApplicationPaused()
	{
	}

	public override void setEnableRequestStoragePermission()
	{
	}
	// modified 170811
	public override void showNotice(string unityObjName, string unityFuncName)
	{
	}
	// modified 170811
	public override void getNoticePopupInfo(string unityObjName, string unityFuncName)
	{
	}
	// added 170811
	public override void setServerId(string serverId)
	{
	}
	// added 170811
	public override void setGameLanguage(string gameLanguage)
	{
	}
	// added 171207
	public override void setNetworkTimeoutSeconds(int seconds)
	{
	}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
	private AndroidJavaObject activeUser = null;

	public C2SActiveUserPlugin() {

	AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
	AndroidJavaObject currentActivity = jc.GetStatic<AndroidJavaObject>("currentActivity");

	activeUser = new AndroidJavaObject("com.com2us.module.activeuser.plugin.ActiveUserPlugin", currentActivity);
	}

	public override void useTestServer() {
	activeUser.Call("useTestServer");
	}

	public override void start()
	{
	activeUser.Call("start");
	}

	public override void startEx(int serverState)
	{
	AndroidJavaClass cls_modulemanager = new AndroidJavaClass("com.com2us.module.manager.ModuleManager$SERVER_STATE");
	AndroidJavaObject obj_serverstate;
	switch(serverState) {
	case STAGING_SERVER:
	obj_serverstate = cls_modulemanager.GetStatic<AndroidJavaObject>("STAGING_SERVER");
	break;
	case SANDBOX_SERVER:
	obj_serverstate = cls_modulemanager.GetStatic<AndroidJavaObject>("SANDBOX_SERVER");
	break;
	case LIVE_SERVER:
	default:
	obj_serverstate = cls_modulemanager.GetStatic<AndroidJavaObject>("LIVE_SERVER");
	break;
	}

	activeUser.Call("start", obj_serverstate);
	}

	public override void startWithoutNotice(int serverState, bool showNoticePopup){
	AndroidJavaClass cls_modulemanager = new AndroidJavaClass("com.com2us.module.manager.ModuleManager$SERVER_STATE");
	AndroidJavaObject obj_serverstate;
	switch(serverState) {
	case STAGING_SERVER:
	obj_serverstate = cls_modulemanager.GetStatic<AndroidJavaObject>("STAGING_SERVER");
	break;
	case SANDBOX_SERVER:
	obj_serverstate = cls_modulemanager.GetStatic<AndroidJavaObject>("SANDBOX_SERVER");
	break;
	case LIVE_SERVER:
	default:
	obj_serverstate = cls_modulemanager.GetStatic<AndroidJavaObject>("LIVE_SERVER");
	break;
	}

	activeUser.Call("start", obj_serverstate, showNoticePopup);
	}

	public override string getVersion()
	{
	return activeUser.Call<string>("getVersion");
	}

	public override void setLogged(bool isLogged)
	{
	activeUser.Call("setLogged", isLogged);
	}

	public override string getDID() {
	return activeUser.CallStatic<string>("getDID");
	}

	public override void setUserAgreeCallback(string unityObjName, string unityFuncName)
	{
	activeUser.Call ("setUnityUserAgreeCallback", unityObjName, unityFuncName);
	}

	public override void setActiveUserCallback(string unityObjName, string unityFuncName) 
	{
	activeUser.Call ("setUnityActiveUserCallback", unityObjName, unityFuncName);
	}

	public override void setEnableUserAgreeUI()
	{
	activeUser.Call("setEnableUserAgreeUI");
	}

	public override void setEnableUserAgreeUI(int colorType)
	{
	activeUser.Call("setEnableUserAgreeUI", colorType);
	}

	public override void showUserAgreeTerms()
	{
	activeUser.Call("showUserAgreeTerms");
	}

	public override void showUserAgreeTerms(string url)
	{
	activeUser.Call("showUserAgreeTerms", url);
	}

	public override void resetUserAgree()
	{
	activeUser.Call("resetUserAgree");
	}

	public override void onApplicationResumed() {
	activeUser.Call("onActivityStarted");
	}

	public override void onApplicationPaused() {
	activeUser.Call("onActivityStopped");
	}

	public override void setEnableRequestStoragePermission () {		
	activeUser.Call("setEnableRequestStoragePermission");
	}
	// modified 170811
	public override void showNotice(string unityObjName, string unityFuncName){
	activeUser.Call("showUnityNoticePopup", unityObjName, unityFuncName);
	}
	// modified 170811
	public override void getNoticePopupInfo(string unityObjName, string unityFuncName){
	activeUser.Call("getUnityNoticePopupInfo", unityObjName, unityFuncName);
	}
	// added 170811
	public override void setServerId (string serverId){
	activeUser.Call("setServerId", serverId);
	}
	// added 170811
	public override void setGameLanguage(string gameLanguage){
	activeUser.Call("setGameLanguage", gameLanguage);
	}
	// added 171207
	public override void setNetworkTimeoutSeconds(int seconds){
	activeUser.Call("setNetworkTimeoutSeconds", seconds);
	}

#endif

#if !UNITY_EDITOR && UNITY_IPHONE
	public C2SActiveUserPlugin() {

	}

	public override void useTestServer() {
	CS_ActiveUserUseTestServer();
	}

	public override void start()
	{
	CS_ActiveUserStart();
	}

	public override void startEx(int serverState)
	{
	CS_ActiveUserStartEx(serverState);
	}

	public override void startWithoutNotice(int serverState, bool showNoticePopup)
	{
	CS_ActiveUserStartWithoutNotice(serverState, showNoticePopup);
	}

	public override string getVersion()
	{
	return Marshal.PtrToStringAnsi(CS_ActiveUserUnityGetVersion());
	}

	public override void setLogged(bool isLogged)
	{
	CS_ActiveUserSetLogged(isLogged==true?1:0);
	}

	public override string getDID() {
	return Marshal.PtrToStringAnsi(CS_ActiveUserGetDID());
	}

	public override void setUserAgreeCallback(string unityObjName, string unityFuncName)
	{
	CS_UserAgreeUnitySetCallback(unityObjName, unityFuncName);
	}

	public override void setActiveUserCallback(string unityObjName, string unityFuncName) 
	{
	CS_ActiveUserUnitySetCallback(unityObjName, unityFuncName);
	}

	public override void setEnableUserAgreeUI() {
	CS_SetModuleView();
	CS_UserAgreeUnityShowUI();
	}

	public override void setEnableUserAgreeUI(int colorType) {
	CS_SetModuleView();
	CS_UserAgreeUnityShowUIEx(colorType);
	}

	public override void showUserAgreeTerms() {
	CS_SetModuleView();
	CS_UserAgreeUnityShowTermsUI();
	}

	public override void showUserAgreeTerms(string url)
	{
	CS_SetModuleView();
	CS_UserAgreeUnityShowTermsUIEx(url);
	}

	public override void resetUserAgree() {
	CS_UserAgreeReset();
	}

	public override void onApplicationResumed() {

	}

	public override void onApplicationPaused() {

	}

	public override void setEnableRequestStoragePermission () {		

	}
	// modified 170811
	public override void showNotice(string unityObjName, string unityFuncName){
	CS_UpdateNoticeUnityShowNoticePopup(unityObjName ,unityFuncName);
	}
	// modified 170811
	public override void getNoticePopupInfo(string unityObjName, string unityFuncName){
	CS_UpdateNoticeUnityGetPopupInfo(unityObjName, unityFuncName);
	}
	// added 170811
	public override void setServerId(string serverId){
	CS_UnitySetServerId(serverId);
	}
	// added 170811
	public override void setGameLanguage(string gameLanguage){
	CS_UnitySetGameLanguage(gameLanguage);
	}
	// added 171207
	public override void setNetworkTimeoutSeconds(int seconds){
	CS_UnitySetMinTimeoutSeconds(seconds);
	}

	#endif

}
