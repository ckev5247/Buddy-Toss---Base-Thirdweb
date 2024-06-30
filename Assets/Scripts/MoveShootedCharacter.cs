using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using DG.Tweening;
using System.Numerics;
using Thirdweb;
using Vector3 = UnityEngine.Vector3;

public class MoveShootedCharacter : MonoBehaviour {
	float distanceDeTir =5f;
	Rigidbody2D rb;
	public static float speed;
	float fallingSpeed;
	float shootingSpeed;
	float FlyingTime;
	private Animator Myanim;
	private bool done ;
	[SerializeField] GameObject Dash;
	[SerializeField] GameObject Retry;
	[SerializeField] GameObject MainMenu;
	public static float currentHighDistance=0f;
	public Color night;
	public Color day;

	public Text savingOnChain;

	public string Address { get; private set; }

	// Use this for initialization
	void Start () {
		currentHighDistance = 0f;
	    shootingSpeed = 3f;
		speed = 0f;
		rb = GetComponent<Rigidbody2D> ();
		Myanim = GetComponent<Animator> ();
		FlyingTime = 1f;
		//gameObject.GetComponent<Renderer> ().enabled = false;
		savingOnChain.text = "";
	}

	IEnumerator GameOver(){
		Debug.Log("GameOver");
		SubmitScore(currentHighDistance);
		if (PlayerPrefs.GetFloat ("BestScore", 0f) < currentHighDistance) {
			PlayerPrefs.SetFloat ("BestScore", currentHighDistance);
			//Call function to save best score on chain
		}
		if (Global.PlaySessionCounterBeforeShowingAds >= 2) {
			if (AdmobInitialisation.interstitial.IsLoaded ()) {

				AdmobInitialisation.interstitial.Show ();
				AdmobInitialisation.interstitial.Destroy ();
			}
			Global.PlaySessionCounterBeforeShowingAds = 0;

			#if UNITY_ANDROID	
			string adUnitId = "ca-app-pub-00000000000000000000";
			#elif  UNITY_IPHONE
			string adUnitId = "ca-app-pub-00000000000000000000000";
			#else
			string adUnitId = "unexpected_platform";
			#endif

			AdmobInitialisation.interstitial = new InterstitialAd (adUnitId);
			AdRequest request = new AdRequest.Builder ().Build ();
			AdmobInitialisation.interstitial.LoadAd (request);
		} else
			Global.PlaySessionCounterBeforeShowingAds += 1;


		Camera.main.orthographicSize = 5f;
		Global.GameOver = true;
		yield return new WaitForSecondsRealtime (0f);
		//Instantiate (MainMenu,new Vector3(-0.82f,-2.36f,0f),transform.rotation);
		//Instantiate (Retry,new Vector3(1.29f,-2.36f,0f),transform.rotation);
		//Instantiate (Dash,new Vector3(-16f,0f,0f),transform.rotation);
	}

	public BigInteger FloatToBigInteger(float value)
	{
		// Convert the float to decimal to preserve precision
		decimal decimalValue = (decimal)value;

		// Convert the decimal to BigInteger
		BigInteger bigIntegerValue = new BigInteger(decimalValue);

		return bigIntegerValue;
	}

	public async void SubmitScore(float value)
	{
		savingOnChain.text = "Submit Score On Chain";
		Address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();
		BigInteger newScore = FloatToBigInteger(value);
		var contract = ThirdwebManager.Instance.SDK.GetContract(
			"0xA957a6Dd4af3d2f6501cf0044b51d73c761325Af",
			"[{\"type\":\"constructor\",\"name\":\"\",\"inputs\":[],\"outputs\":[],\"stateMutability\":\"nonpayable\"},{\"type\":\"event\",\"name\":\"NewHighScore\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"indexed\":true,\"internalType\":\"address\"},{\"type\":\"uint256\",\"name\":\"score\",\"indexed\":false,\"internalType\":\"uint256\"}],\"outputs\":[],\"anonymous\":false},{\"type\":\"event\",\"name\":\"PlayerScoreUpdated\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"indexed\":true,\"internalType\":\"address\"},{\"type\":\"uint256\",\"name\":\"score\",\"indexed\":false,\"internalType\":\"uint256\"}],\"outputs\":[],\"anonymous\":false},{\"type\":\"function\",\"name\":\"getHighScore\",\"inputs\":[],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getPlayerHighScore\",\"inputs\":[{\"type\":\"address\",\"name\":\"playerAddress\",\"internalType\":\"address\"}],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer1Address\",\"inputs\":[],\"outputs\":[{\"type\":\"address\",\"name\":\"\",\"internalType\":\"address\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer1Score\",\"inputs\":[],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer2Address\",\"inputs\":[],\"outputs\":[{\"type\":\"address\",\"name\":\"\",\"internalType\":\"address\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer2Score\",\"inputs\":[],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer3Address\",\"inputs\":[],\"outputs\":[{\"type\":\"address\",\"name\":\"\",\"internalType\":\"address\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer3Score\",\"inputs\":[],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer4Address\",\"inputs\":[],\"outputs\":[{\"type\":\"address\",\"name\":\"\",\"internalType\":\"address\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer4Score\",\"inputs\":[],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer5Address\",\"inputs\":[],\"outputs\":[{\"type\":\"address\",\"name\":\"\",\"internalType\":\"address\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer5Score\",\"inputs\":[],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayers\",\"inputs\":[],\"outputs\":[{\"type\":\"tuple[5]\",\"name\":\"\",\"components\":[{\"type\":\"address\",\"name\":\"playerAddress\",\"internalType\":\"address\"},{\"type\":\"uint256\",\"name\":\"score\",\"internalType\":\"uint256\"}],\"internalType\":\"struct HighScore.Player[5]\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"highestScore\",\"inputs\":[],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"owner\",\"inputs\":[],\"outputs\":[{\"type\":\"address\",\"name\":\"\",\"internalType\":\"address\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"playerHighScores\",\"inputs\":[{\"type\":\"address\",\"name\":\"\",\"internalType\":\"address\"}],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"setPlayerScore\",\"inputs\":[{\"type\":\"address\",\"name\":\"playerAddress\",\"internalType\":\"address\"},{\"type\":\"uint256\",\"name\":\"newScore\",\"internalType\":\"uint256\"}],\"outputs\":[],\"stateMutability\":\"nonpayable\"},{\"type\":\"function\",\"name\":\"topPlayers\",\"inputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"outputs\":[{\"type\":\"address\",\"name\":\"playerAddress\",\"internalType\":\"address\"},{\"type\":\"uint256\",\"name\":\"score\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"}]"
			 );
		Debug.Log("SubmitingScore");
		await contract.Write("setPlayerScore", Address, newScore);
		Debug.Log("SubmitedScore");
		Instantiate(MainMenu, new Vector3(-0.82f, -2.36f, 0f), transform.rotation);
		Instantiate(Retry, new Vector3(1.29f, -2.36f, 0f), transform.rotation);
		Instantiate(Dash, new Vector3(-16f, 0f, 0f), transform.rotation);
		savingOnChain.text = "";
	}

	IEnumerator fallDown(){
		Myanim.SetBool ("Falling", false);
		yield return new WaitForSecondsRealtime (FlyingTime);
		foreach (GameObject FI in GameObject.FindGameObjectsWithTag("FlyingImage")) {
			FI.GetComponent<Image> ().enabled = false;

		}
		foreach (GameObject FI in GameObject.FindGameObjectsWithTag("FallingImage")) {
			if (transform.position.y>22f)
			FI.GetComponent<Image> ().enabled = true;
		}
		Myanim.SetBool ("Falling", true);
		speed = fallingSpeed;
	}

	void Update () {
		if (Global.GameOver == false) {
			//velocty
			rb.velocity = new UnityEngine.Vector2(0f, speed);
			//camera zoom
			if (speed > 0 && transform.position.y > Camera.main.orthographicSize - 7f) {
				//Camera.main.orthographicSize = Camera.main.orthographicSize + (transform.position.y - (Camera.main.orthographicSize-5f));

				Camera.main.orthographicSize = Mathf.SmoothStep (Camera.main.orthographicSize, Camera.main.orthographicSize + (transform.position.y - (Camera.main.orthographicSize - 7f)), Time.deltaTime * 300f);
			} else if (speed < 0 && transform.position.y < Camera.main.orthographicSize - 7f) {
				
				//Camera.main.orthographicSize = Camera.main.orthographicSize + (transform.position.y - (Camera.main.orthographicSize-5f));
				Camera.main.orthographicSize = Mathf.SmoothStep (Camera.main.orthographicSize, Camera.main.orthographicSize + (transform.position.y - (Camera.main.orthographicSize - 7f)), Time.deltaTime * 300f);
			}
			//transform.position = new Vector3 (Camera.main.orthographicSize * Screen.width / Screen.height, Camera.main.orthographicSize, transform.position.z);

			//Control 
			if (Input.GetMouseButtonDown (0)) {
			
				foreach (GameObject Shooter in GameObject.FindGameObjectsWithTag("Shooter")) {
					if (transform.position.y < Shooter.transform.position.y + distanceDeTir && transform.position.y > Shooter.transform.position.y - distanceDeTir*1.2f) {
						if (transform.position.y < Shooter.transform.position.y) {
							if (distanceDeTir < 20f) {
								distanceDeTir = distanceDeTir * 1.2f;
							}
							shootingSpeed = shootingSpeed * 1.5f;
							speed = shootingSpeed;
							fallingSpeed = shootingSpeed * -1.5f;
							FlyingTime = FlyingTime * 1.2f;
							StartCoroutine ("fallDown");
						} else if (transform.position.y > Shooter.transform.position.y) {
							if (distanceDeTir < 20f) {
								distanceDeTir = distanceDeTir * 1.15f;
							}
							shootingSpeed = shootingSpeed * 1.2f;
							speed = shootingSpeed;
							fallingSpeed = shootingSpeed * -1.1f;
							FlyingTime = FlyingTime * 1.1f;
							StartCoroutine ("fallDown");
						}

					} else if (transform.position.y < Shooter.transform.position.y - 6f) {
						//SceneManager.LoadScene ("buddytoss");
						if (done == false) {
							done = true;
							StartCoroutine ("GameOver");
						}
					}
					
			

				}
			}
			foreach (GameObject Shooter in GameObject.FindGameObjectsWithTag("Shooter")) {
				if (transform.position.y < Shooter.transform.position.y - 6f)
				if (done == false) {
					done = true;
					StartCoroutine ("GameOver");
				}
			}
			if (transform.position.y < 0)
				Global.Score = 0f;
			else
				Global.Score = transform.position.y * 35;

			if (transform.position.y >= 23f && speed > 0) {
				foreach (GameObject FI in GameObject.FindGameObjectsWithTag("FlyingImage")) {
					FI.GetComponent<Image> ().enabled = true;
					gameObject.GetComponent<SpriteRenderer> ().enabled = false;
				}
			}
			if (transform.position.y <= 23f && speed < 0) {
				foreach (GameObject FI in GameObject.FindGameObjectsWithTag("FallingImage")) {
					FI.GetComponent<Image> ().enabled = false;
					gameObject.GetComponent<SpriteRenderer> ().enabled = true;
				}
			}
		}
		else 
			rb.velocity = new UnityEngine.Vector2(0f,0f);

		if (Global.Score > currentHighDistance) {
			currentHighDistance = Global.Score;
		}

		if (transform.position.y > 100f) {
			Camera.main.DOColor (night, 2f);
		}
		else
			Camera.main.DOColor (day, 2f);
	}
}