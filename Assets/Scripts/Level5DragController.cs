using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Level5DragController : MonoBehaviour {


	public void OnDrag()
	{
		Transform parentTrans = transform.parent.transform;
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 mousePositionLocal = parentTrans.InverseTransformPoint (mousePosition);
		gameObject.transform.localPosition = new Vector3(Mathf.Clamp(mousePositionLocal.x,parentTrans.InverseTransformPoint(-4f,0f,0f).x,parentTrans.InverseTransformPoint(4f,0f,0f).x),
													Mathf.Clamp(mousePositionLocal.y,parentTrans.InverseTransformPoint(0f,-2.8f,0f).y,parentTrans.InverseTransformPoint(0f,3.2f,0f).y),
													0f);
	}

}
