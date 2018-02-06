using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScript : MonoBehaviour {
	public UIPanel pausePanel;
	public void ClosePauseMenu(){
		pausePanel.gameObject.SetActive (false);
		GameManager.instance.nowGameState = GameManager.GameState.play;
		//Time.timeScale = 1f;
	}
	public void OpenPauseMenu(){

		pausePanel.gameObject.SetActive (true);
		GameManager.instance.nowGameState = GameManager.GameState.stop;
		//Time.timeScale = 0.01f;
	}
}
