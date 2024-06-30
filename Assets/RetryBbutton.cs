using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class RetryBbutton : MonoBehaviour {

		// Use this for initialization

		void OnMouseDown(){
			SceneManager.LoadScene ("buddytoss");

		}
		void Start () {
			StartCoroutine ("grow");
		}
		IEnumerator grow(){

			transform.DOScale(0.4f,0.2f);
			yield return new WaitForSecondsRealtime (0.2f);
			transform.DOScale (0.5f,0.2f);
			yield return new WaitForSecondsRealtime (0.2f);
			StartCoroutine ("grow");

		}

		// Update is called once per frame
		void Update () {

		}
	}
