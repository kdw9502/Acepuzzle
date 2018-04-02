#ifdef __cplusplus
extern "C" {
#endif
    
    typedef struct Iap_ItemInfo{
        const char* 	pid;				//빌링시스템에 등록되어있는 아이템 코드
        int            quantity;		//수량
        char*          hubuid;			//글로벌 회원시스템 회원 구분키값
        char*          orderKey;		//결제 요청시 고유키값
    } CS_IapItemInfo;
    
    typedef struct CS_IapItemList_ {
        const char *productID;
        const char *formattedString;
        const char *localizedTitle;
        const char *localizedDescription;
    } CS_IapItemList;
    
    /*
     * iapState: 현재 상태
     GET_ITEM_LIST : 서버로부터 아이템에 대한 정보를 받음
     BUY_SUCCESS : 구매 성공
     BUY_FAILED : 구매 실패
     BUY_CANCELED : 구매 취소(유저에 의한 취소입니다.)
     RESTORE_SUCCESS : 복구 성공
     MARKET_CANCELED : 마켓으로부터 취소됐다는 메세지를 받음
     MARKET_REFUNED : 마켓으로부터 환불됐다는 메세지를 받음
     PROCESS_END : 구매 혹은 아이템 복구가 모두 끝난 경우
     SEND_LOG_SUCCESS : 로그 기록 성공
     SEND_LOG_FAILED : 로그 기록 실패(실패에 대한 처리는 래퍼에서 합니다.)
     * pid : 상품 고유 아이디
     * param : 구매시 입력한 값
     * stateValue : state에 따라 필요한 값 설정
     GET_ITEM_LIST : 서버로부터 받은 아이템 정보 리스트
     ※ struct로 필요한 데이터를 받음(미정)
     BUY_FAILED : 에러코드
     PROCESS_END : 구매인 경우 로그서버에 보낼 데이터
     */
    typedef enum INAPP_RESULT_TYPE
    {
        GET_ITEM_LIST       = 1,	//서버로부터 아이템에 대한 정보를 받음
        BUY_SUCCESS         = 2,	//구매 성공
        BUY_FAILED          = 3,	//구매 실패
        BUY_CANCELED        = 4,	//구매 취소(유저에 의한 취소입니다.)
        RESTORE_SUCCESS     = 5,	//복구 성공
        RESTORE_FINISHED    = 6,
        RESTORE_FAILED      = 7,
        PURCHASE_UPDATED	= 8,	// Android only
        
        PROMOTE_PURCHASE    = 9,    // IOS Only
        NOT_OWNED           = 10,   // 요청한 값 없음
        
        MAX_INAPP_RESULT
    } INAPP_RESULT;
    
    typedef void (*IapCB)(INAPP_RESULT iapState, void* iapItem, void* stateValue);
    
    int CS_IapInitialize(char** pid, char* appid, int autoVerify, IapCB cb);
    void CS_IapUninitialize(void);
    void CS_IapStoreStart(void);
    void CS_IapStoreEnd(void);
    void CS_IapRestoreItem(char* hubuid);
    void CS_IapBuyItem(CS_IapItemInfo iapItemInfo);
    void CS_IapUseTestServer(void);
    void CS_IapBuyFinish(void);
    
    // 2.13.0 update
    void CS_IapCheckPromotePurchase(void);
    
    int CS_IapModuleGetVersion(void) __attribute__ ((deprecated));
    const char* CS_IapModuleGetVersionEx();
    
#define MC_IapInitialize		CS_IapInitialize
#define MC_IapUninitialize		CS_IapUninitialize
#define MC_IapStoreStart		CS_IapStoreStart
#define MC_IapStoreEnd			CS_IapStoreEnd
#define MC_IapRestoreItem		CS_IapRestoreItem
#define MC_IapBuyItem			CS_IapBuyItem
#define MC_IapSendLog			CS_IapSendLog
#define MC_IapUseTestServer	CS_IapUseTestServer
#define MC_IapBuyFinish       CS_IapBuyFinish
#define MC_IapCheckPromotePurchase CS_IapCheckPromotePurchase

    
#ifdef __cplusplus
};
#endif
