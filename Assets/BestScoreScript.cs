using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreScript : MonoBehaviour {
	Text BestScore;
	// Use this for initialization
	void Start () {
		BestScore = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetFloat ("BestScore", 0) > 0f)
			BestScore.text = "Best:" + PlayerPrefs.GetFloat ("BestScore", 0).ToString ("F2") + "m";
		else
			BestScore.text = " " ;
			
		
	}
}
