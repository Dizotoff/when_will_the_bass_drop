using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
	public float timer = 10.0f;
	private GameObject CutScene3;
	bool count=false;
	bool check=true;
	public GameObject player;
	Rigidbody2D RB;

	// Use this for initialization
	void Start () {
		CutScene3 = GameObject.Find ("LevelBlock");
		player = GameObject.FindGameObjectWithTag ("DjDesk");
		RB = player.GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		

		if (count == true) {
			timer -= Time.deltaTime;
		}
		if (check == true) {

			if (timer < 0) {
			
				CutScene3.SetActive(false);
				check = false;
			}
		}

		
	}



	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			this.GetComponent<AudioController> ().DropBass();
			other.enabled = false;
			count = true;
		}
	}






}
