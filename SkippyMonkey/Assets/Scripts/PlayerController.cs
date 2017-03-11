using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour {
	public float runspeed;
	public float jumpspeed;
	public Collider2D colHead;


	private Rigidbody2D rgBody;
	private Collider2D coll;
	private Animator anim;
	private bool gameStarted = false;

	private void Awake(){
		rgBody = GetComponent<Rigidbody2D> ();
		coll = GetComponent<Collider2D> ();
		LeanTouch.OnFingerTap += OnFingerTap;
		anim = GetComponent<Animator> ();
	}

	private void OnFingerTap(LeanFinger finger){
		gameStarted = true;
		anim.SetBool ("IsGrounded", false);
		rgBody.velocity = new Vector2 (rgBody.velocity.x, jumpspeed);
	}

	private void OnCollisionEnter2D(Collision2D collision){
		anim.SetBool ("IsGrounded", true);
	}

	private void Update (){
		if (coll.enabled) {
			if (gameStarted && rgBody.velocity.x < (runspeed / 2)) {
				Die ();
				return;
			}

			rgBody.velocity = new Vector2 (runspeed, rgBody.velocity.y);
			if (transform.position.x > 320) {
				transform.Translate (new Vector2 (-640, 0));
			}
		} else {
			if (transform.position.x < -320) {
				transform.position =  new Vector2 (transform.position.x + 640, 0);
			}
		}
	}

	public void Die(){
		coll.enabled = false;
		colHead.enabled = false;
		rgBody.velocity = new Vector2 (-150, rgBody.velocity.y);
		rgBody.freezeRotation = false;
		rgBody.angularVelocity = 80;
		LeanTouch.OnFingerTap -= OnFingerTap;
		PlayScene.Instance.GameOver ();
		Debug.Log ("Die");
	}

}
