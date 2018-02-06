using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorBoxConfirm : MonoBehaviour {
	public GameObject errorPanel;
	void OnPress(){
		SFXManager.instance.PlayMenu ();
		errorPanel.SetActive (false);

	}

}
