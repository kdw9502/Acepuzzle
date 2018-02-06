using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour {
	public GameObject ResetConfirmPanel;
	// Use this for initialization
	public void ResetConfirmPanelOn(){
		ResetConfirmPanel.SetActive (true);
	}
	public void Yes(){
		PlayerPrefs.DeleteAll ();
		ResetConfirmPanel.SetActive (false);
	}
	public void No(){

		ResetConfirmPanel.SetActive (false);
	}
}
