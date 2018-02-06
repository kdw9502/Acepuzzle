using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScript : MonoBehaviour {
	public List<UILabel> Labels;
	int LabelIndex=0;
	public UIButton prevButton;
	public UIButton nextButton;
	//public GameObject Parent;
	// Use this for initialization
	void OnEnable () {
		Labels [LabelIndex].gameObject.SetActive (true);
		if (LabelIndex == 0)
			prevButton.isEnabled = false;
		else if (LabelIndex == Labels.Count - 1)
			nextButton.isEnabled = false;
	}
	public void HelpActive(){
		gameObject.SetActive (true);
	}
	public void HelpInActive(){
		Labels [LabelIndex].gameObject.SetActive (false);
		gameObject.SetActive (false);
	}
	public void nextText(){
		if (LabelIndex == Labels.Count-1) {
			return;
		}
		Labels [LabelIndex].gameObject.SetActive (false);
		Labels [++LabelIndex].gameObject.SetActive (true);
		if (LabelIndex == Labels.Count - 1) {
			nextButton.isEnabled = false;
		}
		if (LabelIndex == 1) {
			prevButton.isEnabled = true;
		}
	}
	public void prevText(){
		if (LabelIndex == 0) {
			return;
		}
		Labels [LabelIndex].gameObject.SetActive (false);
		Labels [--LabelIndex].gameObject.SetActive (true);
		if (LabelIndex == 0) {
			prevButton.isEnabled = false;
		}
		if (LabelIndex == Labels.Count-2) {
			nextButton.isEnabled = true;
		}
	}


}
