using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour {
	public float time = 10f;

	public GameObject Detonator;
	public GameObject bombPos;

	// Use this for initialization
	void Start () {
		Collider[] col = GetComponents<Collider>();
//		col[1].Size = new Vector3 (5f, 0.3f, 0.3f);
//		int i = 0;
//		foreach(Collider slimCol in col){
//			col[i++] = slimCol;
//		}
//		this.Detonator = (GameObject)Resources.Load ("Assets/Prefabs/Detonator-Base");
//		Debug.Log (Detonator);
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
	//	col[1].Size = new Vector3 (5f, 0.3f, 0.3f);
	//	Instantiate (Detonator, bombPos.transform.position, Quaternion.identity);
		Destroy (gameObject);


	}
}

