using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PatrolState : IEnemyState {
	private readonly EnemyState enemy;

	public PatrolState(EnemyState enemyState) {
		enemy = enemyState;
	}

	public void UpdateState (){
		Patrol();
	}

	void Patrol () {
		enemy.transform.Translate(Vector3.right * enemy.speed * Time.deltaTime);
		Debug.Log ("PATROLLING");

		if (EnemySightLine().collider && EnemySightLine().collider.CompareTag("Wall")){
			Debug.Log ("FACING A WALL");
			if (enemy.Clockwise == false){
				enemy.transform.Rotate(0, 0, 90);
			} else {
				enemy.transform.Rotate(0, 0, -90);
			}
		}
			

//		if(pursuit && PlayerDetectionRay().collider.gameObject.tag == "Player") {
//			Pursuit ();
//		}
			
	}


	RaycastHit2D PlayerDetectionRay (){
		float dist = Vector3.Distance (enemy.Target.transform.position, enemy.transform.position); // distance between player and enemy
		Vector3 dir = enemy.Target.transform.position - enemy.transform.position; // direction towards player
		enemy.hit = Physics2D.Raycast (new Vector2 (enemy.transform.position.x, enemy.transform.position.y),
			new Vector2 (dir.x, dir.y), dist, enemy.layerMask); // created a raycast from enemy to player
		Debug.DrawRay(enemy.transform.position, dir, Color.red); // you'll see the ray in the scene view when running the game
		return enemy.hit;
	}

	RaycastHit2D EnemySightLine() {
		Vector3 sightDir = enemy.transform.TransformDirection(Vector3.right); // direction where the enemy is looking (forward)
		RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(enemy.transform.position.x, enemy.transform.position.y), new Vector2(sightDir.x, sightDir.y), 1.0f, enemy.layerMask);
		Debug.DrawRay (new Vector2(enemy.transform.position.x, enemy.transform.position.y), new Vector2(sightDir.x, sightDir.y), Color.cyan);
		return hit2;
	}

	public void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			ToAlertState ();
		}
	}


	public void ToAlertState(){
		enemy.currentState = enemy.alertState;
	}

	public void ToChaseState(){
		enemy.currentState = enemy.chaseState;
	}


	public void ToPatrolState(){
		// wont't be used, but the method should be kept because of IEnemyState
	}


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
