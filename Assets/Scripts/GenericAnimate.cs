using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericAnimate : MonoBehaviour {
	public Sprite[] sprites; 
	public bool loop, destroyOnFinish, whileNear, needsActivating;
	bool activated = false;
	SpriteRenderer sr;
	float timer = 0.05f;
	public float distance = 5.0f, timerReset = 0.05f;
	int counter = 0;
	GameObject player; 
	// Use this for initialization
	void Start () {
		sr = this.GetComponent<SpriteRenderer> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		
	}
	
	// Update is called once per frame
	void Update () {
		if (whileNear == true) {
			animateWhileNear ();
		} else if (needsActivating == true && activated == false) {
			if (Input.GetKey (KeyCode.Mouse0) && Vector3.Distance (player.transform.position, this.transform.position) < 2.0f) {
				activated = true;
			}
		} else if (needsActivating == true && activated == true) {
			normalAnimate ();
			if (Input.GetKey (KeyCode.Mouse0) && Vector3.Distance (player.transform.position, this.transform.position) < 2.0f) {
				activated = false;
			}
		} else {
			normalAnimate ();
		}
	}

	void animateWhileNear()
	{
		sr.sprite = sprites [counter];
		if (Vector3.Distance (player.transform.position, this.transform.position) < distance){
			timerReset -= Time.deltaTime;
			if (timerReset <= 0) {
				if (counter < sprites.Length - 1) {
					counter++;
				} else {
					if (loop == true) {
						counter = 0;
					} else if (destroyOnFinish == true) {
						Destroy (this.gameObject);
					}
				}
				timer = timerReset; 
			}
	}
}
	void normalAnimate()
	{
		sr.sprite = sprites [counter];
			timerReset -= Time.deltaTime;
			if (timer <= 0) {
				if (counter < sprites.Length - 1) {
					counter++;
				} else {
					if (loop == true) {
						counter = 0;
					} else if (destroyOnFinish == true) {
						Destroy (this.gameObject);
					}
				}
				timer = timerReset; 
			}
		}
		
	}