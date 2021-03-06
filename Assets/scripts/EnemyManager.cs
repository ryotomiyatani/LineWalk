﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {
	//スタート時スライムが生成されるポジション
	public List<Vector3>startPositionList = new List<Vector3>();
	//スライムが生成されるポジション
	public List<Vector3>positionList = new List<Vector3>();
	//スライムの種類
	public List<GameObject> slimList = new List<GameObject>(); 


	//スライムの最大個数
	public int maxSlim = 3;
	//スライム数の初期化
	int currentSlim = 0;
	//スライムの最大個数を増やすためのスコア基準
	int slimCountMax = 500;



	// Use this for initialization
	void Start () {

		for (int i = 0; i <= 2; i++) {
			
			int positionNum = Random.Range(0,startPositionList.Count);
			int slimNum = Random.Range (0, 4);
			GameObject slim = Instantiate (slimList [slimNum]) as GameObject;
			slim.transform.position = new Vector3 (startPositionList [positionNum].x, startPositionList [positionNum].y, startPositionList [positionNum].z);

			currentSlim += 1;
			startPositionList.RemoveAt (positionNum);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		currentSlim =  currentSlim - EnemyController.reduceSlim;
		if (currentSlim < maxSlim) {

			int num = Random.Range (0, 10);
			Debug.Log (num);
			if (num <= 5) {
				int positionNum = Random.Range (0, positionList.Count);
				int slimNum = Random.Range (0, 1);
				GameObject slim = Instantiate (slimList [slimNum]) as GameObject;
				slim.transform.position = new Vector3 (positionList [positionNum].x, positionList [positionNum].y, positionList [positionNum].z);
			} else if (6 <= num && num <= 8) {
				int positionNum = Random.Range (0, positionList.Count);
				int slimNum = 2;
				GameObject slim = Instantiate (slimList [slimNum]) as GameObject;
				slim.transform.position = new Vector3 (positionList [positionNum].x, positionList [positionNum].y, positionList [positionNum].z);
			} else {
				int positionNum = Random.Range (0, positionList.Count);
				int slimNum = 3;
				GameObject slim = Instantiate (slimList [slimNum]) as GameObject;
				slim.transform.position = new Vector3 (positionList [positionNum].x, positionList [positionNum].y, positionList [positionNum].z);

			}
				
			EnemyController.reduceSlim = 0;
			currentSlim += 1;

			}
		if(GameController.Instance.score > slimCountMax ){
			maxSlim += 1;
			slimCountMax += 500;
		}


	}
}
