using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PathFinding : MonoBehaviour {
	public GameObject Enemy;
	public GameObject Player;
	public Sprite SpriteWall; // Dragged the wall sprite here in Unity
	public Sprite SpriteFloor; 
	public GameObject TileLayer;
	static int rows = 10;
	static int cols = 10;
	int[,] map = new int [rows, cols];

	void TileState (GameObject tile, int[,] array) {
		int x = (int)tile.transform.position.x; // the position of the object gives us the indices of the corresponding node in the map array
		int y = (int)Mathf.Abs(tile.transform.position.y);

		if (tile.GetComponent<SpriteRenderer> ().sprite == SpriteWall) { // now asking if the sprite used in this object is 
			array [y, x] = 1; // solid tile/node
		} else {
			array [y, x] = 0; // open tile/node
		}
	}
		

	void Start ()
	{
		foreach (Transform child in TileLayer.transform) { // iterates through every child inside our tile map layer ( a parent object, works as a container)
			TileState (child.gameObject, map); // now creates the array of nodes
		}

		/* for (int i = 0; i < rows; i++) {
			for (int k = 0; k < cols; k++) {
				Debug.Log (map [i, k]);
			} 

		}*/

	}


	void Update() {
		var graph = new Graph (map);
		var search = new Search (graph);
		int EX = (int)Enemy.transform.position.x; // Enemy's X-position, shows 1 unit less than the actual tile position but it has been taken into account in search.Start()
		int EY = (int)Mathf.Abs (Enemy.transform.position.y); 
		int PX = (int)Player.transform.position.x; // Player's X-position, shows 1 unit less than the actual tile position but it has been taken into account in search.Start()
		int PY = (int)Mathf.Abs (Player.transform.position.y); 

		search.Start (graph.nodes [(EX - 1) * cols + EY], graph.nodes [(PX - 1) * cols + PY]);


		while (!search.finished) {
			search.Step ();
		}


		for (int i = 0; i < search.path.Count; i++) {
			// Debug.Log ();
		}
		Debug.Log ("Search done. Path length " + search.path.Count + ", iterations " + search.iterations);	
		
		}

}

