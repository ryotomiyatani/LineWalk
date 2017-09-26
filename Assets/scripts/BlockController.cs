
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockController : MonoBehaviour {
	//生成するオブジェクトを取得
	public GameObject block;
	public GameObject blockPos;

	//Bombの残数を表示するテキスト
	public GameObject bombCountText;

	//Bombを置く時のサウンド
	public AudioSource puttingBomb;


	// Use this for initialization
	void Start () {
		//シーン中のBombCountオブジェクトを取得
		bombCountText = GameObject.Find("BombCount");

		puttingBomb = GetComponent<AudioSource>();

	}

	// Update is called once per frame
	void Update () {
		//スペースを押したら爆弾生成
		if (GameController.Instance.bombCount > 0) {
		if (Input.GetKeyDown (KeyCode.Space)) {
				GameController.Instance.bombCount -= 1;

				puttingBomb.PlayOneShot (puttingBomb.clip);

				//Instantiate( 生成するオブジェクト,  場所, 回転 );  回転はそのままなら↓
				Instantiate (block, new Vector3 (blockPos.transform.position.x, blockPos.transform.position.y, blockPos.transform.position.z), Quaternion.Euler (180, 0, 0));
				this.bombCountText.GetComponent<Text> ().text = "Bomb Count：" + GameController.Instance.bombCount;

			}
		}
	}

}