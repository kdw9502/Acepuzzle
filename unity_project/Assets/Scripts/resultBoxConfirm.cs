using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resultBoxConfirm : MonoBehaviour {
	public UIPanel InputPanel;
	public UIPanel resultPanel;
	// Use this for initialization

	// Update is called once per frame
	void OnPress(){
		SFXManager.instance.PlayMenu ();
		InputPanel.gameObject.SetActive (true);
		resultPanel.gameObject.SetActive(false);
	}
}
