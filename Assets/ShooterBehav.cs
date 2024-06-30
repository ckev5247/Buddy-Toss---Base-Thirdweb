using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBehav : MonoBehaviour {
	Rigidbody2D rb;
	Animator Myanim;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		Myanim = GetComponent<Animator> ();
	}

	IEnumerator ToIdle(){
		yield return new WaitForSecondsRealtime (0.5f);
		Myanim.SetBool ("Shooting", false);

	}
	// Update is called once per frame
	void Update () {
		if (Global.GameOver == false) {
			rb.velocity = new Vector2 (0f, -MoveShootedCharacter.speed);

			if (Input.GetMouseButtonDown (0)) {
				Myanim.SetBool ("Shooting", true);
				StartCoroutine ("ToIdle");
			}
		}
		else 
			rb.velocity = new Vector2 (0f,0f);
		//transform.position = new Vector3(transform.position.x, -Camera.main.orthographicSize + 3.16f,transform.position.z);
	}
}
