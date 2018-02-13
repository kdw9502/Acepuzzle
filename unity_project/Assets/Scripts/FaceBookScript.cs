using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
public class FaceBookScript : MonoBehaviour {
	public UIPanel loginPanel;
	// Use this for initialization
	void Awake () {
		if (!FB.IsInitialized) {
			// Initialize the Facebook SDK
			FB.Init(InitCallback, OnHideUnity);
		} else {
			// Already initialized, signal an app activation App Event
			FB.ActivateApp();
		}
	}
	private void InitCallback ()
	{
		if (FB.IsInitialized) {
			// Signal an app activation App Event
			FB.ActivateApp();
			// Continue with Facebook SDK
			// ...
		} else {
			Debug.Log("Failed to Initialize the Facebook SDK");
		}
	}
	private void OnHideUnity (bool isGameShown)
	{
		if (!isGameShown) {
			// Pause the game - we will need to hide
			Time.timeScale = 0;
		} else {
			// Resume the game - we're getting focus again
			Time.timeScale = 1;
		}
	}
	List<string> perms = new List<string>(){"public_profile", "email", "user_friends"};

	public void LogonFB(){
		if (FB.IsLoggedIn) {

		} else {
			FB.LogInWithReadPermissions(perms, AuthCallback);

		}
		if (FB.IsLoggedIn) {


			FB.FeedShare(
				string.Empty,
				new System.Uri("http://www.aceproject.co.kr"),
				"AceProject",
				"http://www.aceproject.co.kr/dpdltm/wp-content/uploads/header_logo2.png"
			);
		}


	}

	private void AuthCallback (ILoginResult result) {
		if (FB.IsLoggedIn) {
			// AccessToken class will have session details
			var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
			// Print current access token's User ID
			Debug.Log(aToken.UserId);
			// Print current access token's granted permissions
			foreach (string perm in aToken.Permissions) {
				Debug.Log(perm);
			}
		} else {
			Debug.Log("User cancelled login");
		}
	}
	public void OffLoginPanel(){
		loginPanel.gameObject.SetActive(false);
	}
}
