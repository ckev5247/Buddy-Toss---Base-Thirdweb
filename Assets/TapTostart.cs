using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TapTostart : MonoBehaviour {
	public static bool affichscore;
	SpriteRenderer sp;
	// Use this for initialization
	void Start () {
		StartCoroutine ("fade");
		affichscore = false;
		sp = GetComponent<SpriteRenderer> ();
	}
	void OnMouseDown(){
		StartCoroutine ("gamestart");
	}

	IEnumerator gamestart(){
		affichscore = true;
		foreach (GameObject tuto in GameObject.FindGameObjectsWithTag("Tuto")) {
			tuto.transform.DOLocalMoveX (-20f, 0.5f);
		}
		sp.DOKill();
		sp.DOFade (0f,0.3f);
	
		yield return new WaitForSecondsRealtime (1f);
		foreach (GameObject tuto in GameObject.FindGameObjectsWithTag("Tuto")) {
			Destroy (tuto);
		}
		Destroy (gameObject);

	}

	IEnumerator fade(){
		gameObject.GetComponent<SpriteRenderer> ().DOFade (0f,1f);
		yield return new WaitForSecondsRealtime (1f);
		gameObject.GetComponent<SpriteRenderer> ().DOFade (1f,1f);
		yield return new WaitForSecondsRealtime (1f);
		StartCoroutine ("fade");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
