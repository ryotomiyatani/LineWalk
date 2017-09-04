using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorController : MonoBehaviour {
	//アニメーションさせるコンポーネントを入れる
	private Animator myAnimator;
	//キャラクターのRigidbodyコンポーネントを入れる
	private Rigidbody  myRigidbody;
	//キャラクターの移動速度
	public float speed = 2.0f; 

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
	}
		
	void ChangeDirection(){
		//プレイヤーの向きを決める
		transform.rotation = Quaternion.LookRotation(transform.position + 
			(Vector3.right * Input.GetAxisRaw("Horizontal")) + 
			(Vector3.forward * Input.GetAxisRaw("Vertical")) 
			- transform.position);
					
	}
}
