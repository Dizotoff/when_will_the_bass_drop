using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public bool moving = false; //control the animation 
	float speed = 5.0f; // how fast the player will move
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		movement ();
	}

	void movement(){  
		if (Input.GetKey (KeyCode.W)) { //detect if the key down or up 
			transform.Translate (Vector3.up * speed * Time.deltaTime,Space.World);
			moving = true;//time.deltatime for increasing the perfomance on the old computer 
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (Vector3.down * speed * Time.deltaTime,Space.World);
			moving = true;
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (Vector3.left * speed * Time.deltaTime,Space.World);
			moving = true;
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector3.right * speed * Time.deltaTime,Space.World);
			moving = true;
		}

		if (Input.GetKey (KeyCode.D) != true && Input.GetKey (KeyCode.W) != true && Input.GetKey (KeyCode.S) != true && Input.GetKey (KeyCode.A) != true) 
		{
			moving = false;
		}

	}
}
