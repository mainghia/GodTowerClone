using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using UnityEngine.UI;

public class PlayScene : MonoBehaviour {

	public static PlayScene Instance{ get; private set;}
	public Text scoreDisplay;

	private int score = 0;

	private void Awake(){
		Instance = this;
	}

	public void Score(){
		score++;
		scoreDisplay.text = score.ToString ();
	}

	public void GameOver(){
		StartCoroutine (AnimateGameOver());
		PlayerPrefs.SetInt ("Score", score);
		FindObjectOfType<CameraController> ().ScreenShake ();
	}

	public IEnumerator AnimateGameOver(){
		yield return new WaitForSeconds (1f);
		TKSceneManager.ChangeScene ("End Scene");
	}
}
