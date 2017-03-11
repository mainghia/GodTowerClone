using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class ScorerController : MonoBehaviour {

	private Collider2D col;

	// Use this for initialization
	void Start () {
		col = GetComponent<Collider2D> ();
	}
	
	private void OnTriggerEnter2D(Collider2D other){

		PlayScene.Instance.Score ();
		PlatformFactory.Instance.PutNewPlatformInPlace();
		col.enabled = false;

	}

}
