using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmScript : MonoBehaviour {
	UISprite sp;
	void Start(){
		sp =gameObject.GetComponent<UISprite> ();
		sp.spriteName= GameManager.instance.GetComponent<AudioSource> ().mute?"mute":"unmute";
	}
	void OnClick(){
		GameManager.instance.GetComponent<AudioSource> ().mute = !GameManager.instance.GetComponent<AudioSource> ().mute;
		PlayerPrefs.SetInt ("BGM",GameManager.instance.GetComponent<AudioSource> ().mute?1:0);

		if (sp.spriteName == "mute")
			sp.spriteName = "unmute";
		else
			sp.spriteName = "mute";
	}
}
