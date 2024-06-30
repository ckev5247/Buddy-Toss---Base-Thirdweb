using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInOutCamera : MonoBehaviour {
	public float zoomSpeed = 1;
	public float targetOrtho;
	public float smoothSpeed = 2.0f;


	void Start() {
		targetOrtho = Camera.main.orthographicSize;
	}

	void Update () {
		targetOrtho = Camera.main.orthographicSize *1.5f;

		//Camera.main.orthographicSize = Mathf.MoveTowards (Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
	}
}