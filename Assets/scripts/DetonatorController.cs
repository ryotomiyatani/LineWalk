using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetonatorController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("DetonatorTime", 10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void DetonatorTime(){

		gameObject.SendMessage ("Explode");
	}
}
