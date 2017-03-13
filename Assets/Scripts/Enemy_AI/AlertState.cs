using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AlertState : IEnemyState{
	public readonly EnemyState enemy;
	private float searchTimer;

	public AlertState(EnemyState enemyState){
		enemy = enemyState;
	}

	public void OnTriggerEnter(Collider other){
		// nothing here, keep the method.
	}

	public void ToAlertState() {
		// won't be used, needs to be kept
	}

	public void ToChaseState() {
		enemy.currentState = enemy.chaseState;
	}

	public void ToPatrolState(){
		enemy.currentState = enemy.patrolState;
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

	private void Search(){
		enemy.transform.Rotate (Vector3.up * searchTimer *Time.deltaTime); // turns the enemy slowly
		searchTimer += Time.deltaTime; // counts the time

		if (searchTimer >= enemy.SearchDuration) { // if doesn't see anything, goes back to patrolling
			ToPatrolState ();
		}


	}

	public void UpdateState(){
		EnemySightLine ();
		PlayerDetectionRay ();
		Search ();
	}

}
