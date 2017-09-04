﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	//当たった個数リストに格納
	private List<GameObject> hitObjects = new  List<GameObject> ();
	//スライム取得
	public GameObject slim;
	//スライムを減らすためのカウント
	public static int reduceSlim = 0;
	// Use this for initialization
	void Start () {
//		Instantiate(slim, new Vector3(15, 0.5, -14.5));
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		if (hitObjects.Count >= 2) {
			Destroy (gameObject);
			reduceSlim += 1;
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

		Collider GetCollider(GameObject gameObject)
		{
			Collider collider = gameObject.GetComponent<Collider>();
			return collider;
		}
}
