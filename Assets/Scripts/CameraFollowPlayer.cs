using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {
	GameObject player; // create object player
	public bool followPlayer = true;
	Vector3 mousePos;
	PlayerMovement pm;
	Camera cam;
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");// find gameobject with tag "player" there are few custom tags in unity 
		pm = player.GetComponent<PlayerMovement>();
		cam = Camera.main;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftShift)) //If shift pressed play stop movement and camera starts following the mouse 
		{
			followPlayer = false;
			pm.setMoving(false);
		} else
		{
			followPlayer = true;
		}

		if (followPlayer == true) {
			camFollowPlayer ();
		} else
		{
			lookAhead();
		}
	}
	public void setFollowPlayer (bool val)
	{
		followPlayer = val;
	}

	void camFollowPlayer()

	{
		Vector3 newPos = new Vector3 (player.transform.position.x, player.transform.position.y, this.transform.position.z); // take players x and y position and keep camera z position, then assigned it to the transform position
		this.transform.position = newPos;

	}

	void lookAhead()
	{
		Vector3 camPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y)); //get the mouse position to move the camera 
		camPos.z = -10; //Increase the screenview 
		Vector3 dir = camPos - this.transform.position; //Direction between player and mouse axis 
		if (player.GetComponent<SpriteRenderer>().isVisible == true) //If player sprite is visible move the camera until it become invisible to camera
		{
			transform.Translate(dir * 2 * Time.deltaTime); 
		}

	}


}