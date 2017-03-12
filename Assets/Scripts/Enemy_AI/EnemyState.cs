﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour {

	[HideInInspector]
	public IEnemyState currentState;

	[HideInInspector]
	public PatrolState patrolState;

	[HideInInspector]
	public AlertState alertState;

	[HideInInspector]
	public ChaseState chaseState;

	public float speed = 1.5f;
	public GameObject EnemyObject;
	public GameObject Target;
	public bool Clockwise;
	public RaycastHit2D hit;
	public int layerMask = 1 << 7;

	void Awake (){
		patrolState = new PatrolState(this);
		alertState = new AlertState(this);
		chaseState = new ChaseState(this);

	}


	void Start(){
		currentState = patrolState;
	}

	void Update() {
		currentState.UpdateState ();
	}

	private void onTriggerEnter(Collider other){
		currentState.OnTriggerEnter (other);
	}

}
