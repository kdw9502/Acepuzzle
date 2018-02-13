using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UndoData{
	public int x,y,type;
	public UndoData(int _x,int _y,int _type){
		x = _x;
		y = _y;
		type = _type;
	}
}

public class GameManager : MonoBehaviour {
	public static GameManager instance;

	public int tableSize;
	float rootScale;
	public UISprite readySprite;// Sprite ready and go
	public TableScript table;   // Ingame table
	UIPanel tablePanel;			// IngameObject Panel
	public UIPanel resultPanel; 
	public GameObject coinPrefab;
	//List<GameObject> coinList;// replaced with Array
	public GameObject[,] coinArray;	// Array of coins' gameObject
	float totalTime=0f;			// Ingame time
	public enum coinState{black,white};
	public coinState[,] coinStateArray;// Array of every coin's state
	[HideInInspector]
	public enum GameState{ play,stop};
	public UILabel resultLabel; // print Total time to clear game
	public UILabel infoLabel;	// print Cleared game information (4 X 4 , 2color etc)
	public UILabel recordLabel; // best record of this size
    public UILabel newRecordLabel;
	public UISlider timeBar;	// display remain time to next chance 
	public UIButton onePickButton;
    public UIButton hintButton;
    public UIButton backButton; // back to menu button
	public UIButton undoButton; 
	public UIPanel inputPanel;	// Front menu Pannel
	public List<float> chanceTerm;
	float chanceTime;			// Time since previos chance
	public UIPanel loadPanel;
	int[,] SaveTable;
	public Stack<UndoData> undoList;
    public bool isHintUsed=false;
	[HideInInspector]
	public bool useChance=false;
	int listIndex=0;			// Index that incresed along time pass
	[HideInInspector]
	public GameState nowGameState=GameState.stop;

    /* Awake
     parameter=GameManager.instance;
    */
	void Awake(){
		//for singletone pattern
		if (GameManager.instance == null)
			GameManager.instance = this;
		if (PlayerPrefs.GetInt ("Saved") == 1) {
			loadPanel.gameObject.SetActive (true);
		}

		
	}
    /*
     * Start
     * parameter:tablePanel, nowGameState, undoList;
    */
    void Start () {
		tablePanel= table.transform.parent.gameObject.GetComponent<UIPanel>();
		nowGameState = GameState.stop;
		undoList = new Stack<UndoData> ();
		//for Instantiate scaling
		rootScale=GameObject.Find("UI Root").transform.localScale.x;
		SFXManager.instance.source.mute=PlayerPrefs.GetInt ("SFX",0)==1?true:false;
		GameManager.instance.GetComponent<AudioSource> ().mute = PlayerPrefs.GetInt ("BGM")==1?true:false;
	}
	/*
     * parameter:totalTime,chanceTime 
     */
	void Update () {
		switch (nowGameState) {
		case GameState.play:
			totalTime += Time.deltaTime;
			chanceTime += Time.deltaTime;
			ChanceCheck ();
			if (Input.GetKeyDown (KeyCode.Escape)) {
				SaveData ();
			}
			break;
		

		case GameState.stop:
			// Escape to Quit when game is not played
			if (Input.GetKeyDown (KeyCode.Escape)) {
				Application.Quit ();
			}
			break;
		}


	}
	/* Check chanceTime and add chance
     * parameter:chanceTiem,chanceTerm,listIndex,chanceButton,timebar
     * 
     */    
	void ChanceCheck(){
		if (chanceTime > chanceTerm [listIndex]) {
			chanceTime = 0f;

			onePickButton.isEnabled = true;
            hintButton.isEnabled = true;
			if (listIndex < chanceTerm.Count-1)
				listIndex++;
		}
		timeBar.value = 1 - (chanceTime / chanceTerm [listIndex]);

	}

	/* Reset GameData
     * parameter: nowGameState,totalTime,chanceTiem,listIndex,backButton,chanceButton,tableSize
     *            tablePanel, table, coinArray,coinStateArray,coinStateArray,undoList,undoButton
     * 
     */
	void ResetData(int _parsedsize){
		nowGameState = GameState.stop;
		totalTime = 0;
		chanceTime = 0;
		listIndex = 0;
        isHintUsed = false;
		backButton.isEnabled = false;
		onePickButton.isEnabled = false;
        hintButton.isEnabled = false;
		tableSize = _parsedsize;
		tablePanel.gameObject.SetActive (true);
		table.MakeTable(tableSize);
		coinArray=new GameObject[tableSize,tableSize];
		coinStateArray = new coinState[tableSize, tableSize];
		for (int i = 0; i < tableSize; i++) {
			for (int j = 0; j < tableSize; j++) {
				coinStateArray[i,j] = coinState.black;				
			}
		}
		undoList.Clear ();
		undoButton.isEnabled = false;
		timeBar.value = 1;
	}
	public void SaveData(){


		PlayerPrefs.SetInt ("Saved",1);
		PlayerPrefs.SetFloat ("totalTime",totalTime);
		PlayerPrefs.SetFloat ("chanceTime",chanceTime);
		PlayerPrefs.SetFloat ("Chance",onePickButton.isEnabled?1:0);
		PlayerPrefs.SetInt ("TableSize",tableSize);
		PlayerPrefs.SetInt ("listIndex",listIndex);
		for (int i = 0; i < tableSize; i++) {
			for (int j = 0; j < tableSize; j++) {
				PlayerPrefs.SetInt ("T"+(i*tableSize+j), (int)coinStateArray[i,j]);
			}

		}
		Application.Quit ();
	}

	public void LoadData(){
		nowGameState = GameState.stop;
		totalTime = 0;
		chanceTime = 0;
		listIndex = 0;
		backButton.isEnabled = false;


		undoList.Clear ();
		undoButton.isEnabled = false;
		PlayerPrefs.SetInt ("Saved",0);
		totalTime=PlayerPrefs.GetFloat ("totalTime");
		chanceTime=PlayerPrefs.GetFloat ("chanceTime");
		onePickButton.isEnabled=PlayerPrefs.GetFloat ("Chance")==1?true:false;
        hintButton.isEnabled= PlayerPrefs.GetFloat("Chance") == 1 ? true : false;
        tableSize =PlayerPrefs.GetInt ("TableSize");
		listIndex = PlayerPrefs.GetInt ("listIndex");

		tablePanel.gameObject.SetActive (true);
		table.MakeTable(tableSize);
		coinArray=new GameObject[tableSize,tableSize];
		coinStateArray = new coinState[tableSize, tableSize];
		SaveTable = new int[tableSize, tableSize];
		for (int i = 0; i < tableSize; i++) {
			for (int j = 0; j < tableSize; j++) {
				coinStateArray[i,j] = coinState.black;
				SaveTable [i, j] = PlayerPrefs.GetInt ("T"+(i*tableSize+j));
			}
		}

		undoList.Clear ();
		undoButton.isEnabled = false;
		ReadyToPlay (tableSize,true);
	}
	/* ResetData and Init Game  */
	/* Called by Onclick of inputPanel/InputBox/Button 
     * ReadyToPlay() -> makeCoin()-> GoToPlay()-> StartPlay()
     * parameter: parsedsize (input from inputbox OnPress() ), readySprite
     */
	public void ReadyToPlay(int _parsedsize,bool isLoad=false){

		if (!isLoad) {
			ResetData (_parsedsize);
		}
		StartCoroutine( MakeCoins (tableSize,isLoad));
		SFXManager.instance.PlayReady ();
		readySprite.gameObject.SetActive (true);
		readySprite.spriteName="Ready";
        readySprite.MakePixelPerfect();
		// Delay table*table time to wait to complete makecoins 
		// TODO: Is it need? How about Ivoke 2second after makecoins()? 
		//Invoke ("GoToPlay", 2.0f + tableSize * tableSize * 0.026f);
	}
    /*
     * Display Go Sprite 
     * parameter: readySprite
     * ReadyToPlay() -> makeCoin()-> GoToPlay()-> StartPlay()
     */
    void GoToPlay(){
		SFXManager.instance.PlayGo ();
		readySprite.spriteName="Go";
		readySprite.MakePixelPerfect ();
		Invoke ("StartPlay",1.0f);
	}
    /*StartGame
     * parameter: readySprite
     * ReadyToPlay() -> makeCoin()-> GoToPlay()-> StartPlay() 
     */
    void StartPlay(){
		readySprite.gameObject.SetActive(false);
		nowGameState = GameState.play;
		backButton.isEnabled = true;
	}
	/* make Coins with Delay (to better look)
     * parameter: tableSize , coinArray,coinStateArray
     * 
     *
     */
	IEnumerator MakeCoins(int TableSize,bool isLoad=false){
		bool isEven; //is Size even number?
		isEven = (TableSize & 1)==1 ? false : true;

		float offset = TableScript.BgExpandSize * (TableSize / 2 - (isEven?1:0) / 2.0f );
		Vector3 LeftUpper = new Vector3 (-offset,offset,0);
		Vector3 coinPos ;
		for (int i = 0; i <TableSize; i++) {
			
			for (int j = 0; j < TableSize; j++) {
				
				coinPos =LeftUpper+ new Vector3 (TableScript.BgExpandSize*j,-TableScript.BgExpandSize*i , 0);

				//coinList.Add( Instantiate (coinPrefab,table.transform.localScale.x*rootScale*coinPos,Quaternion.identity,table.gameObject.transform));
				coinArray[i,j]= Instantiate (coinPrefab,table.transform.localScale.x*rootScale*coinPos+table.transform.position,Quaternion.identity,table.gameObject.transform);
				/* Coins need to remember their Index */
				coinArray [i, j].GetComponent<CoinScript> ().y=i;
				coinArray [i, j].GetComponent<CoinScript> ().x=j;

				coinStateArray [i, j] = coinState.black;
				yield return new WaitForSecondsRealtime(1f/(TableSize*TableSize));
			}

		}
		if (!isLoad) {
            do
            {
                InitRandomChange();
            }while (CheckEnd()) ;
           
		} else {
			for (int i = 0; i < TableSize; i++) {
				for (int j = 0; j < TableSize; j++) {
					if(SaveTable[i,j]==1)
						ChangeOneCoinColor (i,j,true);
				}
			}
		}
        Invoke("GoToPlay",1f);
    }
    /*
     * Change Random Index coin's adjustCoin's color 
     * parameter :None
     */
    void InitRandomChange(){
		int x, y;
		int changeCount = tableSize * tableSize*4;
		for (int i = 0; i < changeCount; i++) {
			x = Random.Range (0,tableSize-1);
			y = Random.Range (0,tableSize-1);
			ChangeAdjustCoinColor (x, y,true);
		}
	}
    /* Change coin adjust to (x,y) coin 
     * parameter: coinArray,undoList, (x,y), bool noRecord( which add to undoList or not)
     * 
     *
     */
	public void ChangeAdjustCoinColor(int x,int y,bool noRecord=false){
		if(noRecord==false)
			undoList.Push (new UndoData(x,y,0));

		if (x-1 >=0) {//if left exist

			SwapCoinColor(coinArray[x-1,y].GetComponent<CustomUI2DSpriteAnimation>(),x-1,y);
		}
		if (x+1 < tableSize) {//if right exist

			SwapCoinColor(coinArray[x+1,y].GetComponent<CustomUI2DSpriteAnimation>(),x+1,y);
		}
		if(y-1>=0){//if upside exist

			SwapCoinColor(coinArray[x,y-1].GetComponent<CustomUI2DSpriteAnimation>(),x,y-1);
		}
		if (y + 1 < tableSize) {//if downside exist

			SwapCoinColor(coinArray[x,y+1].GetComponent<CustomUI2DSpriteAnimation>(),x,y+1);
		}

	}
    /*Change coin (x,y)
    * parameter: coinArray,undoList, (x,y), bool noRecord( which add to undoList or not)
    */
    public void ChangeOneCoinColor(int x,int y,bool noRecord=false){
		if(noRecord==false)
			undoList.Push (new UndoData(x,y,1));
		SwapCoinColor (coinArray [x, y].GetComponent<CustomUI2DSpriteAnimation>(), x, y);
	}
    /* Change Coin Color rules
     * parameter: coinSprite,coinStateArray
     * 
     * 
     */
	public void SwapCoinColor(CustomUI2DSpriteAnimation coinSprite,int x, int y){ // only for 2color , if you want more plz modify (add rules)
		if (coinStateArray[x,y]==coinState.black) {
			coinSprite.PlayBack ();
			coinStateArray[x,y] = coinState.white;
		}
		else if (coinStateArray[x,y]==coinState.white) {
			coinSprite.PlayBack ();
			coinStateArray[x,y] = coinState.black;
		}
	}
    /* check end of game and display result
     * parameter : nowCoinState,coinStateArray
         */
	public bool CheckEnd(){
		

		coinState nowCoinState = coinStateArray [0, 0];
		for (int i = 0; i < tableSize; i++) {
			for (int j = 0; j < tableSize; j++) {
				if (coinStateArray [i, j] != nowCoinState) {
					return false;
				}
			}
		}
//		nowGameState = GameState.stop;
//		Invoke("DisplayResult",0.7f);

		return true;
	}
    /* after end game, display Result
     * called by checkEnd
     * parameter: nowGameState,resultLabel,totalTime,infoLabel,TableSzie,PlayerPrefs,recordLabel,tablePanel,ResultPanel
         */
    public void DisplayResult()
    {
        float bestRecord;
        const float maxTime = (1<<20);
        SFXManager.instance.PlayClear ();
        nowGameState = GameState.stop;
        newRecordLabel.text = "";
        resultLabel.text = totalTime.ToString("#,0.##") + " 초";
        infoLabel.text = "" + tableSize.ToString() + " X " + tableSize.ToString() + " 사이즈";
        bestRecord = PlayerPrefs.GetFloat("Best" + tableSize, maxTime);
        if (isHintUsed)
        {
            newRecordLabel.color = Color.black;
            newRecordLabel.text = "힌트를 사용하여 기록되지 않습니다.";

        }
        else if ( totalTime < bestRecord)
        {
            PlayerPrefs.SetFloat("Best" + tableSize, totalTime);
            bestRecord = totalTime;
            newRecordLabel.color = Color.white;
            newRecordLabel.text = "신기록!";

        }
        if(bestRecord==maxTime)
        {
            recordLabel.text = "아직 클리어하지 못하였습니다.";
        }
        else
        {
            recordLabel.text = "" + tableSize + " X " + tableSize + "최고 기록\n" + bestRecord.ToString("#,0.##") + " 초";
        }

        StartCoroutine(DestroyCoins());
        tablePanel.gameObject.SetActive(false);
        resultPanel.gameObject.SetActive(true);

    }
    /* Back to main
     * called by Back button Onclick()
     * parameter: tablePanel,inputPanel,nowGameState
     * 
         */
	public void BackButtonClick(){
		StartCoroutine (DestroyCoins ());

		tablePanel.gameObject.SetActive (false);
		inputPanel.gameObject.SetActive (true);

		nowGameState = GameState.stop;
	}

    /* Destroy coins
     * called by displayResult, BackbuttonClick
     * parameter: coinStateArray,coinArray,tableSize
     * 
     */
	IEnumerator DestroyCoins(){
		for (int i = 0; i < tableSize; i++) {
			for (int j = 0; j < tableSize; j++) {
				Destroy( coinArray [i,j]);
			}
			yield return null;
		}
		coinStateArray = null;
		coinArray = null;

	}

	public void ChanceClick(){
		if (GameManager.instance.useChance) {
			GameManager.instance.useChance = false;

		}
		else if (onePickButton.isEnabled) {
			GameManager.instance.useChance = true;
		} 
	}
    /* Undo
     * parameter: undoList
     */
	public void Undo(){// only for 2color
		if (undoList.Count == 0) {

			return;
		}
		UndoData temp=undoList.Pop ();
		int x = temp.x;
		int y = temp.y;
		int type = temp.type;
		if (type == 0) {
			ChangeAdjustCoinColor (x, y,true);
		} else {
			ChangeOneCoinColor (x, y,true);
		}
		if (undoList.Count == 0)
			undoButton.isEnabled = false;
	}

	public IEnumerator EndingPerfomance (int i, int j)
    {

		bool[,] visit = new bool[tableSize, tableSize];
		Queue<int> que=new Queue<int>();
		int temp;
		nowGameState = GameState.stop;

		ChangeOneCoinColor (i, j,false);
		yield return new WaitForSeconds (0.3f);
		que.Enqueue(i*tableSize+j);
		visit [i, j] = true;
//		print (tableSize);
		while (que.Count != 0) {
			temp=que.Dequeue ();
			i = temp / tableSize;
			j = temp % tableSize;
			if (i > 0) {
				if (!visit [i - 1, j]) {
					ChangeOneCoinColor (i - 1, j, false);
					que.Enqueue ((i - 1) * tableSize + j);
					visit [i - 1, j] = true;
				}
			}
			if (i < tableSize-1) {
				if (!visit [i +1, j]) {
					ChangeOneCoinColor (i + 1, j, false);
					que.Enqueue ((i + 1) * tableSize + j);
					visit [i + 1, j] = true;
				}
			}
			if (j > 0) {
				if (!visit [i , j-1]) {
					ChangeOneCoinColor (i , j-1, false);
					que.Enqueue (i  * tableSize + j-1);
					visit [i , j-1] = true;
				}
			}
			if (j < tableSize - 1) {
				if (!visit [i , j+1]) {
					ChangeOneCoinColor (i , j+1, false);
					que.Enqueue (i  * tableSize + j+1);
						visit [i , j+1] = true;
				}

			}
			yield return new WaitForSeconds (0.1f);
		}
		yield return new WaitForSeconds (0.3f);
		DisplayResult ();
    }
}
/*TODO: Seperate to UndoScript
 * TODO: ChanceScript,BackButtonScript
 * TODO: resultBoxScript
 * 
 * 
 * 
 * 
 * 
 * 
 */