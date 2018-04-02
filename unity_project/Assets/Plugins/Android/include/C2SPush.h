/*************************************************************
 * Push Module v3.3.1
 *
 * Created by Com2uS.DEV.OPLab.MI.Hife on December 2011
 * Copyright (c) 2011 Com2uS Corporation. All rights reserved.
 *************************************************************/

#ifdef __cplusplus
extern "C" {
#endif

typedef enum Push_UserSetting_ {
	DEFAULT_FALSE 	= 0x00,	//deprecated. use USER_FALSE
	DEFAULT_TRUE 	= 0x01,	//deprecated. use USER_TRUE
	USER_FALSE 		= 0x02,
	USER_TRUE 		= 0x03
} Push_UserSetting;

typedef enum Push_BoolType_ {
	Push_FALSE = 0,
	Push_TRUE = 1
} Push_BoolType;

typedef enum Push_CallbackType_ {
	onReceivedGCMPush		= 0x01,
	onReceivedLocalPush		= 0x02
} Push_CallbackType;

typedef void (*PushCallback)(Push_CallbackType callbackType, int pushID, int remainPushCallback);

void CS_pushSetPush(Push_UserSetting isPush);
void CS_pushSetSound(Push_UserSetting isSound);
void CS_pushSetVib(Push_UserSetting isVib);
void CS_pushSetAgree(Push_BoolType notice, Push_BoolType night);
Push_UserSetting CS_pushGetPush();
Push_UserSetting CS_pushGetSound();
Push_UserSetting CS_pushGetVib();
Push_BoolType CS_pushGetAgreeNotice();
Push_BoolType CS_pushGetAgreeNight();

void CS_pushRegisterLocalpush(int pushID, char* title, char* msg, char* ticker, char* type, char* icon, char* sound, char* active, long after);
void CS_pushRegisterLocalpushEx(int pushID, char* title, char* msg, char* ticker, char* type, char* icon, char* sound, char* active, long after, char* broadcastAction);
void CS_pushRegisterLocalpushBig(int pushID, char* title, char* msg, char* bigmsg, char* ticker, char* type, char* icon, char* sound, char* active, long after, char* broadcastAction);
void CS_pushRegisterLocalpushData(char* jsonPushData);
void CS_pushUnRegisterLocalpush(int pushID);
void CS_pushUnRegisterAllLocalpush();			// added v2.5.0
void CS_pushRegisterCallbackHandler(PushCallback pushCallback);
void CS_pushUnRegisterCallbackHandler();
void CS_pushSetOperationLocalPushOnRunning(int boolean);
void CS_pushSetOperationGCMPushOnRunning(int boolean);
int CS_pushGetOperationLocalPushOnRunning();	// added v2.3.8
int CS_pushGetOperationGCMPushOnRunning();		// added v2.3.8
char* CS_pushGetRegistrationId();

void CS_pushSetOperationOnRunning(int boolean); // Deprecated

#ifdef __cplusplus
};
#endif
