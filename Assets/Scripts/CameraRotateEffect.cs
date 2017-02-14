using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateEffect : MonoBehaviour {
	PlayerMovement pm;

	float mod = 0.1f;
	float zVal = 0.0f;
	// Use this for initialization
	void Start () {
		pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
	}

	// Update is called once per frame
	void Update () {
		if (pm.moving==true) //if player moving it create rotation vector
		{
			Vector3 rot = new Vector3(0, 0, zVal); //rotate only x and y direction
			this.transform.eulerAngles = rot;


			zVal += mod;


			if (transform.eulerAngles.z >= 5.0f && transform.eulerAngles.z < 10.0f)  //rotating betweeb
			{
				mod = -0.1f;
			}
			else if (transform.eulerAngles.z < 355.0f && transform.eulerAngles.z > 350.0f)
			{ mod = 0.1f; }
		}

	}
}