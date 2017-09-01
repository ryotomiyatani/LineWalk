using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class EnemyGenerator : MonoBehaviour {
	//スタート時Enemy生成されるポジション
	public List<Vector3>startPositionList = new List<Vector3>();
	//Enemy生成されるポジション
	public List<Vector3>positionList = new List<Vector3>();
	//スライムの種類
	public List<GameObject> slimList = new List<GameObject>(); 


//	private GameObject[] instPosition;
//
//	public GameObject[] slimPrefabs;
	//スライムの最大個数
	public int maxSlim = 3;

	// Use this for initialization
	void Start () {
		for (int i = 0; i <= 2; i++) {
			int positionNum = Random.Range (0, maxSlim);
			int slimNum = Random.Range (0, 4);
			GameObject slim = Instantiate (slimList [slimNum]) as GameObject;
			slim.transform.position = new Vector3 (startPositionList [positionNum].x, startPositionList [positionNum].y, startPositionList [positionNum].z);

			startPositionList.RemoveAt (positionNum);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
