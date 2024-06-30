using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Fadeout : MonoBehaviour {
	SpriteRenderer sp;
	// Use this for initialization
	void Start () {
		sp = GetComponent<SpriteRenderer> ();
		sp.DOKill ();
		sp.DOFade (0f, 1f);
	}
		
	// Update is called once per frame
	void Update () {
		
	}
}
