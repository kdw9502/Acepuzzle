using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBoxConfirm : MonoBehaviour {
	public GameObject InputPanel;
	public UILabel size;
	public GameObject ErrorPanel;
	int parsedSize;
	void Start(){
		size.text = "0";
	}

	public void OnClick(){
		SFXManager.instance.PlayMenu ();
		int parsedSize = 3;
		bool error = false;
		try {
			parsedSize=int.Parse(size.text);
		} catch (System.Exception ex) {
			ErrorPanel.SetActive (true);
			error = true;
		}
		if (!error) {
			if (parsedSize < 3 || parsedSize > 12) {				
				error = true;
			}
		}

		if (!error) {
			InputPanel.SetActive (false);
			GameManager.instance.ReadyToPlay (parsedSize);
		} else {
			ErrorPanel.SetActive (true);
		}
	}
}
