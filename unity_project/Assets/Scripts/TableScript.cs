using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableScript : MonoBehaviour {
	public static TableScript instance;
	public UISprite BG;
	UISprite Table;
	public const int BgBasicSize=315; //2*2 size
	public const int BgExpandSize=135;
	public GameObject Panel;
	void Awake(){
		if (TableScript.instance == null)
			TableScript.instance = this;
			Table = GetComponent<UISprite> ();
	}


	public void MakeTable(int TableSize){
		int index = TableSize - 2;
		int width = BgBasicSize + BgExpandSize * index;
		Table.width = width;
		Table.height = width;
		float Scale=1.0f;
        if (BG.width * 4 < BG.height * 3)// if width are smaller than 4:3
        {
            Scale= 0.85f*BG.width/width ;
        }
        else // width are too long(over 4:3 aspect)
        {
            Scale = 0.6f * BG.height / width;
        }
        if (Scale > 1.0f) Scale = 1f;
		Table.transform.localScale = new Vector3 (Scale, Scale, 1f);
		Panel.SetActive (true);

	

	}

}
