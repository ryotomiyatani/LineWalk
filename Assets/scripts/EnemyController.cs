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


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}
		
	void OnTriggerEnter( Collider other )
	{
		if(other.gameObject.tag == "Block"){

			Destroy (gameObject);
			reduceSlim += 1;
			GameController.Instance.score += 10;

		}
	}

}