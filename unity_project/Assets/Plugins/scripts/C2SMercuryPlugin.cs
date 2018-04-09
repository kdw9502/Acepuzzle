/* his file must not be modified.
 * 2013-02-07 by hife
 * 2013-02-25 by hife
 * 2013-06-17 by hife
 * 2013-07-10 by HLKim
 * 2013-07-15 by HLKim
 * 2013-07-23 by HLKim
 * 2013-08-16 by HLKim
 * 2014-02-13 by THJo
 * 2015-06-17 by KJKim
 * 2015-06-24 by GJPark
 * 2015-08-05 by kjkim
 * 2015-08-11 by kjkim (v2.8.0)
 * 2015-08-12 by kjkim
 * 2015-09-08 by kjkim (Android method call)
 * 2015-11-18 by kjkim (Custom board & view Enum values)
 */

using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;


public interface IMercuryCallback
{
	void onMercuryResult (int result);
}

public interface IMercuryCallbackWithData
{
	void onMercuryResultWithData (int result, string jsonData);
}

public abstract class IMercuryPlugin : MonoBehaviour
{
	// Mercury Result Start
    // Mercury full banner & main page
	public const int MERCURY_OPEN                = 1;        // 모듈 Full Banner 웹뷰 열림 알림
	public const int MERCURY_CLOSE               = 2;        // 모듈 Full Banner 웹뷰 닫힘 알림
	public const int MERCURY_FORCED_OPEN         = 3;        // 모듈 Main Page 웹뷰 열림 알림
	public const int MERCURY_FORCED_CLOSE        = 4;        // 모듈 Main Page 웹뷰 닫힘 알림
	public const int MERCURY_NOTICE_OPEN         = 5;        // 모듈 Notice Only 웹뷰 열림 알림
	public const int MERCURY_NOTICE_CLOSE        = 6;        // 모듈 Notice Only 웹뷰 닫힘 알림

    // Custom board & view
	public const int MERCURY_CUSTOM_OPEN         = 7;        // 모듈 Custom board 뷰 열림 알림
	public const int MERCURY_CUSTOM_CLOSE        = 8;        // 모듈 Custom board 뷰 닫힘 알림

	public const int MERCURY_CUSTOM_BOARD_OPEN   = MERCURY_CUSTOM_OPEN;
	public const int MERCURY_CUSTOM_BOARD_CLOSE  = MERCURY_CUSTOM_CLOSE;
	public const int MERCURY_CUSTOM_VIEW_OPEN    = 9;        // 모듈 Custom 웹뷰 열림 알림
	public const int MERCURY_CUSTOM_VIEW_CLOSE   = 10;        // 모듈 Custom 웹뷰 닫힘 알림

    // Review popup
	public const int MERCURY_REVIEW_OPEN         = 11;       // 리뷰 팝업 열림 알림
	public const int MERCURY_REVIEW_CLOSE        = 12;       // 리뷰 팝업 닫힘 알림

    // Moregames popup (Android Only)
	public const int MERCURY_MOREGAMES_OPEN      = 13;		// 모어게임즈 팝업 열림 알림
	public const int MERCURY_MOREGAMES_CLOSE     = 14;		// 모어게임즈 팝업 닫힘 알림
	public const int MERCURY_MOREGAMES_CLOSE_WITH_APP_TERMINATION  = 15;	// 모어게임즈 팝업 닫힘 & 사용자가 앱 종료하기 선택함 알림

    // Network error
    public const int MERCURY_NETWORK_DISCONNECT  = 16;       // 네트워크 접속장애 알림
    // Mercury Result End


	// GetCustomViewInfo Result
	public const int MERCURY_SUCCESS = 0;      // REQUEST SUCCESS
	public const int MERCURY_FAILED = -1;      // REQUEST FAILED


	// Mercury Show Type Start
    // Mercury full banner
	public const int MERCURY_SHOW_EVENT                  = -11;      // Full Banner

    // Mercury main page
	public const int MERCURY_SHOW_NOTICE_TOP             = -12;      // Main Page (공지사항 위쪽 배치)
	public const int MERCURY_SHOW_NOTICE_BOTTOM          = -13;      // Main Page (공지사항 아래쪽 배치)
	public const int MERCURY_SHOW_FORCED_NOTICE_TOP      = -14;      // Main Page (공지사항 위쪽 배치 + 하루안보기 무시)
	public const int MERCURY_SHOW_FORCED_NOTICE_BOTTOM   = -15;      // Main Page (공지사항 아래쪽 배치 + 하루안보기 무시)

    // Mercury notice
	public const int MERCURY_SHOW_NOTICE_ONLY            = -16;      // Notice Only (공지사항만 표시)
	public const int MERCURY_SHOW_FORCED_NOTICE_ONLY     = -17;      // Notice Only (공지사항만 표시 + 하루안보기 무시)

    // Custom show type
    // Base <= type < MAX
	public const int MERCURY_SHOW_CUSTOM_BASE            = 100000;    // Custom board
	public const int MERCURY_SHOW_CUSTOM_BOARD_BASE      = MERCURY_SHOW_CUSTOM_BASE;
	public const int MERCURY_SHOW_CUSTOM_BOARD_MAX       = MERCURY_SHOW_CUSTOM_BASE + 200000;

	public const int MERCURY_SHOW_CUSTOM_VIEW_BASE       = MERCURY_SHOW_CUSTOM_BOARD_MAX;
    public const int MERCURY_SHOW_CUSTOM_VIEW_MAX        = MERCURY_SHOW_CUSTOM_VIEW_BASE + 200000;
    // Mercury show Type End


    // Badge request & response code start
	// Mercury Badge Target
	public const int MERCURY_BADGE_FOR_EVENT        = -20;       // Badge for 'Full banner'
	public const int MERCURY_BADGE_FOR_NOTICE       = -21;       // Badge for 'Main page'
	public const int MERCURY_BADGE_FOR_NOTICE_ONLY  = -22;       // Badge for 'Notice Only'
	public const int MERCURY_BADGE_FOR_NONE         = -23;       // Badge not found

    // Custom board & view
    // Base <= target < MAX
	public const int MERCURY_BADGE_FOR_CUSTOM_BASE  = 100000;
	public const int MERCURY_BADGE_FOR_CUSTOM       = MERCURY_BADGE_FOR_CUSTOM_BASE;
	public const int MERCURY_BADGE_FOR_CUSTOM_MAX   = MERCURY_BADGE_FOR_CUSTOM_BASE + 200000;

	public const int MERCURY_BADGE_FOR_CUSTOM_BOARD_BASE  = MERCURY_BADGE_FOR_CUSTOM_BASE;
	public const int MERCURY_BADGE_FOR_CUSTOM_BOARD_MAX   = MERCURY_BADGE_FOR_CUSTOM_MAX;

	public const int MERCURY_BADGE_FOR_CUSTOM_VIEW_BASE  = MERCURY_BADGE_FOR_CUSTOM_BOARD_MAX;
    public const int MERCURY_BADGE_FOR_CUSTOM_VIEW_MAX   = MERCURY_BADGE_FOR_CUSTOM_VIEW_BASE + 200000;
    // Badge request & response code end


	// Mercury Badge Type
	public const int MERCURY_BADGE_TYPE_NONE = -24;
	public const int MERCURY_BADGE_TYPE_NEW = -25;
	public const int MERCURY_BADGE_TYPE_MAX = -26;


	// Interface
	public abstract void createPlugin ();	
	public abstract void setCallback (IMercuryCallback cb);
	
	public abstract void setLog (bool isLog);
	public abstract void setUid (string uid);
	
	public abstract void setResumed ();
	public abstract void setPaused ();
	
	public abstract void mercuryShowEx (string uid, int mercuryShowType, string additionalInfo);
	public abstract void mercuryGetCustomViewInfo (string uid, int viewID, IMercuryCallbackWithData customViewCallback); // Add v2.7.3
	
	public abstract int mercuryShowReviewPopup (string uid, string vid, string did); // Add v2.8.0
	public abstract int mercuryShowMoregamesPopup (string uid, string vid, string did); // Add v2.8.0
	
	public abstract void mercuryGetBadge (int showType); // Add v2.7.0

    // Deprecated v2.11.0
	public abstract void setIsUsingStaging (bool isUsingStaging); // Use CS_ActiveUserStartEx(serverState)

	// Deprecated v2.6.0
	public abstract void showForNotice (string uid);
	public abstract void forcedShowForNotice (string uid);
	public abstract void showForEvent (string uid);
	public abstract void forcedShowForEvent (string uid);


#if UNITY_IPHONE
	[DllImport ("__Internal")]
	public static extern void CS_MercuryUnitySetCallback (string objName);
	[DllImport ("__Internal")]
	public static extern void CS_MercurySetLog (int isLog);
	[DllImport ("__Internal")]
	public static extern void CS_MercurySetIsUsingStaging (int isUsingStaging);
	[DllImport ("__Internal")]
	public static extern void CS_MercurySetUid (string uid);
	[DllImport ("__Internal")]
	public static extern void CS_MercuryShowEx (string uid, int mercuryShowType, string additionalInfo);
	[DllImport ("__Internal")]
	public static extern void CS_MercuryGetCustomViewInfoUnity (string uid, int viewID, string customViewCallback);
	[DllImport ("__Internal")]
	public static extern int CS_MercuryShowReviewPopup (string uid, string vid, string did);
	[DllImport ("__Internal")]
	public static extern int CS_MercuryShowMoregamesPopup (string uid, string vid, string did);
	[DllImport ("__Internal")]
	public static extern void CS_MercuryGetBadge (int showType);
	// Deprecated v2.6.0
	[DllImport ("__Internal")]
	public static extern void CS_MercuryShowForNotice (string uid);
	[DllImport ("__Internal")]
	public static extern void CS_MercuryForcedShowForNotice (string uid);
	[DllImport ("__Internal")]
	public static extern void CS_MercuryShowForEvent (string uid);
	[DllImport ("__Internal")]
	public static extern void CS_MercuryForcedShowForEvent (string uid);

#endif
}


public class C2SMercuryPlugin : IMercuryPlugin
{
	
	static IMercuryCallback mercuryCB = null;
	static IMercuryCallbackWithData mercuryCBWithData = null;
#if UNITY_ANDROID
	AndroidJavaObject mercuryPlugin = null;
	
	public override void createPlugin ()
	{
		AndroidJavaClass unityPlayer = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject> ("currentActivity");		
		mercuryPlugin = new AndroidJavaObject ("com.com2us.module.mercury.unityplugin.MercuryUnityPlugin", currentActivity);
	}
	
	public override void setCallback (IMercuryCallback cb)
	{
		mercuryCB = cb;
		mercuryPlugin.Call ("setUnityCallBack", gameObject.name);
	}

	public override void showForNotice (string uid)
	{
		mercuryPlugin.Call ("mercuryShowEx", uid, MERCURY_SHOW_NOTICE_TOP, "");
	}
	
	public override void forcedShowForNotice (string uid)
	{
		mercuryPlugin.Call ("mercuryShowEx", uid, MERCURY_SHOW_FORCED_NOTICE_TOP, "");
	}

	public override void showForEvent (string uid)
	{
		mercuryPlugin.Call ("mercuryShowEx", uid, MERCURY_SHOW_NOTICE_BOTTOM, "");
	}
	
	public override void forcedShowForEvent (string uid)
	{
		mercuryPlugin.Call ("mercuryShowEx", uid, MERCURY_SHOW_FORCED_NOTICE_BOTTOM, "");
	}
	
	public override void setLog (bool isLog)
	{
		mercuryPlugin.Call ("setLogged", isLog);
	}

	public override void setIsUsingStaging (bool isUsingStaging)
	{
		mercuryPlugin.Call ("setIsUsingStaging", isUsingStaging);
	}

	public override void setUid (string uid)
	{

		mercuryPlugin.CallStatic ("setUid", uid);
	}

	public override void setResumed ()
	{
		mercuryPlugin.Call ("onActivityResumed");
	}

	public override void setPaused ()
	{
		mercuryPlugin.Call ("onActivityPaused");
	}

	public override void mercuryShowEx (string uid, int mercuryShowType, string additionalInfo)
	{
		mercuryPlugin.Call ("mercuryShowEx", uid, mercuryShowType, additionalInfo);
	}
	
	public override void mercuryGetCustomViewInfo (string uid, int viewID, IMercuryCallbackWithData customViewCallback)
	{
		mercuryCBWithData = customViewCallback;
		mercuryPlugin.Call ("mercuryGetCustomViewInfoUnity", uid, viewID, gameObject.name);
	}
	
	public override int mercuryShowReviewPopup (string uid, string vid, string did)
	{
		return mercuryPlugin.Call<int> ("showReviewPopup", uid, vid, did);
	}
	
	public override int mercuryShowMoregamesPopup (string uid, string vid, string did)
	{
		return mercuryPlugin.Call<int> ("showMoregamesPopup", uid, vid, did);
	}
	
	public override void mercuryGetBadge (int showType)
	{
		mercuryPlugin.Call ("mercuryGetBadge", showType);
	}

#endif

#if UNITY_IPHONE
	public override void createPlugin ()
	{
	}
	
	public override void setCallback (IMercuryCallback cb)
	{
		mercuryCB = cb;
		CS_MercuryUnitySetCallback (gameObject.name);
	}
	
	public override void showForNotice (string uid)
	{
		CS_MercuryShowForNotice (uid);
	}
	
	public override void forcedShowForNotice (string uid)
	{
		CS_MercuryForcedShowForNotice (uid);
	}

	public override void showForEvent (string uid)
	{
		CS_MercuryShowForEvent (uid);
	}
	
	public override void forcedShowForEvent (string uid)
	{
		CS_MercuryForcedShowForEvent (uid);
	}
	
	public override void setLog (bool isLog)
	{
		CS_MercurySetLog (isLog ? 1 : 0);
	}

	public override void setIsUsingStaging (bool isUsingStaging)
	{
		CS_MercurySetIsUsingStaging (isUsingStaging ? 1 : 0);
	}

	public override void setUid (string uid)
	{
		CS_MercurySetUid (uid);
	}

	public override void mercuryShowEx (string uid, int mercuryShowType, string additionalInfo)
	{
		CS_MercuryShowEx (uid, mercuryShowType, additionalInfo);
	}
	
	public override void mercuryGetCustomViewInfo (string uid, int viewID, IMercuryCallbackWithData customViewCallback)
	{
		mercuryCBWithData = customViewCallback;
		CS_MercuryGetCustomViewInfoUnity (uid, viewID, gameObject.name);
	}
	
	public override int mercuryShowReviewPopup (string uid, string vid, string did)
	{
		return CS_MercuryShowReviewPopup (uid, vid, did);
	}
	
	public override int mercuryShowMoregamesPopup (string uid, string vid, string did)
	{
		return CS_MercuryShowMoregamesPopup (uid, vid, did);
	}
	
	public override void mercuryGetBadge (int showType)
	{
		CS_MercuryGetBadge (showType);
	}
	
	public override void setResumed ()
	{
		
	}

	public override void setPaused ()
	{
		
	}
#endif

	void setMercuryCallback (string strResult)
	{
		int result = System.Convert.ToInt32 (strResult);
		if (mercuryCB != null)
			mercuryCB.onMercuryResult (result);
	}
	
	void setMercuryCallbackWithData (string strResult)
	{
		string[] strTokens = strResult.Split ('\t');
		
		int result = System.Convert.ToInt32 (strTokens [0]);

		if (mercuryCBWithData != null)
			mercuryCBWithData.onMercuryResultWithData (result, strTokens [1]);
	}

#if !UNITY_ANDROID && !UNITY_IPHONE
	public override void createPlugin ()
	{
	}
	public override void setCallback (IMercuryCallback cb)
	{
	}
	public override void showForNotice (string uid)
	{
	}
	public override void forcedShowForNotice (string uid)
	{
	}
	public override void showForEvent (string uid)
	{
	}
	public override void forcedShowForEvent (string uid)
	{
	}
	public override void setLog (bool isLog)
	{
	}
	public override void setIsUsingStaging (bool isUsingStaging)
	{
	}
	public override void setUid (string uid)
	{
	}
	public override void setResumed ()
	{
	}
	public override void setPaused ()
	{
	}
	public override void mercuryShowEx ()
	{
	}
	public override void mercuryGetCustomViewInfo (string uid, int viewID, IMercuryCallbackWithData customViewCallback)
	{
	}
	public override int mercuryShowReviewPopup (string uid, string vid, string did)
	{
		return 0;
	}
	public override int mercuryShowMoregamesPopup (string uid, string vid, string did)
	{
		return 0;
	}
	public override void mercuryGetBadge (int showType)
	{
	}
#endif
	
}