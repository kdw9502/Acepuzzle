#ifndef __C2SMERCURY_H__
#define __C2SMERCURY_H__

#ifdef __cplusplus
extern "C" {
#endif

    // Mercury open/close result
    typedef  enum _MERCURY_RESULT
    {
        // Mercury full banner & main page
        MERCURY_OPEN                = 1,        // 모듈 Full Banner 웹뷰 열림 알림
        MERCURY_CLOSE               = 2,        // 모듈 Full Banner 웹뷰 닫힘 알림
        MERCURY_FORCED_OPEN         = 3,        // 모듈 Main Page 웹뷰 열림 알림
        MERCURY_FORCED_CLOSE        = 4,        // 모듈 Main Page 웹뷰 닫힘 알림
        MERCURY_NOTICE_OPEN         = 5,        // 모듈 Notice Only 웹뷰 열림 알림
        MERCURY_NOTICE_CLOSE        = 6,        // 모듈 Notice Only 웹뷰 닫힘 알림

        // Custom board & view
        MERCURY_CUSTOM_OPEN         = 7,        // 모듈 Custom board 뷰 열림 알림
        MERCURY_CUSTOM_CLOSE        = 8,        // 모듈 Custom board 뷰 닫힘 알림
        
        MERCURY_CUSTOM_BOARD_OPEN   = MERCURY_CUSTOM_OPEN,
        MERCURY_CUSTOM_BOARD_CLOSE  = MERCURY_CUSTOM_CLOSE,
        MERCURY_CUSTOM_VIEW_OPEN    = 9,        // 모듈 Custom 웹뷰 열림 알림
        MERCURY_CUSTOM_VIEW_CLOSE   = 10,        // 모듈 Custom 웹뷰 닫힘 알림
        
        // Review popup
        MERCURY_REVIEW_OPEN         = 11,       // 리뷰 팝업 열림 알림
        MERCURY_REVIEW_CLOSE        = 12,       // 리뷰 팝업 닫힘 알림
        
        // Moregames popup (Android Only)
        MERCURY_MOREGAMES_OPEN      = 13,		// 모어게임즈 팝업 열림 알림
		MERCURY_MOREGAMES_CLOSE     = 14,		// 모어게임즈 팝업 닫힘 알림
		MERCURY_MOREGAMES_CLOSE_WITH_APP_TERMINATION  = 15,	// 모어게임즈 팝업 닫힘 & 사용자가 앱 종료하기 선택함 알림
        
        // Network error
        MERCURY_NETWORK_DISCONNECT  = 16       // 네트워크 접속장애 알림

    } MERCURY_RESULT;

    // GetCustomViewInfo result
    typedef enum _MERCURY_CUSTOM_RESULT
    {
        MERCURY_SUCCESS =  0,
        MERCURY_FAILED  = -1

    } MERCURY_CUSTOM_RESULT;

    // Mercury Show type
    typedef enum _MERCURY_SHOW_TYPE
    {
        // Mercury full banner
        MERCURY_SHOW_EVENT                  = -11,      // Full Banner
        
        // Mercury main page
        MERCURY_SHOW_NOTICE_TOP             = -12,      // Main Page (공지사항 위쪽 배치)
        MERCURY_SHOW_NOTICE_BOTTOM          = -13,      // Main Page (공지사항 아래쪽 배치)
        MERCURY_SHOW_FORCED_NOTICE_TOP      = -14,      // Main Page (공지사항 위쪽 배치 + 하루안보기 무시)
        MERCURY_SHOW_FORCED_NOTICE_BOTTOM   = -15,      // Main Page (공지사항 아래쪽 배치 + 하루안보기 무시)
        
        // Mercury notice
        MERCURY_SHOW_NOTICE_ONLY            = -16,      // Notice Only (공지사항만 표시)
        MERCURY_SHOW_FORCED_NOTICE_ONLY     = -17,      // Notice Only (공지사항만 표시 + 하루안보기 무시)
        
        // Custom show type
        // Base <= type < MAX
        MERCURY_SHOW_CUSTOM_BASE            = 100000,    // Custom board
        MERCURY_SHOW_CUSTOM_BOARD_BASE      = MERCURY_SHOW_CUSTOM_BASE,
        MERCURY_SHOW_CUSTOM_BOARD_MAX       = MERCURY_SHOW_CUSTOM_BASE + 200000,

        MERCURY_SHOW_CUSTOM_VIEW_BASE       = MERCURY_SHOW_CUSTOM_BOARD_MAX,
        MERCURY_SHOW_CUSTOM_VIEW_MAX        = MERCURY_SHOW_CUSTOM_VIEW_BASE + 200000
    } MERCURY_SHOW_TYPE;

    // Badge request & response code
    typedef enum _MERCURY_BADGE_TARGET
    {
        MERCURY_BADGE_FOR_EVENT        = -20,       // Badge for 'Full banner'
        MERCURY_BADGE_FOR_NOTICE       = -21,       // Badge for 'Main page'
        MERCURY_BADGE_FOR_NOTICE_ONLY  = -22,       // Badge for 'Notice Only'
        MERCURY_BADGE_FOR_NONE         = -23,       // Badge not found
        
        // Custom board & view
        // Base <= target < MAX
        MERCURY_BADGE_FOR_CUSTOM_BASE  = 100000,
        MERCURY_BADGE_FOR_CUSTOM       = MERCURY_BADGE_FOR_CUSTOM_BASE,
        MERCURY_BADGE_FOR_CUSTOM_MAX   = MERCURY_BADGE_FOR_CUSTOM_BASE + 200000,
        
        MERCURY_BADGE_FOR_CUSTOM_BOARD_BASE  = MERCURY_BADGE_FOR_CUSTOM_BASE,
        MERCURY_BADGE_FOR_CUSTOM_BOARD_MAX   = MERCURY_BADGE_FOR_CUSTOM_MAX,
        
        MERCURY_BADGE_FOR_CUSTOM_VIEW_BASE  = MERCURY_BADGE_FOR_CUSTOM_BOARD_MAX,
        MERCURY_BADGE_FOR_CUSTOM_VIEW_MAX   = MERCURY_BADGE_FOR_CUSTOM_VIEW_BASE + 200000

    } MERCURY_BADGE_TARGET;

    // Badge type
    typedef enum _MERCURY_BADGE_TYPE
    {
        MERCURY_BADGE_TYPE_NONE     = -24,
        MERCURY_BADGE_TYPE_NEW      = -25,
        MERCURY_BADGE_TYPE_MAX      = -26

    } MERCURY_BADGE_TYPE;
    
    // Callback type
	typedef void (*MercuryCB)(MERCURY_RESULT result);
    typedef void (*MercuryCBWithData)(const MERCURY_CUSTOM_RESULT result, const char* jsonData);

	void CS_MercurySetCallBack(MercuryCB callback);

	void CS_MercuryShowEx(const char* uid, MERCURY_SHOW_TYPE mercuryShowType, const char* additionalInfo) ;

    // Return MERCURY_SUCCESS or MERCURY_FAILED
    int CS_MercuryGetCustomViewInfo(const char* uid, const int viewID, MercuryCBWithData customViewCallback);
    int CS_MercuryShowReviewPopup(const char* uid, const char* vid, const char* did);
    int CS_MercuryShowMoregamesPopup(const char* uid, const char* vid, const char* did);

    void CS_MercuryGetBadge(const int badgeTarget);
    int CS_MercuryGetBadgeType(const int badgeTarget);

	void CS_MercurySetLog(int isLog);
    void CS_MercurySetIsUsingStaging(int isUsingStaging);
	void CS_MercurySetUid(const char* uid);
	const char* CS_MercuryGetVersion();
    
    // Deprecated v2.6.0
    void CS_MercuryShowForNotice(const char* uid);
    void CS_MercuryForcedShowForNotice(const char* uid);
    void CS_MercuryShowForEvent(const char* uid);
    void CS_MercuryForcedShowForEvent(const char* uid);
#ifdef __cplusplus
};
#endif


#endif
