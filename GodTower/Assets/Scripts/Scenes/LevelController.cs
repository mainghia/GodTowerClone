using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {
	private static string LEVEL_TEXT = "LEVEL";
	private static string ACCESSDENIED_TEXT = "ACCESS DENIED";
	private static float NAME_CHANGE_INTERVAL = 1f;

	public Text levelNameTextField;
	public Text hintText;
	public InputField pwInp;
	public string correctAnswer;
	public string levelName;
	public string levelHintText;
	public string nextLevelSceneFileName;
	public List<GameObject> levelHintList;
	public Button nextHintButton;



	private float nextLevelNameChangeTimestamp = NAME_CHANGE_INTERVAL;
	private Coroutine hintTextCoroutine;
	private int currentHintIndex = 0;

	public void Start() {
		hintText.text = levelHintText;
		if (levelHintList.Count > 1) {
			nextHintButton.gameObject.SetActive (true);
			DisplayCurrentHint ();
		}
	}

	public void Update() {		 
		if(Time.timeSinceLevelLoad > nextLevelNameChangeTimestamp){
			nextLevelNameChangeTimestamp += NAME_CHANGE_INTERVAL;
			levelNameTextField.text = (levelNameTextField.text == LEVEL_TEXT) ? levelName : LEVEL_TEXT;
		}
	}

	public void OnSubmitButtonClicked() {
		if (pwInp.text.Equals (correctAnswer)) {
			TKSceneManager.ChangeScene (nextLevelSceneFileName);
		} else {
			pwInp.text = "";
			hintText.text = ACCESSDENIED_TEXT;
			hintText.color = Color.red;
			if (hintTextCoroutine != null) {
				StopCoroutine (hintTextCoroutine);
			}
			hintTextCoroutine = StartCoroutine (ChangeHintTextBack());
		}
	}

	public void OnNextHintButtonClicked(){
		currentHintIndex++;
		currentHintIndex %= levelHintList.Count;
		if (currentHintIndex == levelHintList.Count - 1) {
			nextHintButton.transform.localScale = new Vector3 (-1, 1, 1);
		} else {
			nextHintButton.transform.localScale = Vector3.one;
		}
		DisplayCurrentHint();
	}

	public void DisplayCurrentHint(){
		for (int i = 0; i < levelHintList.Count; i++) {
			levelHintList [i].SetActive (i == currentHintIndex);
		}
	}


	private IEnumerator ChangeHintTextBack() {
		//yield return null;
		yield return new WaitForSeconds(2f);
		hintText.text = levelHintText;
		hintText.color = Color.black;
	}


}
