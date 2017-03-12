using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AlertState : IEnemyState{
	public readonly EnemyState enemy;

	public AlertState(EnemyState enemyState){
		enemy = enemyState;
	}

	public void OnTriggerEnter(Collider other){

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

	public void UpdateState(){
		// Search ();
		// Look ();
		// write these codes later
	}

}
