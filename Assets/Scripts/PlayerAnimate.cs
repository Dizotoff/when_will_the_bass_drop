using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour {
	Sprite[] walking, attacking, legsSpr;
	int counter = 0, legCount =0;
	PlayerMovement pm;
	float timer = 0.05f, legTimer = 0.05f;
	public SpriteRenderer torso, legs;
	SpriteContainer sc;
	// Use this for initialization
	void Start () {
		pm = this.GetComponent<PlayerMovement> ();
		sc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<SpriteContainer> ();
		walking = sc.getPlayerUnarmedWalk ();
		legsSpr = sc.getPlayerLegs ();
		
	}
	
	// Update is called once per frame
	void Update () {
		animateLegs ();
		animateTorso ();
	}

	void animateTorso()
	{
		if (pm.moving == true) { //check if player is moving
			torso.sprite = walking [counter];
			timer -= Time.deltaTime;
			if (timer <= 0) {
				if (counter < walking.Length - 1) {
					counter++;
				} else {
					counter = 0;
				}
				timer = 0.1f;
			}
		}
	}

	void animateLegs()
	{
		if (pm.moving == true) {
			legs.sprite = legsSpr [legCount];
			legTimer -= Time.deltaTime;
			if (legTimer <= 0) {
				if (legCount < legsSpr.Length - 1) {
					legCount++;
				} else {
					legCount = 0;
				}
				legTimer = 0.1f;
			}
		}
	}






}
