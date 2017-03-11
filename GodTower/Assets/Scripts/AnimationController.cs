using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (MoveUp ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private IEnumerator MoveUp(){
		Vector3 originalPostion = new Vector3 (0, -250, 1);
		Vector3 targetPostion = new Vector3 (0, 250, 1);

		float time = 0;
		while (time < 2.5f) {
			transform.localPosition = Vector3.Lerp (originalPostion, targetPostion,Mathfx.SmoothStep(0,1,time / 2.5f));
			time += Time.deltaTime;
			yield return null;
		}

		transform.localPosition = targetPostion;
	}
}
