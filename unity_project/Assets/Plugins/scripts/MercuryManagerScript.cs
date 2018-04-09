using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercuryManagerScript : MonoBehaviour {

	static string uid = "1234343423";

	public static C2SMercuryPlugin mercuryPlugin;
	static MercuryCB mercuryCB;
	static MercuryCBWithData mercuryCBWithData;

	class MercuryCB : IMercuryCallback
	{
		public void onMercuryResult (int result)
		{
			Debug.Log ("Result : " + result);
		}
	}

	class MercuryCBWithData : IMercuryCallbackWithData
	{
		public void onMercuryResultWithData (int result, string jsonData)
		{
			Debug.Log ("Result : " + result);
			Debug.Log ("JsonData : " + jsonData);
		}
	}


	void Start ()
	{
		mercuryCB = new MercuryCB ();
		mercuryCBWithData = new MercuryCBWithData ();
		mercuryPlugin = gameObject.AddComponent<C2SMercuryPlugin> ();
		mercuryPlugin.createPlugin ();
		mercuryPlugin.setLog (true);
		#if !IOS_SIMULATOR
		mercuryPlugin.setCallback ( mercuryCB );	
		#endif
		mercuryPlugin.setIsUsingStaging (true); //true -> use test server, false -> use real server
		mercuryPlugin.setUid (uid);
		//GetBadge ();
	}


	void OnApplicationPause (bool isPause)
	{
		
		if (mercuryPlugin == null)
			return;
		
		if (isPause)
			mercuryPlugin.setPaused ();
		else
			mercuryPlugin.setResumed ();
		ShowReviewPopup ();
	}

	public void ShowEx(){
		Debug.Log ("I'm your Show Notice Top Button click!");
		mercuryPlugin.mercuryShowEx (uid, C2SMercuryPlugin.MERCURY_SHOW_NOTICE_TOP, "{arm:korea-server}");
	}
	public void ForcedShowEx(){
		Debug.Log ("I'm your Forced Show Notice Top Button click!");
		mercuryPlugin.mercuryShowEx (uid, C2SMercuryPlugin.MERCURY_SHOW_FORCED_NOTICE_TOP, "{arm:korea-server}");
	}
	public void ShowNoticeOnly(){
		Debug.Log ("I'm your Only Notice Button click!");
		mercuryPlugin.mercuryShowEx (uid, C2SMercuryPlugin.MERCURY_SHOW_NOTICE_ONLY, "{arm:korea-server}");
	}
	public void GetCustomViewInfo(){
		Debug.Log ("I'm your Get Custom View Info Button click!");
		mercuryPlugin.mercuryGetCustomViewInfo (uid, C2SMercuryPlugin.MERCURY_SHOW_NOTICE_ONLY, mercuryCBWithData);
	}
	public void ShowEvents(){
		Debug.Log ("I'm your Event Show Button click!");
		mercuryPlugin.mercuryShowEx (uid, C2SMercuryPlugin.MERCURY_SHOW_EVENT, "{arm:korea-server}");
	}

	//void CS_MercuryGetBadge(const int badgeTarget)
	public void GetBadge(){
		Debug.Log ("I'm your Get Badge Button click!");
		mercuryPlugin.mercuryGetBadge (C2SMercuryPlugin.MERCURY_BADGE_FOR_EVENT);
		mercuryPlugin.mercuryGetBadge (C2SMercuryPlugin.MERCURY_BADGE_FOR_NOTICE);
	}
	//int CS_MercuryShowReviewPopup(const char* uid, const char* vid, const char* did)
	public void ShowReviewPopup(){
		Debug.Log ("I'm your Show Review Popup Button click!");
		mercuryPlugin.mercuryShowReviewPopup ("1111", "1234", "12345");
	}

	//int CS_MercuryShowMoregamesPopup(const char* uid, const char* vid, const char* did)
	public static void  ShowMoreGames(){
		Debug.Log ("I'm your Show More Games Popup Button click!");
		mercuryPlugin.mercuryShowMoregamesPopup ("1111", "1234", "12345");
	}
//	void OnGUI ()
//	{
//		int i = 0;
//
//		if (GUI.Button (new Rect (0, 0, btnWidth, btnHeight), "Show Notice Top Button")) {
//			Debug.Log ("I'm your Show Notice Top Button click!");
//			mercuryPlugin.mercuryShowEx (uid, C2SMercuryPlugin.MERCURY_SHOW_NOTICE_TOP, "{arm:korea-server}");
//		}
//
//		if (GUI.Button (new Rect (btnX, computePosY (i++), btnWidth, btnHeight), "Forced Show Notice Top Button")) {
//			Debug.Log ("I'm your Forced Show Notice Top Button click!");
//			mercuryPlugin.mercuryShowEx (uid, C2SMercuryPlugin.MERCURY_SHOW_FORCED_NOTICE_TOP, "{arm:korea-server}");
//		}
//
//		if (GUI.Button (new Rect (btnX, computePosY (i++), btnWidth, btnHeight), "Only Notice")) {
//			Debug.Log ("I'm your Only Notice Button click!");
//			mercuryPlugin.mercuryShowEx (uid, C2SMercuryPlugin.MERCURY_SHOW_NOTICE_ONLY, "{arm:korea-server}");
//		}
//
//		if (GUI.Button (new Rect (btnX, computePosY (i++), btnWidth, btnHeight), "Forced Only Notice")) {
//			Debug.Log ("I'm your Forced Only Notice Button click!");
//			mercuryPlugin.mercuryShowEx (uid, C2SMercuryPlugin.MERCURY_SHOW_FORCED_NOTICE_ONLY, "{arm:korea-server}");
//		}
//
//		if (GUI.Button (new Rect (btnX, computePosY (i++), btnWidth, btnHeight), "Forced Show Event Button")) {
//			Debug.Log ("I'm your Event Show Button click!");
//			mercuryPlugin.mercuryShowEx (uid, C2SMercuryPlugin.MERCURY_SHOW_EVENT, "{arm:korea-server}");
//		}
//
//		if (GUI.Button (new Rect (btnX, computePosY (i++), btnWidth, btnHeight), "Get Custom View Info")) {
//			Debug.Log ("I'm your Get Custom View Info Button click!");
//			mercuryPlugin.mercuryGetCustomViewInfo (uid, C2SMercuryPlugin.MERCURY_SHOW_NOTICE_ONLY, mercuryCBWithData);
//		}
//
//		if (GUI.Button (new Rect (btnX, computePosY (i++), btnWidth, btnHeight), "Get Badge(200001)")) {
//			Debug.Log ("I'm your Get Badge Button click!");
//			mercuryPlugin.mercuryGetBadge (200001);
//		}
//
//		if (GUI.Button (new Rect (btnX, computePosY (i++), btnWidth, btnHeight), "Show Review Popup")) {
//			Debug.Log ("I'm your Show Review Popup Button click!");
//			mercuryPlugin.mercuryShowReviewPopup ("1111", "1234", "12345");
//		}
//
//		if (GUI.Button (new Rect (btnX, computePosY (i++), btnWidth, btnHeight), "Show More Games Popup")) {
//			Debug.Log ("I'm your Show More Games Popup Button click!");
//			mercuryPlugin.mercuryShowMoregamesPopup ("1111", "1234", "12345");
//		}
//
//		if (GUI.Button (new Rect (btnX, computePosY (i++), btnWidth, btnHeight), "Exit")) {
//			Debug.Log ("Exit");
//			Application.Quit ();
//		}
//	}
}
