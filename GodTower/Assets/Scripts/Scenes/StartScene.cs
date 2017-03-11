using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour {

	public void OnBeginButtonClicked(){
		TKSceneManager.ChangeScene("level 1");
	}

	public void OnContinueButtonClicked(){
		// TODO: continue button function
	}
}
