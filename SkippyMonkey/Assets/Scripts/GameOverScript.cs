using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {
    
	public Text scoreDisplay;
	public Button ReplayButton;

	private void Awake(){
		ReplayButton.enabled = true;
		scoreDisplay.text = PlayerPrefs.GetInt ("Score").ToString();
	}

	public void OnReplayButtonTapped()
    {
		ReplayButton.enabled = false;
        TKSceneManager.ChangeScene("Gameplay Scene");
    }
}
