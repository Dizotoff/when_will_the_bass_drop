using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IEnemyState {

	private readonly EnemyState enemy;

	public ChaseState(EnemyState enemyState){
		enemy = enemyState;
	}

	private void Chase() {
		Debug.Log ("CHASE");
		Vector3 dir = enemy.Target.transform.position - enemy.transform.position;
		enemy.transform.Translate (dir * enemy.ChaseSpeed * Time.deltaTime);

		// enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, enemy.Target.transform.position, enemy.ChaseSpeed * Time.deltaTime);

		 if (!PlayerDetectionRay ().collider.gameObject.CompareTag("Player")) { // if the guard doesn't see the player anymore, it  goes back to patrolling
			ToPatrolState ();
		 }

	}

	public void OnTriggerEnter(Collider other){
		// not needed, keep here nevertheless.
	}

	public void ToAlertState() {
		enemy.currentState = enemy.alertState;
	}

	public void ToChaseState() {
		// won't be used, needs to be kept
	}

	public void ToPatrolState(){
		enemy.currentState = enemy.patrolState;
	}

	public void UpdateState(){
		Chase ();
		EnemySightLine ();
		PlayerDetectionRay ();
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


}
