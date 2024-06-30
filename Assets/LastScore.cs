using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LastScore : MonoBehaviour {
	Text BestScore;
	// Use this for initialization
	void Start () {
		BestScore = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		if (Global.GameOver == true) {


			BestScore.text = MoveShootedCharacter.currentHighDistance.ToString ("F2") + "m";
		}
			else
				BestScore.text = " ";

		

	}
}