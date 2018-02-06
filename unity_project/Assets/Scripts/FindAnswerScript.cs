using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class FindAnswerScript : MonoBehaviour {
	List<bool[]> linearMatrix;
	int tableSize;
	bool[] isAnswerArray;
    public UILabel hintLabel;
	List<bool[]> MakeMatrix(){
		//initialize
			linearMatrix = new List<bool[]> ();
			for (int i = 0; i < tableSize * tableSize; i++) 
				linearMatrix.Add (new bool[tableSize * tableSize + 1]);



		//table represent [0,0] coin click[1,0]^click[0,1]
		for (int y = 0; y < tableSize; y++) {
			for (int x = 0; x < tableSize; x++) {
				if (x-1 >=0) {//if left exist
					linearMatrix[y*tableSize+x][y*tableSize+x-1]= true;
				}
				if (x+1 < tableSize) {//if right exist
					linearMatrix[y*tableSize+x][y*tableSize+x+1]= true;

				}
				if(y-1>=0){//if upside exist
					linearMatrix[y*tableSize+x][(y-1)*tableSize+x]= true;

				}
				if (y + 1 < tableSize) {//if downside exist
					linearMatrix[y*tableSize+x][(y+1)*tableSize+x]= true;

				}
			}
		}
	 

		//last one is represent coin state
		for (int y = 0; y < tableSize; y++) {
			for (int x = 0; x < tableSize; x++) {
				linearMatrix[y*tableSize+x][tableSize*tableSize ]=GameManager.instance.coinStateArray [y, x]==GameManager.coinState.white? true:false;
			}
		}

		return linearMatrix;

	}
	void GaussJordanElem(){
		int first=0;
		/*
		string mat="";
		for (int i = 0; i < tableSize*tableSize; i++) {

			for (int j = 0; j < tableSize*tableSize+1; j++) {


				mat = mat + (linearMatrix [i] [j] ? 1 : 0);

			}
			mat=mat+"\n";
		}
		print (mat);
		*/
		for (int i = 0; i < tableSize*tableSize; i++) {

			for (int j = 0; j < tableSize*tableSize; j++) {
				if (linearMatrix [i] [j]) {
					first = j;
					break;
				}
			}
			for (int j = 0; j < tableSize*tableSize; j++) {
				
				if (i != j && linearMatrix [j] [first]==true) {
					for (int k = 0; k < tableSize * tableSize+1; k++) {
						linearMatrix [j] [k] =linearMatrix[j][k]^linearMatrix [i] [k];
					}
				}
			}
		} 

		bool[] temp;
		int pivot = 0;
		for (int i = 0; i < tableSize * tableSize; i++) {
			
			for (int j = i; j < tableSize*tableSize; j++) {
				
				if (linearMatrix [j] [pivot]) {
					temp = linearMatrix [pivot];
					linearMatrix [pivot] = linearMatrix [j];
					linearMatrix [j] = temp;
					pivot++;
					break;
				}
			}
		}
		/*
		mat="";
		for (int i = 0; i < tableSize*tableSize; i++) {
			
			for (int j = 0; j < tableSize*tableSize+1; j++) {
				

				mat = mat + (linearMatrix [i] [j] ? 1 : 0);

			}
			mat=mat+"\n";
		}
		print (mat);
		*/
	}

	bool FindAnswer(){

		bool fail = true;
		isAnswerArray = new bool[tableSize*tableSize];
		for (int i = 0; i < tableSize*tableSize; i++) {
			if (linearMatrix [i] [tableSize * tableSize]) {
				fail = true;
				for (int j = 0; j < tableSize*tableSize; j++) {
					
					if (linearMatrix [i] [j]) {
						isAnswerArray [i] = true;
						fail = false;
						break;
					}
				}
				if (fail)
					return false; //if one matrix row 000..001 has no answer;
			}
		}
		return true;
	}
	public void PrintAnswer()
	{
		if (GameManager.instance.nowGameState == GameManager.GameState.stop)
			return;
		tableSize = GameManager.instance.tableSize;
		MakeMatrix ();
		GaussJordanElem ();
		if (FindAnswer ()) {
			for (int i = 0; i < tableSize*tableSize; i++) {
				if (isAnswerArray [i] == true) {
					print (i);
					print (""+(i / tableSize+1) + "행" + (i % tableSize+1) + "열");
				}
			}
		} else {
			print ("fail");
		}
	}
	public void StartHintCoroutine(){
		if (GameManager.instance.nowGameState == GameManager.GameState.stop)
			return;
		tableSize = GameManager.instance.tableSize;
		StartCoroutine (HintButtonClick());
	}
	IEnumerator HintButtonClick(){
		MakeMatrix ();
		yield return null;
		GaussJordanElem ();
		yield return null;
		if (FindAnswer ()) {
            GameManager.instance.onePickButton.isEnabled = false;
            GameManager.instance.hintButton.isEnabled = false;
            for (int i = 0; i < tableSize*tableSize; i++) {
				
				if (isAnswerArray [i] == true) {							
					print (""+(i / tableSize)+" "+(i % tableSize));
					GameManager.instance.coinArray[i / tableSize,i % tableSize].GetComponent<TweenColor>().enabled=true;
					yield return new WaitForSeconds(0.1f);
                    

                }
			}
            for (int i = 0; i < tableSize * tableSize; i++)
            {
                if (isAnswerArray[i] == true)
                {
                    GameManager.instance.coinArray[i / tableSize, i % tableSize].GetComponent<TweenColor>().enabled = false;
                    GameManager.instance.coinArray[i / tableSize, i % tableSize].GetComponent<TweenColor>().ResetToBeginning();
                }
            }
            GameManager.instance.isHintUsed = true;

            
		}


		else{
            hintLabel.text = "정답 없음!";
            Invoke("ChangeHintLabel", 5.0f);
		}
	}
    void ChangeHintLabel()
    {

        hintLabel.text = "힌트";
    }

}
