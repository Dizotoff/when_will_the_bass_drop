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
		EnemySightLine ();
		PlayerDetectionRay ();
	}

	void Patrol () {
		enemy.transform.Translate(Vector3.right * enemy.Speed * Time.deltaTime);
		// Debug.Log ("PATROLLING"); // WORKS!

		if (EnemySightLine().collider.gameObject.tag == "Wall"){
			Debug.Log ("FACING A WALL, TURNING"); // doesn't work!! doesn't detect walls 
			if (enemy.Clockwise == false){
				enemy.transform.Rotate(0, 0, 90);
			} else {
				enemy.transform.Rotate(0, 0, -90);
			}
		}
			

		if(PlayerDetectionRay().collider.gameObject.tag == "Player") {
			ToChaseState();
		}
			
	}


	private RaycastHit2D PlayerDetectionRay (){ // the line from enemy to player.
		float dist = Vector3.Distance (enemy.Target.transform.position, enemy.transform.position); // distance between player and enemy
		Vector3 dir = enemy.Target.transform.position - enemy.transform.position; // direction towards player
		enemy.Hit = Physics2D.Raycast (new Vector2 (enemy.transform.position.x, enemy.transform.position.y),
			new Vector2 (dir.x, dir.y), dist, enemy.LayerMask); // created a raycast from enemy to player
		Debug.DrawRay(enemy.transform.position, dir, Color.red); // you'll see the red ray in the scene view when running the game
		return enemy.Hit;
	}

	private RaycastHit2D EnemySightLine() { // enemy sight, fairly short
		Vector3 sightDir = enemy.transform.TransformDirection(Vector3.right); // direction where the enemy is looking (forward)
		RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(enemy.transform.position.x, enemy.transform.position.y),
			new Vector2(sightDir.x, sightDir.y), 1.0f, enemy.LayerMask); // creates a raycast to represent the enemy sight
		Debug.DrawRay (new Vector2(enemy.transform.position.x, enemy.transform.position.y), new Vector2(sightDir.x, sightDir.y), Color.cyan); // blue ray in the scene view
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
		
}
