#ifndef _C2SINAPP_H_
#define _C2SINAPP_H_

#ifdef __cplusplus
extern "C" {
#endif

typedef struct CS_IapItemList_ {	//for iOS, Tstore, Lebi, Plasma, Amazon & GooglePlay(API Lv3)
	const char* productID;
	const char* formattedString;
	const char* localizedTitle;
	const char* localizedDescription;
	const char* currencyCode;			// added v2.9.1
	long long	amountMicros;			// added v2.9.1
} CS_IapItemList;

typedef struct Iap_ItemInfo{
	const char* pid;
	int 		quantity;
	const char* uid;					// changed to uid from hubuid in v2.9.1
	const char* additionalInfo;			// changed to additionalInfo from orderKey in v2.9.1
} CS_IapItemInfo;

// BUY_FAILED state value
typedef struct CS_IapErrorStateValue_ {
	const char* errorCode;
	const char* errorValue;
	const char* errorMsg;
} CS_IapErrorStateValue;


typedef enum CS_IapSuccessStateValue_ {
	MARKET_NUMBER				= 0,
	MARKET_NAME 				= 1,

	GOOGLEINAPP_RECEIPT 		= 2,	// deprecated market (use GOOGLEPLAY_RECEIPT)
	GOOGLEINAPP_SIGNATURE 		= 3,	// deprecated market (use GOOGLEPLAY_SIGNATURE)

	TSTORE_TRANSACTION			= 4,
//	TSTORE_TID					= 4,	// deprecated after v2.8.3
//	TSTORE_DATELOCAL			= 5,	// deprecated after v2.8.3

	OLLEHMARKET_TRANSACTIONID 	= 6,
	OLLEHMARKET_DATELOCAL 		= 7,

	OZSTORE_DATELOCAL			= 8,
	OZSTORE_UKEY				= 37,	// added v2.8.4
	OZSTORE_TXID				= 38,	// added v2.8.4

	THIRDPARTY_ORDERKEY 		= 9,	// deprecated after v2.9.1 (use THIRDPARTY_ADDITIONALINFO)
	THIRDPARTY_ADDITIONALINFO 	= 9,	// added v2.9.1

	QIIP_DATELOCAL 				= 10,

	HAMI_DATELOCAL 				= 11,

	LEBI_BILLINGNUM 			= 12,

	PLASMA_PAYMENTID			= 13,
	PLASMA_PURCHASEID			= 14,
	PLASMA_ITEMID				= 15,
	PLASMA_VERIFYURL			= 16,
	PLASMA_PARAM1				= 17,
	PLASMA_PARAM2				= 18,
	PLASMA_PARAM3				= 19,
	PLASMA_PURCHASEDATE			= 20,

	AMAZON_PRODUCTID			= 21,
	AMAZON_USERID				= 22,
	AMAZON_PURCHASETOKEN		= 23,	// deprecated after v2.9.1 (use AMAZON_RECEIPTID)
	AMAZON_RECEIPTID			= 23,	// added v2.9.1
	AMAZON_REQUESTID			= 24,
	AMAZON_MARKETPLACE			= 40,	// added v2.9.1

	KDDI_TRANSACTION			= 25,
	KDDI_SIGNATURE				= 26,

	MM_ORDERID					= 27,
	MM_PURCHASEDATE				= 28,

	MBIZ_EMONEY					= 29,
	MBIZ_PURCHASEDATE			= 30,

	GOOGLEPLAY_RECEIPT			= 35,
	GOOGLEPLAY_SIGNATURE		= 36,

	MAX_SUCCESS_STATE_VALUE		= 41
} CS_IapSuccessStateValue;


typedef enum CS_IapBillingTarget_ {
//	GoogleInAppBilling	=  1,	// deprecated market (use GooglePlayBilling)
	TstoreBilling		=  2,
	ollehMarketBilling	=  3,
	OZstoreBilling		=  4,
	ThirdPartyBilling	=  5,
	qiipBilling			=  6,
	HamiBilling			=  7,
	LebiBilling			=  8,
	PlasmaBilling		=  9,
	AmazonBilling		= 10,
	KDDIBilling			= 11,
	MMBilling			= 12,
	MBizBilling			= 13,
//	PantechBilling		= 14,
	GooglePlayBilling	= 15,

	MAX_BILLING_TARGET
} CS_IapBillingTarget;



typedef enum INAPP_RESULT_TYPE
{
	  GET_ITEM_LIST				=  1,
	  BUY_SUCCESS				=  2,
	  BUY_FAILED				=  3,
	  BUY_CANCELED				=  4,
	  RESTORE_SUCCESS			=  5,
//	  RESTORE_FINISH			=  6,	// iOS only
//	  RESTORE_FAILED			=  7,	// iOS only
	  PURCHASE_UPDATED			=  8,	// Android only

	  MAX_INAPP_RESULT
} INAPP_RESULT;

typedef enum LICENSE_RESULT_TYPE
{
	  AUTHORIZE_LICENSE_SUCCESS	= 100,
	  AUTHORIZE_LICENSE_FAILED	= 101
} LICENSE_RESULT;

typedef enum SELECT_TARGET_RESULT_TYPE
{
	  TARGETING_SUCCESS	= 200,
	  TARGETING_FAILED	= 201
} SELECT_TARGET_RESULT;


typedef void (*IapCB)(INAPP_RESULT iapState, void* iapItem, void* stateValue);
typedef void (*LicenseCB)(LICENSE_RESULT licenseState, void* stateValue);
typedef void (*TargetCB)(SELECT_TARGET_RESULT selectTargetState, int stateValue);


int  CS_IapInitialize(char** pids, char* appid, int autoVerify, IapCB cb);	// for iOS
int  CS_IapInitializeEx(int billingTarget, char** pids, char* appid, int autoVerify, IapCB cb);	// for Android
void CS_IapUninitialize();
void CS_IapStoreStart();
void CS_IapStoreEnd();
void CS_IapRestoreItem(char* uid);
void CS_IapBuyItem(CS_IapItemInfo iapItemInfo);
void CS_IapBuyFinish();
void CS_IapUseTestServer();
int  CS_IapRequestBalance(char* uid); // for Lebi
void CS_IapAuthorizeLicense(LicenseCB licensecb); // for KDDI
void CS_IapSelectTarget(TargetCB targetcb); // for GooglePlay, Lebi

void CS_IapSetUseDialog(int boolean); // for MM

#ifdef __cplusplus
};
#endif

#endif	// _C2SINAPP_H_
