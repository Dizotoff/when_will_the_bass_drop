using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState {

	// by inheriting this interface, all of the enemy states classes will have (to have) these methods,
	// thus they will work with enemystate without enemystate knowing anything about the state classes.
	// these methods are for changing the states within EnemyState through currentState (type IEnemyState).

	void UpdateState();

	void OnTriggerEnter(Collider other);

	void ToPatrolState();

	void ToAlertState();

	void ToChaseState();
}
