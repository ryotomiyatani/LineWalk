using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private List<GameObject> hitObjects = new  List<GameObject> ();

	public GameObject slim;

	// Use this for initialization
	void Start () {
//		Instantiate(slim, new Vector3(15, 0.5, -14.5));
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		Debug.Log ("hirObjects");
		if (hitObjects.Count >= 2) {
			Destroy (gameObject);
		}
		hitObjects.Clear();
	}

	void OnCollisionStay( Collision other )
	{
		if(other.gameObject.tag == "Block"){
		// 衝突しているオブジェクトをリストに登録する
		hitObjects.Add(other.gameObject);
		}
	}

	//	Collider GetCollider(GameObject gameObject)
	//	{
	//		Collider collider = gameObject.GetComponent<Collider>();
	//		return collider;
	//	}
}
