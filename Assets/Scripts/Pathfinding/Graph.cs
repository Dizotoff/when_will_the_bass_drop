using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph {

	public int rows = 0;
	public int cols = 0;

	public Node[] nodes;// created an array of the nodes we want to keep track of 

	public Graph(int[,] grid){
		rows = grid.GetLength (0);
		cols = grid.GetLength (1);

		nodes = new Node[grid.Length];

		// Loop through all the paces in the array and create an empty node
		for(var i = 0; i < nodes.Length; i++){
			var node = new Node (); // creates a node that goes inside the array
			node.label = i.ToString (); // converts the i value into a string
			nodes[i] = node; // relating the current nodes i-position to a space inside the array
		}

		// Iterate through each of the rows in the grid
		for(var r = 0; r < rows; r++){
			for (var c = 0; c < cols; c++) { // going through each of the columns
				var node = nodes[cols*r + c]; // getting a reference to a node inside of the Nodes array. Converting the rows and columns into the correct space inside of the array  
				
				// is the value of the grid a wall? 0 = open tile, 1 = solid tile.
				if(grid[r,c] == 1){
					continue;
				}


				// Connecting a node to its neighbours
				// UP
				if(r > 0){
					node.adjecent.Add(nodes[cols*(r-1)+c]);
				}

				// RIGHT
				if(c < cols-1){
					node.adjecent.Add(nodes[cols*r+c+1]);
				}

				// DOWN
				if(r < rows - 1) {
					node.adjecent.Add(nodes[cols*(r+1)+c]);
				}

				// LEFT
				if(c > 0){
					node.adjecent.Add(nodes[cols*r+c-1]);
				}
			}
		}


	}

}
