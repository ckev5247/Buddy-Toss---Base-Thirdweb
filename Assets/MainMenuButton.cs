using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnMouseDown(){
		SceneManager.LoadScene ("MainMenu");

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
