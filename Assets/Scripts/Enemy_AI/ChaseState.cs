using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IEnemyState {

	private readonly EnemyState enemy;

	public ChaseState(EnemyState enemyState){
		enemy = enemyState;
	}

	private void Chase() {
		Debug.Log ("PURSUIT");
		enemy.speed = 3.5f;

		// Add rotation later, for now just focus on pursuing the player!!
		enemy.transform.Translate(enemy.Target.transform.position * enemy.speed * Time.deltaTime);

		// if(PlayerDetectionRay().collider != player){
		//
		//}
	}

	public void OnTriggerEnter(Collider other){
		
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
	}

	private void Look(){
		// include enemy sight line code here
	}
}
