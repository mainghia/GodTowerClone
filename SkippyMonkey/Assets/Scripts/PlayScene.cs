using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using UnityEngine.UI;

public class PlayScene : MonoBehaviour {

	public static PlayScene Instance{ get; private set;}
	public Text scoreDisplay;

	private int score = 0;
	private int highScore = 0;
	private string highScoreKey = "HighScore";

	private void Awake(){
		Instance = this;
		highScore = PlayerPrefs.GetInt ("HighScore",0);
	}

	public void Score(){
		score++;
		scoreDisplay.text = score.ToString ();
		if (score> highScore){			
			PlayerPrefs.SetInt(highScoreKey, score);
			PlayerPrefs.Save();
		}

	}

	public void AddScore(string playerName, int score){	
		int newScore, oldScore;
		string newName, oldName;

		newScore = score;
		newName = playerName;

		for(int i=0;i<10;i++){
			if(PlayerPrefs.HasKey(i+"HighScore")){
				if(PlayerPrefs.GetInt(i+"HighScore")<newScore){ 
					// Swap score when new Score is higher than stored score
					oldScore = PlayerPrefs.GetInt(i+"HighScore");
					oldName = PlayerPrefs.GetString(i+"HScoreName");
					PlayerPrefs.SetInt(i+"HighScore",newScore);
					PlayerPrefs.SetString(i+"HScoreName",newName);
					newScore = oldScore;
					newName = oldName;
				}
			}else{
				PlayerPrefs.SetInt(i+"HighScore",newScore);
				PlayerPrefs.SetString(i+"HScoreName",newName);
				newScore = 0;
				newName = "";
			}
		}
		PlayerPrefs.Save();
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
