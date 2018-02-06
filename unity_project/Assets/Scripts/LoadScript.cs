using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScript : MonoBehaviour {
	public UIPanel InputPanel;


	public void DoNotLoad(){
		PlayerPrefs.SetInt ("Saved",0);
	}
	public void LoadGame(){
		InputPanel.gameObject.SetActive (false);
		GameManager.instance.LoadData ();
	}
	public void LoadPanelOFF(){
		gameObject.SetActive (false);
	
	}

	public void LoadPanelOn(){
		gameObject.SetActive (true);
	}
}
