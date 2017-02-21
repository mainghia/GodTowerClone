using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Level4BarController : MonoBehaviour {

	private Image image;
	private Color imageOriginalColor;

	void Awake(){
		image = GetComponent<Image> ();
		imageOriginalColor = image.color;
	}

	public void OnMouseEnter(){
		image.color = Color.clear;
	}

	public void OnMouseExit(){
		image.color = imageOriginalColor;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
