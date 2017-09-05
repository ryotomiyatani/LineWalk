using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorController : MonoBehaviour {
	//アニメーションさせるコンポーネントを入れる
	private Animator myAnimator;
	//ナイトのRigidbodyコンポーネントを入れる
	private Rigidbody  myRigidbody;
	//ナイトの移動速度
	public float speed = 2.0f;
	//ナイトのライフ
	public int life = 3;
	//動きを減退させる
	private float coefficient = 0.0f;
	//ゲーム終了の判定
	private bool isEnd = false;

	int count = 0;
	bool isHit = false;


	UnityEngine.AI.NavMeshAgent agent;


	// Use this for initialization
	void Start () {
		//アニメーターコンポーネントを取得
		myAnimator = GetComponent<Animator>();
		myRigidbody = GetComponent<Rigidbody> ();
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
		if (isHit && count == 0) {
			// 当たったときの処理
			count = 30; 
			isHit = true;
		}

		if (count > 0) {
			--count;
			if (count <= 0) {
				// 無敵時間の終わり
				count = 0;

				isHit = false;
			}
		}

		if (this.isEnd) {
//			this.transform.rotation.x *= this.coefficient;
			this.speed *= this.coefficient;

		}
		Debug.Log (life);
	}
		
	void ChangeDirection(){
		//プレイヤーの向きを決める
		transform.rotation = Quaternion.LookRotation(transform.position + 
			(Vector3.right * Input.GetAxisRaw("Horizontal")) + 
			(Vector3.forward * Input.GetAxisRaw("Vertical")) 
			- transform.position);
					
	}

	void OnTriggerEnter(Collider other){
		//スライムに衝突した時

			if (other.gameObject.tag == "Slim") {

				if (life == 0) {
					this.isEnd = true;
				}
			if (!isHit) {
				isHit = true;
			}
				life -= 1;
			Debug.Log (life);
			}
		}
	}

