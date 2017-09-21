using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour{
	

//	public readonly static GameController Instance = new GameController();
	//スコア
	public int score = 0;
		//爆弾生成個数
	public int bombCount = 5;
	//ナイトのスクリプト
	public CharactorController Knight;
	//スライムのスクリプト
	public EnemyController slimController;
	//ライフパネルスクリプト
	public LifePanel lifePanel;


//	//Bombの残数を表示するテキスト
//	public GameObject bombCountText;
	//スコアを表示するテキスト
	public GameObject scoreText;
//	//ゲーム終了時に表示するテキスト
//	public GameObject stateText;
	//ゲームオーバー時のスコアテキスト
	private GameObject endScoreText;

	//ハイスコアを表示するテキスト
	public Text highScoreLabel;
	//スタート画面に戻るボタン
	public GameObject startButton;


	//コイン生成リスト
	public List<Vector3>coinPosition = new List<Vector3>();

	static public GameController Instance ;
	void Awake()
	{
		Debug.Log (score);
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);

		}
	}


	public void StartScene(){
		Destroy (gameObject);
		Application.LoadLevel ("StartScene");
	}




	// Use this for initialization
	void Start () {
		Time.timeScale = 1f;
		startButton = GameObject.Find ("Canvas/StartReturn");
		startButton.SetActive (false);

		//ゲームオーバー時に表示するスコアを表示するためのテキスト
		endScoreText = GameObject.Find("EndScoreLabel");

		scoreText = GameObject.Find("ScoreText");

		
	}
	
	// Update is called once per frame
	void Update () {
//		PlayerPrefs.DeleteKey ("HighScore");
		highScoreLabel.text = "High Score：" + PlayerPrefs.GetInt("HighScore") + "pt";

		this.scoreText.GetComponent<Text> ().text = "Score " + score + "pt";

		lifePanel.UpdateLife (Knight.Life ());
		if (PlayerPrefs.GetInt ("HighScore") < score) 
		{
			PlayerPrefs.SetInt ("HighScore", score);

		}
		if (Knight.Life() == 0) {
			Time.timeScale = 0f;

			this.endScoreText.GetComponent<Text> ().text = "Score：" + score + "pt";

			startButton.SetActive (true);


		}
	}
}

