using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveDash : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.DOLocalMoveX (0f,0.2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
