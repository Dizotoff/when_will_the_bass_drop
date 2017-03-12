using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState {
	private readonly EnemyState enemy;

	public PatrolState(EnemyState enemyState) {
		enemy = enemyState;
	}

	public void UpdateState (){
		PatrolState ();
	}

	void Patrol () {
		this.transform.Translate(Vector3.right * speed * Time.deltaTime);
		Debug.Log ("PATROLLING");

		if (EnemySightLine().collider && EnemySightLine().collider.CompareTag("Wall")){
			Debug.Log ("FACING A WALL");
			if (clockwise == false){
				transform.Rotate(0, 0, 90);
			} else {
				transform.Rotate(0, 0, -90);
			}
		}
			

//		if(pursuit && PlayerDetectionRay().collider.gameObject.tag == "Player") {
//			Pursuit ();
//		}
			
	}


	RaycastHit2D PlayerDetectionRay (){
		float dist = Vector3.Distance (player.transform.position, this.transform.position); // distance between player and enemy
		Vector3 dir = player.transform.position - transform.position; // direction towards player
		hit = Physics2D.Raycast (new Vector2 (this.transform.position.x, this.transform.position.y),
			new Vector2 (dir.x, dir.y), dist, layerMask); // created a raycast from enemy to player
		Debug.DrawRay(this.transform.position, dir, Color.red); // you'll see the ray in the scene view when running the game
		return hit;
	}

	public void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			ToAlertState ();
		}
	}


	public void ToAlertSate(){
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
