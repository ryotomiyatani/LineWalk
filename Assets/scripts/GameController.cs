using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public readonly static GameController Instance = new GameController();
	//スコア
	public int score = 0;
	//爆弾生成個数
	public int bombCount = 5;

	public CharactorController Knight;

	public LifePanel lifePanel;


	//Bombの残数を表示するテキスト
	public GameObject bombCountText;
	//スコアを表示するテキスト
	public GameObject scoreText;
	//ゲーム終了時に表示するテキスト
	public GameObject stateText;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		lifePanel.UpdateLife (Knight.Life ());


		}
}

