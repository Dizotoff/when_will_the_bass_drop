using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCursor : MonoBehaviour {

	Vector3 mousePos; //c
	Camera cam; //main camera class
	Rigidbody2D rid; //controller for physics for object
	// Use this for initialization
	void Start () {
		rid = this.GetComponent<Rigidbody2D> ();
		cam = Camera.main;
		
	}
	
	// Update is called once per frame
	void Update () {
		rotateToCamera ();
		
	}

	void rotateToCamera()
	{
		mousePos = cam.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - cam.transform.position.z)); //calculate the screen to world point
		rid.transform.eulerAngles = new Vector3 (0, 0, Mathf.Atan2 ((mousePos.y - transform.position.y), (mousePos.x - transform.position.x)) * Mathf.Rad2Deg); // rotates towards the player
	}
}
