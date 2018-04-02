//
//  C2SPush.h
//  C2SPush
//
//  Created by thebeast thebeast on 11. 10. 12..
//  Copyright (c) 2011 Com2us INT_DEV. All rights reserved.
//


#if !defined(__C2S_PUSH_H__)
#define __C2S_PUSH_H__
#ifdef __cplusplus
extern "C" {
#endif
    typedef enum Push_BoolType_ {
        Push_FALSE  = 0,
        Push_TRUE   = 1
    } Push_BoolType;
    
    typedef enum Push_CallbackType_ {
        onReceivedGCMPush		= 0x01,     //onReceivedAPNSPush, Android Only
        onReceivedLocalPush		= 0x02
    } Push_CallbackType;
    
    //Local Notification CallBack Function
    typedef void (*PushCallback)(Push_CallbackType callbackType, int pushID, int remainPushCallback);
    
    //Remote Function
    void CS_hlpPushDefaultActionOnLaunch(void* inData);
    void CS_hlpPushRegisterTokenEx(void* deviceToken);
    void CS_hlpPushSendPromoCodeEx(void* userInfo);
    void CS_hlpPushUseTestServerEx();
    const char* CS_hlpPushGetVersionEx();
    
    //Notification On/Off
    void CS_pushSetAgree(Push_BoolType notice, Push_BoolType night);
    
    Push_BoolType CS_pushGetAgreeNotice();
    Push_BoolType CS_pushGetAgreeNight();
    
    //Local Notification Function
    void CS_pushRegisterLocalpush(int pushID, char* title, char* msg, char* ticker, char* type, char* icon, char* sound, char* active, long after);
    void CS_pushRegisterLocalpushEx(int pushID, char* title, char* msg, char* ticker, char* type, char* icon, char* sound, char* active, long after, char* broadcastAction);
    void CS_pushUnRegisterLocalpush(int pushID);
    void CS_pushRegisterCallbackHandler(PushCallback pushCallback);
    void CS_pushRunCallback(void* notification);
    
    //Deprecated Function
    void CS_hlpPushRegisterToken(const char* deviceToken)__attribute__ ((deprecated));
    int CS_hlpPushLoadOption()__attribute__ ((deprecated));
    void CS_hlpPushUseTestServer(const char* serverURL,const char* confirmURL,const char* localConfirmURL)__attribute__ ((deprecated));
    unsigned int CS_hlpPushGetVersion()__attribute__ ((deprecated));
#ifdef __cplusplus
};
#endif
#endif