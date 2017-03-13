using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadController : MonoBehaviour {

	public PlayerController playerController;

	public void OnCollisionEnter2D(){
		playerController.Die ();
	}
}
