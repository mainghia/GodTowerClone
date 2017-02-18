using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1 : MonoBehaviour {

	public InputField pwInp;
	public Text hintText;

	public void OnSubmitButtonClicked(){
		if (pwInp.text.Equals ("kabul")) {
			TKSceneManager.ChangeScene ("level 2");
		}
		else
			hintText.text = "Access Denied";
			hintText.color = Color.red;
	}
}
