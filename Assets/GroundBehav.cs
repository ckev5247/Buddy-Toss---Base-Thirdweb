using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBehav : MonoBehaviour {
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Global.GameOver==false)
		
		rb.velocity = new Vector2 (0f,-MoveShootedCharacter.speed);
		else 
			rb.velocity = new Vector2 (0f,0f);
		//transform.position = new Vector3(transform.position.x, -Camera.main.orthographicSize ,transform.position.z);
	}

}
