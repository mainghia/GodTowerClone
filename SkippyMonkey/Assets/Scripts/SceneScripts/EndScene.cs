using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    
	public Text scoreDisplay;
	public InputField nameInputField;
	public Button ReplayButton, SaveButton, LeaderBoardButton;
	public GameObject GOparent, LeaderPanel;
	public List<Text> UInameList, UIscoreList;

	private List<string> nameList = new List<string> ();
	private List<int> scoreList = new List<int> ();

	private void Awake ()
	{
		ReplayButton.enabled = true;
		SaveButton.enabled = true;
		LeaderBoardButton.enabled = true;
		scoreDisplay.text = "Score: " + PlayerPrefs.GetInt ("Score").ToString ();
	}

	public void OnSaveButtonTapped ()
	{
		SaveButton.enabled = false;
		int score = PlayerPrefs.GetInt ("Score");
		string name = nameInputField.text;
		PlayScene.Instance.AddScore (name, score);
		nameInputField.text = "";
	}

	public void OnLeaderButtonTapped ()
	{
		LeaderPanel.SetActive (true);
		LeaderBoardButton.enabled = false;
		GOparent.SetActive (false);
		GetHighScore ();
		ShowHighScore ();
	}

	public void OnBackButtonTapped ()
	{
		LeaderPanel.SetActive (false);
		LeaderBoardButton.enabled = true;
		GOparent.SetActive (true);	
	}

	public void GetHighScore ()
	{
		if (nameList.Count<10) {			
			for (int i = 0; i < 10; i++) {
				if (PlayerPrefs.HasKey (i + "HighScore")) {
				
					scoreList.Add (PlayerPrefs.GetInt (i + "HighScore"));
					nameList.Add (PlayerPrefs.GetString (i + "HScoreName"));					
				} else {				
					scoreList.Add (0);
					nameList.Add ("");
				}
			}
		}
	}

	public void ShowHighScore ()
	{
		for (int i = 0; i < nameList.Count; i++) {
			UInameList [i].text = nameList [i];
			UIscoreList [i].text = scoreList [i].ToString ();
		}

	}

	public void OnReplayButtonTapped ()
	{
		ReplayButton.enabled = false;
		TKSceneManager.ChangeScene ("Gameplay Scene");
	}
}
