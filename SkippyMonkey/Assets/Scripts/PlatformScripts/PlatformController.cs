using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {
	public Collider2D scorerCollider;
	private Camera mainCam;
	// Use this for initialization
	void Awake () {
		mainCam = Camera.main;
	}

	void OnEnable(){
		scorerCollider.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < mainCam.transform.position.y - mainCam.orthographicSize - 300) {
			gameObject.SetActive (false);
		}
	}
}
