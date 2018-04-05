using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActiveUserManagerScript : MonoBehaviour {

//	private int startPosY = (int)(Screen.height*0.12);
//	private int offsetY = 10;
//	private int height = (int)(Screen.height*0.06);
//	private int width = (int)(Screen.width*0.8);
	private string message = "";

	private C2SActiveUserPlugin activeUser = null;

	void Start(){
		StartCoroutine (StartAU ());
	}

	IEnumerator StartAU () {
		activeUser = new C2SActiveUserPlugin();

		message = "ActiveUser Version : " + activeUser.getVersion();

		activeUser.setLogged(true);
		activeUser.setUserAgreeCallback(gameObject.name, "UserAgreeCallback");
		activeUser.setActiveUserCallback(gameObject.name, "ActiveUserCallback");
		//		activeUser.setNoticePopupCallback (gameObject.name, "NoticePopupCallback");
		activeUser.setEnableUserAgreeUI(C2SActiveUserPlugin.USER_AGREE_COLOR_TYPE_BLACK);
		activeUser.setEnableRequestStoragePermission();
		yield return new WaitForSeconds (1.0f);
		activeUser.start ();

	}


	void OnApplicationPause(bool isPause){
		Debug.Log ("isPause : " + isPause);
	}

	void UserAgreeCallback(string msg) {
		Debug.Log("UserAgreeCallback msg : " + msg);
	}

	void ActiveUserCallback(string msg) {
		Debug.Log("ActiveUserCallback msg : " + msg);
		message = msg;
	}

	void NoticePopupCallback(string msg){
		Debug.Log ("NoticePopupCallback msg : " + msg);
		message = msg;
	}

	void NoticePopupInfoCallback(string msg){
		Debug.Log("NoticePopupInfoCallback msg : " + msg);
		message = msg;

		string tempMessage = message;
		Debug.Log ("message length : " + tempMessage.Length);
	}

//	int computePosY(int i)
//	{		
//		return startPosY + (height * i)+ offsetY;
//	}
	public void startWithoutNotice(){
		activeUser.startWithoutNotice (C2SActiveUserPluginInterface.STAGING_SERVER, true);
	}
	public void activeUserStart(){
		activeUser.start();
	}
	public void showUserAgreeTerms(){
		activeUser.showUserAgreeTerms();
	}
	public void getNoticePopupInfo(){
		activeUser.getNoticePopupInfo(gameObject.name, "NoticePopupInfoCallback");	// no more need to set 'serverId' (after 170811, ActiveUser v2.7.5)
	}
	public void showNotice(){
		activeUser.showNotice(gameObject.name, "NoticePopupCallback");	// no more need to set 'serverId' (after 170811, ActiveUser v2.7.5)
	}
	public void setServerID(){
		activeUser.setServerId("serverid_001");
	}
	public void setGameLanguage(){
		activeUser.setGameLanguage("ko");
	}
	public void setNetworkTimeoutSeconds(){
		activeUser.setNetworkTimeoutSeconds(7);
	}

	//	void OnGUI()
	//    {
	//		int i = 0;
	//		GUI.TextArea(new Rect(Screen.width/2 - width/2,computePosY(i++),width,height), message);
	//
	//		if(GUI.Button(new Rect(Screen.width/2 - width/2, computePosY(i++),width,height), "init 1")){
	//
	//			activeUser.startWithoutNotice(C2SActiveUserPluginInterface.STAGING_SERVER, true);
	//		}
	//
	//		if(GUI.Button(new Rect(Screen.width/2 - width/2, computePosY(i++),width,height), "init 2")){
	//
	//			activeUser.startWithoutNotice(C2SActiveUserPluginInterface.STAGING_SERVER, false);
	//		}
	//		if(GUI.Button(new Rect(Screen.width/2 - width/2, computePosY(i++),width,height), "init 3")){
	//
	//			activeUser.start();
	//		}
	//		if(GUI.Button(new Rect(Screen.width/2 - width/2,computePosY(i++),width,height), "showUserAgreeTerms()"))
	//		{
	//			activeUser.showUserAgreeTerms();
	//		}
	//
	//		if(GUI.Button(new Rect(Screen.width/2 - width/2, computePosY(i++),width,height), "getNoticeInfo()")){
	//			activeUser.getNoticePopupInfo(gameObject.name, "NoticePopupInfoCallback");	// no more need to set 'serverId' (after 170811, ActiveUser v2.7.5)
	//		}
	//		if(GUI.Button(new Rect(Screen.width/2 - width/2, computePosY(i++),width,height), "showNotice")){
	//			activeUser.showNotice(gameObject.name, "NoticePopupCallback");	// no more need to set 'serverId' (after 170811, ActiveUser v2.7.5)
	//		}
	//
	//		// added button 170811 (after ActiveUser v2.7.5)
	//		if(GUI.Button(new Rect(Screen.width/2 - width/2, computePosY(i++),width,height), "setServerId : serverid_001")){
	//			activeUser.setServerId("serverid_001");		// set 'serverId' using setServerId API
	//		}
	//		if(GUI.Button(new Rect(Screen.width/2 - width/2, computePosY(i++),width,height), "setServerId : serverid_002")){
	//			activeUser.setServerId("serverid_002");		// set 'serverId' using setServerId API
	//		}
	//		if(GUI.Button(new Rect(Screen.width/2 - width/2, computePosY(i++),width,height), "setGameLanguage : ko")){
	//			activeUser.setGameLanguage("ko");			// set 'gameLanguage' using setGameLanguage API
	//		}
	//		if(GUI.Button(new Rect(Screen.width/2 - width/2, computePosY(i++),width,height), "setGameLanguage : fr")){
	//			activeUser.setGameLanguage("fr");			// set 'gameLanguage' using setGameLanguage API
	//		}
	//
	//		// added button (end) 170811
	//		if(GUI.Button(new Rect(Screen.width/2 - width/2, computePosY(i++),width,height), "setNetworkTimeoutSeconds : 7")){
	//			activeUser.setNetworkTimeoutSeconds(7);			// set 'setNetworkTimeoutSeconds' using setNetworkTimeoutSeconds API
	//		}
	//
	//
	//		if(GUI.Button(new Rect(Screen.width/2 - width/2,computePosY(i++),width,height), "Exit"))
	//		{
	//			Application.Quit();
	//		}
	//	}
}
