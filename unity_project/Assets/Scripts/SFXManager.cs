using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {
	public static SFXManager instance;
	public AudioSource source;
	public AudioClip readyClip;
	public AudioClip goClip;
	public AudioClip coinClip;
	public AudioClip clearClip;
	public AudioClip menuClip;
	public AudioClip chanceClip;
	// Use this for initialization
	void Awake(){
		if (SFXManager.instance == null)
			SFXManager.instance = this;
	}
	public void MuteToggle(){
		SFXManager.instance.source.mute = !source.mute;
	}
	public void PlayReady(){
		SFXManager.instance.source.PlayOneShot (readyClip);
	}
	public void PlayGo(){	
		SFXManager.instance.source.PlayOneShot (goClip);	

	}
	public void PlayCoin(){
		SFXManager.instance.source.PlayOneShot (coinClip);	
	}
	public void PlayClear(){
		SFXManager.instance.source.PlayOneShot (clearClip);
	}
	public void PlayMenu(){
		SFXManager.instance.source.PlayOneShot (menuClip);
	}
	public void PlayChance(){
		SFXManager.instance.source.PlayOneShot (chanceClip);
	}

}
