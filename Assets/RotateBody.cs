using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateBody : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("rotate");
	}
	IEnumerator rotate(){
		transform.DORotate (new Vector3(0f,0f,10f),0.4f);
		yield return new WaitForSecondsRealtime (0.5f);
		transform.DORotate (new Vector3(0f,0f,-10f),0.4f);
		yield return new WaitForSecondsRealtime (0.5f);
		StartCoroutine ("rotate");
	}
	// Update is called once per frame
	void Update () {
		
	}
}
