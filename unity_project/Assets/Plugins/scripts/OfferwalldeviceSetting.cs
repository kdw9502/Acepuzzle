using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfferwalldeviceSetting : MonoBehaviour {
	// Use this for initialization
	public GameObject offerwallLabel;
	void Start () {
		#if UNITY_IOS
			offerwallLabel.SetActive (false);
		#endif
		#if UNITY_ANDROID
		offerwallLabel.SetActive(true);
		#endif
	}
	

}
