using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour {
	public Sprite[] walking, attacking, legsSpr;
	int counter = 0, legCount =0;
	PlayerMovement pm;
	float timer = 0.05f, legTimer = 0.05f;
	public SpriteRenderer torso, legs;
	SpriteContainer sc;
	bool attackingB = false;
	// Use this for initialization
	void Start () {
		pm = this.GetComponent<PlayerMovement> ();
		sc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<SpriteContainer> ();
		walking = sc.getPlayerUnarmedWalk ();
		legsSpr = sc.getPlayerLegs ();
		attacking = sc.getPlayerPunch ();
		
	}
	
	// Update is called once per frame
	void Update () {
		animateLegs ();
		if (attackingB == false) {
			animateTorso ();
		} else {
			animateAttack ();
		}
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

	void animateAttack(){
		torso.sprite = attacking [counter];
			timer -= Time.deltaTime;
		
			if (timer <= 0) {
			if (counter < attacking.Length - 1) {
				counter++;
				} else {
				if (attackingB == true) {
					attackingB = false;
				}
					counter = 0;
				}
				timer = 0.05f;
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

	public void attack()
	{
		attackingB = true;
	}
	public void resetCounter()
	{
		counter = 0;
	}
	public bool getAttack(){
		return attackingB;
	}

	public void setNewTorso(Sprite[] walk, Sprite[] attack)
	{
		counter = 0;
		attacking = attack;
		walking = walk;
	}



}
