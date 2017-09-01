using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour {
	public GameObject target;
	UnityEngine.AI.NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Cha_Knight");
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		agent.SetDestination(target.transform.position);
	}
}
