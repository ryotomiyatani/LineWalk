using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour{
	

//	public readonly static GameController Instance = new GameController();
	//スコア
	public int score = 0;
		//爆弾生成個数
	public int bombCount = 5;

	public CharactorController Knight;

	public EnemyController slimController;

	public LifePanel lifePanel;


//	//Bombの残数を表示するテキスト
//	public GameObject bombCountText;
//	//スコアを表示するテキスト
//	public GameObject scoreText;
//	//ゲーム終了時に表示するテキスト
//	public GameObject stateText;

	//スタート画面に戻るボタン
	public GameObject startButton;
	//結果画面のボタン
	public GameObject resultButton;

	static public GameController Instance ;
	void Awake()
	{
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);

		}
	}


	public void StartScene(){
		Application.LoadLevel ("StartScene");
	}

	public void ResultScene(){
		Application.LoadLevel ("ResultScene");
	}


	// Use this for initialization
	void Start () {
		Time.timeScale = 1f;

		startButton = GameObject.Find ("Canvas/StartReturn");
		startButton.SetActive (false);
		resultButton = GameObject.Find ("Canvas/ResultScene");
		resultButton.SetActive (false);
		Debug.Log (resultButton);
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (score);
		lifePanel.UpdateLife (Knight.Life ());


		if (Knight.Life() == 0) {
			Time.timeScale = 0f;
			Debug.Log(startButton);
			startButton.SetActive (true);
			resultButton.SetActive (true);
				Debug.Log(startButton);

			if (PlayerPrefs.GetInt ("HighScore") < score) 
			{
				PlayerPrefs.SetInt ("HighScore", score);
			}

		}
	}
}

