using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < target.transform.position.y) {
			transform.position = new Vector3 (transform.position.x,target.position.y,transform.position.z);
		}
	}
}
