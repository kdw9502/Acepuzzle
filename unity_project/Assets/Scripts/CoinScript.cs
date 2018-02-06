using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {
	public int x,y;// where this ball is  on table (not position)
	// Use this for initialization
	[HideInInspector]
	public UIButton ChanceButton;
	void OnClick(){
		SFXManager.instance.PlayCoin ();
		if (GameManager.instance.nowGameState != GameManager.GameState.play)
			return;
		if (GameManager.instance.useChance) {
			GameManager.instance.ChangeOneCoinColor (y, x);
			GameManager.instance.useChance = false;

			GameManager.instance.onePickButton.isEnabled = false;
            GameManager.instance.hintButton.isEnabled = false;

		}else {
			GameManager.instance.ChangeAdjustCoinColor (y, x);
		}

		if (GameManager.instance.undoList.Count != 0) {
			GameManager.instance.undoButton.isEnabled = true;
		}
		else {
			GameManager.instance.undoButton.isEnabled = false;

		}
		if(GameManager.instance.CheckEnd())
        {
			GameManager.instance.StartCoroutine(GameManager.instance.EndingPerfomance(y,x));
           
        }
	}
}
