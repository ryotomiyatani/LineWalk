using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
	//当たった個数リストに格納
	private List<GameObject> hitObjects = new  List<GameObject> ();
	//スライム取得
	public int slim;
	//スライムを減らすためのカウント
	public static int reduceSlim = 0;



	//スコアを表示するテキスト
	private GameObject scoreText;


	// Use this for initialization
	void Start () {
		scoreText = GameObject.Find("ScoreText");
	}

	// Update is called once per frame
	void Update () {

	}

//	void FixedUpdate(){
//		if (hitObjects.Count >= 2) {
//
//		}
//
//		hitObjects.Clear();
//	}

	void OnTriggerEnter( Collider other )
	{
		if(other.gameObject.tag == "Block"){

			Destroy (gameObject);
			reduceSlim += 1;
			GameController.Instance.score += 10;
			this.scoreText.GetComponent<Text> ().text = "Score " + GameController.Instance.score + "pt";


		}
	}

//	Collider GetCollider(GameObject gameObject)
//	{
//		Collider collider = gameObject.GetComponent<Collider>();
//		return collider;
//	}
}