using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour {
	Text Score;
	// Use this for initialization
	void Start () {
		Score = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Global.GameOver==false && TapTostart.affichscore==true)
		Score.text = Global.Score.ToString ("F2")+ "m";
		else
			Score.text = "";
	}
}
