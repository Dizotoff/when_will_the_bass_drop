//controll the direction of legs animation
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legDir : MonoBehaviour {
	Vector3 rot;
	// Use this for initialization
	void Start () {
		rot = new Vector3 (0, 0, 0);
		
	}

	// We rotate legs in the direction of moving depend on keys which pressed
	void Update () {
		if(Input.GetKey(KeyCode.W)){
			rot = new Vector3 (0, 0, 90);
			transform.eulerAngles = rot;
	}
		if(Input.GetKey(KeyCode.S)){
			rot = new Vector3 (0, 0, 270);
			transform.eulerAngles = rot;
		}
		if(Input.GetKey(KeyCode.A)){
			rot = new Vector3 (0, 0, 180);
			transform.eulerAngles = rot;
		}
		if(Input.GetKey(KeyCode.D)){
			rot = new Vector3 (0, 0, 0);
			transform.eulerAngles = rot;
		}
}
}