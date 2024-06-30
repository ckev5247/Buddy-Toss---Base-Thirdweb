using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class AdmobInitialisation : MonoBehaviour {

	public static InterstitialAd interstitial;
	private BannerView bannerView;
	// Use this for initialization
	void Start () {

		//APP ID FOR IOS AND ANDROID INITIALISATION
		#if UNITY_ANDROID
		string appId ="ca-app-pub-00000000000000000000000";
		#elif  UNITY_IPHONE
		string appId= "ca-app-pub-00000000000000000000000";
		#else
		string appId = "unexpected_platform";
		#endif

		//intiliase admob
		MobileAds.Initialize(appId);


		#if UNITY_ANDROID	
		string adUnitId = "ca-app-pub-00000000000000000000";
		#elif  UNITY_IPHONE
		string adUnitId = "ca-app-pub-00000000000000000000000";
		#else
		string adUnitId = "unexpected_platform";
		#endif
		////////////////////////interstial
		interstitial = new InterstitialAd(adUnitId);
		AdRequest request = new AdRequest.Builder().Build();
		interstitial.LoadAd(request);

		#if UNITY_ANDROID
		string adUnitIdBanner = "ca-000000000000000000000";
		#elif UNITY_IPHONE
		string adUnitIdBanner = "ca-000000000000000000000000000";
		#else
		string adUnitIdBanner = "unexpected_platform";
		#endif
		//////////////////Bbanner
		bannerView = new BannerView(adUnitIdBanner, AdSize.Banner, AdPosition.Bottom);
		AdRequest requestBanner = new AdRequest.Builder().Build();
		bannerView.LoadAd(requestBanner);
		bannerView.Show ();

	}


	// Update is called once per frame
	void Update () {

	}
}

