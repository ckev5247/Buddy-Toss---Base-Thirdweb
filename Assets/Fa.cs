using System.Collections.Generic;
using UnityEngine;
//using Facebook.Unity;
using UnityEngine.UI;
public class Fa : MonoBehaviour {


	private void Awake ()
	{
//		if (!FB.IsInitialized) {
//			FB.Init (() => {
//				if (FB.IsInitialized)
//					FB.ActivateApp ();
//				else
//					Debug.LogError ("Couldn't initialize");
//			},
//				isGameShown => {
//					if (!isGameShown)
//						Time.timeScale = 0;
//					else
//						Time.timeScale = 1;
//				});
//		} else
//			FB.ActivateApp ();
//
//
//
//
//
//		//firebase 
//
//
//		Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
//			var dependencyStatus = task.Result;
//			if (dependencyStatus == Firebase.DependencyStatus.Available) {
//				// Create and hold a reference to your FirebaseApp, i.e.
//				//   app = Firebase.FirebaseApp.DefaultInstance;
//				// where app is a Firebase.FirebaseApp property of your application class.
//
//				// Set a flag here indicating that Firebase is ready to use by your
//				// application.
//			} else {
//				UnityEngine.Debug.LogError(System.String.Format(
//					"Could not resolve all Firebase dependencies: {0}", dependencyStatus));
//				// Firebase Unity SDK is not safe to use here.
//			}
//		});
//
//		Firebase.Analytics.FirebaseAnalytics
//			.LogEvent(Firebase.Analytics.FirebaseAnalytics.EventLogin);
	}
}