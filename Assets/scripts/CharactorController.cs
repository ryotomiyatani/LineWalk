using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharactorController : MonoBehaviour {
	//アニメーションさせるコンポーネントを入れる
	private Animator myAnimator;
	//ナイトのRigidbodyコンポーネントを入れる
	private Rigidbody  myRigidbody;
	//ナイトのコライダーを入れる
	private Collider myCollider;
	//ナイトの移動速度
	public float speed = 2.0f;
	//ナイトのライフ
	const int DefaultLife = 3;
	//動きを減退させる
	private float coefficient = 0.0f;
	//ゲーム終了時に表示するテキスト
	public GameObject stateText;
	//スコアを表示するテキスト
	public GameObject scoreText;
	//ダメージ音を鳴らすサウンド
	public AudioSource damageSE;

	int life = DefaultLife;

	UnityEngine.AI.NavMeshAgent agent;


	public int Life(){
		return life;
	}



	// Use this for initialization
	void Start () {
		//コライダーコンポーネントを取得
		myCollider = GetComponent<Collider>();
		//アニメーターコンポーネントを取得
		myAnimator = GetComponent<Animator>();
		GetComponent<Animator> ().SetTrigger ("idle");
		//waitアニメーションを開始
		myAnimator.SetFloat("Mot_Knight@Wait",1);
		//Rigidbodyコンポーネントを取得
		myRigidbody = GetComponent<Rigidbody> ();
		//シーン中のstateTextオブジェクトを取得
		stateText = GameObject.Find("GameOver");
		//シーン中のscoreTextオブジェクトを取得
		scoreText = GameObject.Find("Score");
		//AudioSourceコンポーネントを取得
		damageSE = GetComponent<AudioSource>();

		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();


	}

	// Update is called once per frame
	void Update () {
		Vector3 move = Vector3.forward * Input.GetAxis("Vertical") + Vector3.right  * Input.GetAxis("Horizontal") ;
		agent.Move(move * Time.deltaTime * 5);
		if (Input.GetKey (KeyCode.LeftArrow)) {
			myRigidbody.transform.position += new Vector3(-speed, 0.0f, 0.0f) * Time.deltaTime;
			ChangeDirection ();

		}
		if( Input.GetKey(KeyCode.RightArrow) ){
			myRigidbody.transform.position += new Vector3(speed, 0.0f, 0.0f) * Time.deltaTime;
			ChangeDirection ();
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			myRigidbody.transform.position += new Vector3 (0.0f, 0.0f, speed) * Time.deltaTime;
			ChangeDirection ();
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			myRigidbody.transform.position += new Vector3 (0.0f, 0.0f, -speed) * Time.deltaTime;
			ChangeDirection ();
		}


	}

	void ChangeDirection(){
		GetComponent<Animator> ().SetTrigger ("RunTrigger");
		//プレイヤーの向きを決める
		transform.rotation = Quaternion.LookRotation(transform.position + 
			(Vector3.right * Input.GetAxisRaw("Horizontal")) + 
			(Vector3.forward * Input.GetAxisRaw("Vertical")) 
			- transform.position);

//		footSE.PlayOneShot (footSE.clip);
	}

	void OnCollisionEnter(Collision other){
		//スライムに衝突した時
		if (other.gameObject.tag == "Slim") {
			DamageController ();
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Block") {
			DamageController ();
		}
	}

	public void myColliderReturn(){
		//2秒後ナイトのコライダーを戻す
		myCollider.enabled = true;
	}

	public void DamageController(){
		damageSE.PlayOneShot (damageSE.clip);
		//スライムと接触時ライフを1削る
		life -= 1;
		GetComponent<Animator> ().SetTrigger ("DamageTrigger");
		if(life >= 0){
			//ナイトのコライダーを外す
			myCollider.enabled = false;
			Invoke("myColliderReturn", 2f);
		}
		if (life == 0) {

			this.stateText.GetComponent<Text> ().text = "Game Over";



		}
	}

}