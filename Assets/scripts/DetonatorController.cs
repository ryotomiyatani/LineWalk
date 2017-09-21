using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetonatorController : MonoBehaviour {

	//親オブジェクトのコライダーを取得
	public SphereCollider explosionRange;
	//子オブジェクトのコライダーを取得
	public SphereCollider bombPos;

	//子オブジェクトを取得
	public GameObject childBomb;

	//子の子オブジェクトを取得
	private GameObject datonatorRange;

	//爆弾生成可能個数
	public GameObject bombCount;
	//爆発音のサウンド
	public AudioSource bombSE;


	// Use this for initialization
	void Start () {
//		controller = GetComponent<CharacterController>();
		//シーン中のBombCountオブジェクトを取得
		bombCount = GameObject.Find("BombCount");

		//親オブジェクトのコライダーを取得
		explosionRange = gameObject.GetComponent<SphereCollider>();

		//AudioSourceコンポーネントを取得
		bombSE = GetComponent<AudioSource>();

		//子オブジェクトのコライダーを取得
		bombPos = childBomb.GetComponent<SphereCollider> ();
		StartCoroutine ("DestroyTime");
	}
	
	// Update is called once per frame
	void Update () {

	}
	//爆弾の処理
		private IEnumerator DestroyTime(){
			explosionRange.enabled = false;
			yield return new WaitForSeconds (3.0f); 
			childBomb.tag = "Block";
			gameObject.SendMessage ("Explode");
			bombSE.PlayOneShot (bombSE.clip);
			bombPos.radius = 3f;
			yield return new WaitForSeconds (0.1f);
			Destroy (childBomb);
		GameController.Instance.bombCount += 1;
		this.bombCount.GetComponent<Text> ().text = "Bomb Count：" + GameController.Instance.bombCount;

		}



}
