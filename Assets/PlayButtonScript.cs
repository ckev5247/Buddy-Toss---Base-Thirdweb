using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PlayButtonScript : MonoBehaviour {

	// Use this for initialization

	void OnMouseDown(){
		StartCoroutine ("fadeandchange");

	}

	void Start () {
		StartCoroutine ("grow");
	}
	IEnumerator fadeandchange(){
		foreach(GameObject fade in GameObject.FindGameObjectsWithTag("Fade")){
			fade.gameObject.GetComponent<SpriteRenderer> ().DOKill ();
			fade.gameObject.GetComponent<SpriteRenderer> ().DOFade (1f, 0.6f);
		}
		yield return new WaitForSecondsRealtime (0.6f);
		SceneManager.LoadScene ("buddytoss");
	}
	IEnumerator grow(){

		transform.DOScale(0.8f,0.2f);
		yield return new WaitForSecondsRealtime (0.2f);
		transform.DOScale (1f,0.2f);
		yield return new WaitForSecondsRealtime (0.2f);
		StartCoroutine ("grow");

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
