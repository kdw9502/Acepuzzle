using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomUI2DSpriteAnimation : UI2DSpriteAnimation {

	public void PlayBack (){
		base.framerate *= -1;
		enabled = true;
	}
}
