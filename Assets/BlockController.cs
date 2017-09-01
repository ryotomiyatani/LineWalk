using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {
	//生成するオブジェクトを取得
	public GameObject block;
	public GameObject blockPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//スペースを押したら
		if (Input.GetKeyDown (KeyCode.Space)) {
			//Instantiate( 生成するオブジェクト,  場所, 回転 );  回転はそのままなら↓
			Instantiate (block, new Vector3 (blockPos.transform.position.x, blockPos.transform.position.y, blockPos.transform.position.z), Quaternion.identity);
	}
}

}