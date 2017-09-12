using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour {
	public float time = 10f;

	private GameObject datonatorRange;


	// Use this for initialization
	void Start () {

		datonatorRange = transform.FindChild ("DetonatorRange").gameObject;
		Debug.Log (datonatorRange);
		datonatorRange.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		//		bombPos = GameObject.Find ("Bomb");
	}



	void OnCollisionStay(Collision other){
		if (datonatorRange.tag == "Stage") {
			Debug.Log ("a");
			datonatorRange.SetActive (true);
		}
	}

//	void OnCollisionExit(Collision other){
//		if (gameObject.tag == "Stage") {
//			datonatorRange.SetActive (false);
//		}
//	}

}

//	void OnCollisionEnter(Collision other){
//		if (other.gameObject.tag == "Block") {
//			Debug.Log ("a");
//			Destroy (other.gameObject);
//		}
//		if(other.gameObject.tag =="player"){
//			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
//			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;				
//		}
//	}
//	void OnCollisionExit(Collision other){
//		if (other.gameObject.tag == "player") {
//			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
//		}
//	}

//	private IEnumerator DestroyTime(){
//		yield return new WaitForSeconds (3.0f); 
//		gameObject.SendMessage ("Explode");
//		renBomb.enabled = false;
//		colBomb.enabled = false;
//		gameObject.SendMessage ("Explode");
//		explosionRange.radius = 10f;
//		yield return new WaitForSeconds (0.1f);
//		Destroy (gameObject);

//	}



