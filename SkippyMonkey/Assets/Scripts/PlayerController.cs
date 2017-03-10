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

	private Rigidbody2D rgBody;
	private Collider2D coll;
	private Animator anim;

	private void Awake(){
		rgBody = GetComponent<Rigidbody2D> ();
		coll = GetComponent<Collider2D> ();
		LeanTouch.OnFingerTap += OnFingerTap;
		anim = GetComponent<Animator> ();
	}

	private void OnDestroy(){
		LeanTouch.OnFingerTap -= OnFingerTap;
	}

	private void OnFingerTap(LeanFinger finger){
		anim.SetBool ("IsGrounded", false);
		rgBody.velocity = new Vector2 (rgBody.velocity.x, jumpspeed);
	}

	private void OnCollisionEnter2D(Collision2D collision){
		anim.SetBool ("IsGrounded", true);
	}

	private void Update (){
		rgBody.velocity = new Vector2 (runspeed, rgBody.velocity.y);
		if (transform.position.x > 320) {
			transform.Translate (new Vector2 (-640, 0));
		}
	}

}
