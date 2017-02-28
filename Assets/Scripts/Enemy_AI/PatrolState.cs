using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState {

	public EnemyState enemy;
	public Transform[] Waypoints = new Transform[4]; // create an array for waypoints
	public int NextWaypoint;
	public int CurrentWaypoint = 0;


    // Use this for initialization
    void Start () {

		// find each waypoint object when the scene is loaded

		Waypoints [0] = GameObject.Find ("Waypoint1").transform;
		Waypoints [1] = GameObject.Find ("Waypoint2").transform;
		Waypoints [2] = GameObject.Find ("Waypoint3").transform;
		Waypoints [3] = GameObject.Find ("Waypoint4").transform;
	
	}

	
	// Update is called once per frame
	void Update () {



	}





	public void OnTriggerEnter(Collider other)
	{
	}

	public void ToAlertState()
	{
	}

	public void ToChaseState()
	{

	}

	public void ToPatrolState()
	{

	}

	public void UpdateState()
	{

	}
}
