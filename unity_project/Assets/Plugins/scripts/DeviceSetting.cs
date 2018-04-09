using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceSetting : MonoBehaviour {
	// Use this for initialization
	public GameObject offerwallLabel;
	public GameObject eventLabel;
	public GameObject noticeLabel;
	void Start () {
		#if UNITY_IOS
			offerwallLabel.SetActive (false);
		#endif
		#if IOS_SIMULATOR
		evnentLabel.SetActive(false);
		noticeLabel.SetActive(false);
		#endif
		#if UNITY_ANDROID
		offerwallLabel.SetActive(true);
		#endif
	}
	

}
