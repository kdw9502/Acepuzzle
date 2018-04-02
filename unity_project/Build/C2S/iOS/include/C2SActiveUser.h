//
//  C2SActiveUser.h
//  ActiveUser
//
//  Created by Kim Inhong on 12. 3. 20..
//  Copyright (c) 2012년 Com2uS. All rights reserved.
//

#ifndef ActiveUser_C2SActiveUser_h
#define ActiveUser_C2SActiveUser_h
#ifdef __cplusplus
extern "C" {
#endif
    
    //UserAgree
    typedef enum USER_AGREE_TERMS
    {
        TERMS_GAME_SERVICE = 0,
        TERMS_PRIVACY,
        TERMS_SMS               // only android
    }USER_AGREE_TERMS_TYPE;
    
    typedef enum USER_AGREE_COLOR
    {
        USER_AGREE_COLOR_TYPE_WHITE = 0,
        USER_AGREE_COLOR_TYPE_BLACK = 1
    }USER_AGREE_COLOR_TYPE;
    
    //UserAgree Result Callback
    typedef enum USER_AGREE_RESULT_TYPE
    {
        USER_AGREE_SUCCESS = 0,
        USER_AGREE_TERMS_CLOSE = 1,
    }USER_AGREE_RESULT;
    
    typedef enum ACTIVR_USER_RESULT_TYPE
    {
        ACTIVE_USER_GETDID_SUCCESS = 0,
        ACTIVE_USER_GETDID_FAIL = 1,
    }ACTIVE_USER_RESULT;
    
    typedef enum SERVER_STATE_TYPE
    {
        LIVE_SERVER = 0,
        STAGING_SERVER = 1,
        SANDBOX_SERVER = 2
    }SERVER_STATE;
    
    typedef enum SHOW_POPUP_TYPE	// added in ActiveUser iOS(2.6.7) & Android(2.6.6)
    {
        SHOW = 0,
        NOTSHOW = 1,
        SHOW_POPUP_ERROR = -1
    }SHOW_POPUP;
    
    typedef enum POPUP_STATE_TYPE	// added in ActiveUser iOS(2.6.7) & Android(2.6.6)
    {
        CLOSE = 0,
        UNSHOWN = 1,
        POPUP_STATE_ERROR = -1
    }POPUP_STATE;

    
    typedef void (*ActiveUserCB)(ACTIVE_USER_RESULT result);
    typedef void (*UserAgreeCB)(USER_AGREE_RESULT result);
    typedef void (*UpdateNoticePopupCB)(POPUP_STATE state); // added in ActiveUser iOS(2.6.6) & Android(2.6.6)
    typedef void (*UpdateNoticeInfoCB)(SHOW_POPUP show, const char* jsonData);  // added in ActiveUser iOS(2.6.6) & Android(2.6.6)
    
    void CS_ActiveUserSetCallback(ActiveUserCB cb);
    void CS_UserAgreeSetCallback(UserAgreeCB cb);
    
    //Active User
    void CS_ActiveUserStart();
    void CS_ActiveUserStartEx(SERVER_STATE serverState);
    void CS_ActiveUserStartWithoutNotice(SERVER_STATE serverState, int showNoticePopup);
    void CS_ActiveUserSetVID(const char* vid);
    void CS_ActiveUserSetServerId(const char* server_id);
    // game language 추가
    void CS_ActiveUserSetGameLanguage(const char* game_language);
    void CS_ActiveUserRegisterToken(void* deviceToken);
    int CS_ActiveUserGetVersion(char* buf,int bufSize);
    
    void CS_ActiveUserSetLogged(int isLogged); // Only Android
    void CS_ActiveUserSetEnableRequestStoragePermission();	// only Android
    const char* CS_ActiveUserGetDID();
    
    void CS_UserAgreeSetView(void* parentView);	  //For Unity
    void CS_UserAgreeShowUI(void* parentView);    //콜백, 동의 페이지표시
    void CS_UserAgreeShowUIEx(void* parentView, USER_AGREE_COLOR_TYPE colorType);
    void CS_UserAgreeShowTermsUI(void* parentView);
    void CS_UserAgreeShowTermsUIEx(void* parentView, const char* url); // 이용 약관 Custom URL
    
    // 공지팝업 노출
    // Modified in AU 2.6.5. Change CS_UserAgreeShowNotice( void*, void*) to CS_UserAgreeShowNoticeEx(void*, void*)
    // 2.7.2 - serverId 제거
    void CS_UpdateNoticeShowPopup(UpdateNoticePopupCB cb);
    
    // 공지팝업 정보
    // 2.7.2 - serverId 제거
    void CS_UpdateNoticeGetPopupInfo(UpdateNoticeInfoCB cb);
    
    void CS_UserAgreeShowNoticeEx(void* parentView, void* contentsDict);
    // block 유저 팝업 노출
    // void CS_UserAgreeShowBlock(void* dict);
    
    // 2.8.0 update - 타임아웃 시간 세팅
    void CS_SetMinTimeoutSeconds(int seconds);
    
    

    
    void CS_UserAgreeReset();
    
    
    
    // Deprecated
    void CS_ActiveUserUseTestServer(); // Use CS_ActiveUserStartEx(serverState)
#ifdef __cplusplus
};
#endif
#endif
