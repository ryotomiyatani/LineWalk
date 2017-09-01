using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	Vector3 diff;

	public GameObject charactorObj;
	public float differenceZ;
	public float differenceX;

	// Use this for initialization
	void Start () {
		//キャラクターオブジェクトを取得
		charactorObj = GameObject.Find("Cha_Knight");
		//キャラクターとカメラの位置を求める
		differenceZ = charactorObj.transform.position.z - this.transform.position.z;
		differenceX = charactorObj.transform.position.x - this.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		//キャラクターの位置に合わせてカメラを移動
		transform.position = new Vector3(this.charactorObj.transform.position.x-differenceX, this.transform.position.y, this.charactorObj.transform.position.z-differenceZ);
		
	}
}
