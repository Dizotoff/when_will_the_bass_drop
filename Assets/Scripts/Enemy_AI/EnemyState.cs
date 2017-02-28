using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour {

	public IEnemyState currentState;
	public PatrolState patrolState;
	public AlertState alertState;
	public ChaseState chaseState;

	void Awake()
	{
		/*patrolState = new PatrolState(this);
		alertState = new AlertState(this);
		chaseState = new ChaseState(this);*/
	}


	// Use this for initialization
	void Start () {
		currentState = patrolState;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
