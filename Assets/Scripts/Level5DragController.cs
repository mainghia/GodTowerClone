using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Level5DragController : MonoBehaviour {

	private float xLimit = 500 / 2;
	private float yLimit = 500 / 2;
	private Transform parentTransform;

	public void Awake(){
		parentTransform = transform.parent.transform;
	}

	public void OnDrag()
	{		
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 mousePositionLocal = parentTransform.InverseTransformPoint (mousePosition);
		gameObject.transform.localPosition = new Vector3(Mathf.Clamp(mousePositionLocal.x,-xLimit,xLimit),Mathf.Clamp(mousePositionLocal.y,-yLimit,yLimit),0f);
	}

}
