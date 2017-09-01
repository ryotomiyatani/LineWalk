using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour {
	public float time = 10f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Invoke("DestroyTime", time);


	}
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Block") {
			Destroy (other.gameObject);
		}
		if(other.gameObject.tag =="player"){
				GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;				
			//rigidbody.constraints = RigidbodyConstraints.None;
							//rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
			}
		}
	void OnCollisionExit(Collision other){
		if (other.gameObject.tag == "player") {
			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
		}
	}

	void DestroyTime(){
		Destroy (gameObject);
	}
}

