using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour {
	public float time = 10f;

	public GameObject Detonator;
	public GameObject bombPos;
	public Renderer ren; 
	public Transform minGoalX, maxGoalX;
	public Transform minGoalZ, maxGoalZ;

	const int maxPosition = 9;

	Vector3[] positions = new Vector3[maxPosition];



	// Use this for initialization
	void Start () {

		Debug.Log (ren.enabled);
		Collider[] col = GetComponents<BoxCollider>();

		Debug.Log (col[1]);
	}
	
	// Update is called once per frame
	void Update () {

//		Instantiate (Detonator, bombPos.transform.position, Quaternion.identity);
	//	this.Detonator = GameObject.Find ("Detonator-Base");
		bombPos = GameObject.Find ("Bomb");
		Invoke("DestroyTime", time);


	}
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Block") {

			Destroy (other.gameObject);
		}
		if(other.gameObject.tag =="player"){
				GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;				
			}
		}
	void OnCollisionExit(Collision other){
		if (other.gameObject.tag == "player") {
			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
		}
	}

	void DestroyTime(){
//		gameObject.SendMessage ("Explode");
		Destroy (gameObject);

	}

	void LineMax(){
	//	NavMeshAgent.CalculatePath(Vector3 targetPosition, NavMeshPath path);
	}
}

