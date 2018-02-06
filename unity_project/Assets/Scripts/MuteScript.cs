using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteScript : MonoBehaviour {
		UISprite sp;
		void Start(){
			sp =gameObject.GetComponent<UISprite> ();
			sp.spriteName=SFXManager.instance.source.mute?"mute":"unmute";
		}
		void OnClick(){
		
			SFXManager.instance.source.mute = !SFXManager.instance.source.mute;
			SFXManager.instance.PlayMenu ();
			PlayerPrefs.SetInt ("SFX",SFXManager.instance.source.mute?1:0);
			if (sp.spriteName == "mute")
				sp.spriteName = "unmute";
			else
				sp.spriteName = "mute";
		}
}


