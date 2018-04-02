#ifndef __C2SOFFERWALL_H__
#define __C2SOFFERWALL_H__

#ifdef __cplusplus
extern "C" {
#endif


	//  -------------------------- For single Game --------------------------- //
	// Single Game means that client don't communicate with the game server
	typedef enum _CS_OFFERWALL_REWARD_STATE
	{
		OFFERWALL_REWARD_CANCEL 		= 1,	// forbid reward
		OFFERWALL_REWARD_FINISH 		= 2,	// finish reward process
		OFFERWALL_REWARD_IN_PROGRESS 	= 3,	// in progress
		OFFERWALL_REWARD_SUCCESS		= 4,	// Success

	}CS_OFFERWALL_REWARD_STATE;

	typedef void (*OfferwallRewardCB)(int error, const char* errorMessage, int result, const char* eventID, const char* assetCode, int assetAmount);		// Reward callback

	// ------------------------------------------------------------------------ //
    


    typedef  enum _OFFERWALL_RESULT
    {
        OFFERWALL_OPEN              	= -11,
        OFFERWALL_CLOSE             	= -12,
        OFFERWALL_NETWORK_DISCONNECT	= -13,
        OFFERWALL_ACTIVATION			= -14,
        OFFERWALL_DEACTIVATION			= -15,
    }OFFERWALL_RESULT;
    
    typedef void (*OfferwallCB)(OFFERWALL_RESULT result);


    void CS_OfferwallInitialize(const char* uid, int isUsingStaging, OfferwallCB callback);
    void CS_OfferwallInitializeEx(const char* uid, int isUsingStaging, OfferwallCB callback, OfferwallRewardCB rewardCallback);
    void CS_OfferwallSetLog(int isLog);
    void CS_OfferwallShow();
    void CS_OfferwallShowEx(const char* additionalInfo);
    int  CS_OfferwallGetState();

    // For Single Game
    void CS_OfferwallRewardFinish();

    
#ifdef __cplusplus
};
#endif


#endif
