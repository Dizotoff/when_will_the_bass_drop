using System.Collections;
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

	// These are values used in other classes.
	// Since EnemyState is the only class inheriting monobehaviour, it's the only class that can access objects in Unity.
	// That's why I have put these values ere, and they are called in other classes through enemy (Type EnemyState).
	// This way you don't have to open the scripts if you want to change or try different values.

	public float Speed = 1.5f;
	public float ChaseSpeed = 5.5f;
	public GameObject Target;
	public bool Clockwise;
	public RaycastHit2D Hit;

	[HideInInspector]
	public int LayerMask = 1 << 7;

	public bool Stationary;
	public float SearchDuration;
	public float RotationSpeed = 6.5f;

	void Awake (){
		patrolState = new PatrolState(this);
		alertState = new AlertState(this);
		chaseState = new ChaseState(this);

	}
		
	void Start(){
		currentState = patrolState; // guards start by patrolling.
		Target = GameObject.Find("Player");
		LayerMask = ~LayerMask;
	}

	void Update() {
		currentState.UpdateState ();
	}

	private void onTriggerEnter(Collider other){
		currentState.OnTriggerEnter (other);
	}

}
