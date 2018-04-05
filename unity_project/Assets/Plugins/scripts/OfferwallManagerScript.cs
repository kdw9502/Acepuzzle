using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfferwallManagerScript : MonoBehaviour {
	#if UNITY_ANDROID
	static C2SOfferwallPlugin offerwallPlugin;
	OfferwallCallback offerwallCallback;
	OfferwallRewardCallback offerwallRewardCallback;

	class OfferwallCallback : C2SOfferwallCallback {
		public void onOfferwallCallback(int result) {
			switch(result) {
			case C2SOfferwallPlugin.OFFERWALL_OPEN:
				Debug.Log("onOfferwallCallback result : OFFERWALL_OPEN " + result);
				break;
			case C2SOfferwallPlugin.OFFERWALL_CLOSE:
				Debug.Log("onOfferwallCallback result : OFFERWALL_CLOSE " + result);
				break;
			case C2SOfferwallPlugin.OFFERWALL_ACTIVATION:
				Debug.Log("onOfferwallCallback result : OFFERWALL_ACTIVATION" + result);
				break;
			case C2SOfferwallPlugin.OFFERWALL_DEACTIVATION:
				Debug.Log("onOfferwallCallback result : OFFERWALL_DEACTIVATION" + result);
				break;
			default:
				Debug.Log("onOfferwallCallback result : error " + result);
				break;
			}
		}
	}

	class OfferwallRewardCallback : C2SOfferwallRewardCallback{
		public void onOfferwallRewardCallback(int error, string errorMessage, int result, string eventID, string assetCode, int assetAmount){
			switch (result) {
			case C2SOfferwallPlugin.OFFERWALL_REWARD_SUCCESS:
				Debug.Log("onOfferwallRewardCallback result : OFFERWALL_REWARD_SUCCESS");
				break;
			case C2SOfferwallPlugin.OFFERWALL_REWARD_FINISH:
				Debug.Log("onOfferwallRewardCallback result : OFFERWALL_REWARD_FINISH");
				break;
			case C2SOfferwallPlugin.OFFERWALL_REWARD_IN_PROGRESS:
				Debug.Log("onOfferwallRewardCallback result : OFFERWALL_REWARD_IN_PROGRESS");
				break;
			case C2SOfferwallPlugin.OFFERWALL_REWARD_CANCEL:
				Debug.Log("onOfferwallRewardCallback result : OFFERWALL_REWARD_CANCEL");
				break;

			default:
				Debug.Log("onOfferwallRewardCallback result : Not defined state");
				break;
			}
			Debug.Log("\n error: " + error.ToString() + 
				"\n errorMessage: " + errorMessage + 
				"\n result: " + result.ToString() + 
				"\n eventID: " + eventID + 
				"\n assetCode: " + assetCode + 
				"\n assetAmount: " + assetAmount.ToString());
		}
	}

	void Awake(){
		if (offerwallPlugin == null) {
			offerwallPlugin = gameObject.AddComponent<C2SOfferwallPlugin>();
			//offerwallPlugin = new C2SOfferwallPlugin();
		}
	}
	// Use this for initialization
	void Start () {
		offerwallCallback = new OfferwallCallback();
		// only single Mode
		offerwallRewardCallback = new OfferwallRewardCallback();


		offerwallPlugin.createPlugin();
		offerwallPlugin.setLogged(true);
		Debug.Log(offerwallPlugin.getVersion());
		InitTestServerSingle ();

	}

	void OnApplicationPause(bool isPause) {
		if (offerwallPlugin == null)
			return;
		if(isPause) {
			offerwallPlugin.onActivityPaused();
		} else {
			offerwallPlugin.onActivityResumed();
		}
	}

	// 아래 두 함수는 하이브 추가 후 실행
	public void InitLiveServer(){
		Debug.Log ("initialize_Live_Server");
		offerwallPlugin.initialize("1234214", false, offerwallCallback);
	}
	public void InitTestServer(){
		Debug.Log ("initialize_Test_Server");
		offerwallPlugin.initialize("21342135", true, offerwallCallback);
	}

	//게임서버가 없는 싱글모드 게임을 위한 Init()
	public void InitLiveServerSingle(){
		Debug.Log ("initializeEx_Live_Server");
		offerwallPlugin.initializeEx("12352135", false, offerwallCallback, offerwallRewardCallback);
	}
	public void InitTestServerSingle(){
		Debug.Log ("initializeEx_Live_Server");
		offerwallPlugin.initializeEx("12352135", true, offerwallCallback, offerwallRewardCallback);
	}
//	보상처리 완료 후, Offerwall 서버에 클라이언트에서 보상이 완료되었다고 알리기 위한 함수입니다.
//	싱글게임 전용 함수로 CS_OfferwallInitializeEx()으로 초기화 한 후, 클라이언트에서 보상처리를 모두 완료하고 Finish를 호출합니다. 
	public void RewardFinish(){
		Debug.Log ("rewardFinish");
		offerwallPlugin.rewardFinish();
	}

	public void ShowOfferwall(){
		Debug.Log ("showEx");
		offerwallPlugin.showEx("server:kr");
	}
	#endif
}
