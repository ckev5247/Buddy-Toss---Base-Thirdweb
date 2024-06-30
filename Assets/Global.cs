using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {
	public static float Score;
	public static bool GameOver=false;
	public static int PlaySessionCounterBeforeShowingAds=0;
	// Use this for initialization
	void Start () {
		GameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
