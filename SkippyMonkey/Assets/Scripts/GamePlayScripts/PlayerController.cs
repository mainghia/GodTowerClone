using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CustomPhysicCharacterController))]
public class PlayerController : MonoBehaviour {
	public float runspeed;
	public float jumpspeed;
	public LayerMask deadCollisionMask;
	private Collider2D coll;
	private Animator anim;
	private bool gameStarted = false;
	private CustomPhysicCharacterController characterController;
	private Vector2 currentVelocity;

	private void Awake(){
		characterController = GetComponent<CustomPhysicCharacterController>();
		coll = GetComponent<Collider2D> ();
		LeanTouch.OnFingerTap += OnFingerTap;
		anim = GetComponent<Animator> ();
	}

	private void Start(){
		currentVelocity = new Vector2 (runspeed*Time.fixedDeltaTime, 0);
	}

	private void OnFingerTap(LeanFinger finger){
		gameStarted = true;
		currentVelocity.y = jumpspeed * Time.fixedDeltaTime;
		anim.SetBool ("IsGrounded", false);

	}


	private void FixedUpdate(){
		currentVelocity += Physics2D.gravity * Time.fixedDeltaTime;
		characterController.Move (currentVelocity);
		if (characterController.collisionInfo.collideBottom) {
			currentVelocity.y = 0;
			anim.SetBool ("IsGrounded", true);
		} else {
			anim.SetBool ("IsGrounded", false);
		}

		if(characterController.collisionInfo.collideLeft || characterController.collisionInfo.collideRight || characterController.collisionInfo.collideTop){
			Die();
		}

		if (transform.position.x > 320) {
			transform.Translate (new Vector2 (-640, 0));
		}
	 else {
		if (transform.position.x < -320) {
			transform.position =  new Vector2 (transform.position.x + 640, 0);
		}
	}
}

	public void Die(){
		characterController.collisionMask = deadCollisionMask;
		currentVelocity.x = -runspeed * Time.fixedDeltaTime * 0.5f;
		currentVelocity.y = runspeed * Time.fixedDeltaTime * 0.5f;

		LeanTouch.OnFingerTap -= OnFingerTap;
		PlayScene.Instance.GameOver ();
		Debug.Log ("Die");
	}

}
