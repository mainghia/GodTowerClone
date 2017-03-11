using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFactory : MonoBehaviour {
	public static PlatformFactory Instance{ get; private set;}

	public float initialPlatformY;
	public float initialPoolSize;
	public float platformXSpacing;
	public float platformYSpacing;
	public float gapSize;

	public GameObject platformPrefab;

	private List<GameObject> platforms = new List<GameObject>();

	private int currentPlatformIndex = 0;
	private float lastPlatformX = 0;

	// Use this for initialization
	void Awake () {
		Instance = this;
		for (int i = 0; i < initialPoolSize; i++) {
			PutNewPlatformInPlace ();
		}
	}

	public void PutNewPlatformInPlace(){
		GameObject platform = GetNewPlatform ();
		float newX = Random.Range (lastPlatformX+ platformXSpacing, lastPlatformX + 320 - gapSize);
		if (newX > 320 - gapSize/2) {
			newX -= 320 - gapSize;
		}
		platform.transform.position = new Vector2 (newX,initialPlatformY + currentPlatformIndex*platformYSpacing);
		platform.SetActive (true);
		currentPlatformIndex++;
		lastPlatformX =  newX;
	}

	private GameObject GetNewPlatform(){
		foreach (GameObject platform in platforms){
			if (!platform.activeInHierarchy)
				return platform;
		}

		GameObject newPlatform = Instantiate (platformPrefab) as GameObject;
		platforms.Add (newPlatform);
		return newPlatform;
	}

}
