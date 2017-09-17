using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceanManeger : MonoBehaviour {

	public Text highScoreLabel;



	// Use this for initialization
	void Start () {
		//ハイスコアを表示
		highScoreLabel.text = "High Score：" + PlayerPrefs.GetInt("HighScore") + "pt";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Application.LoadLevel ("MainGame");
		}
	}
}
