using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Search {
	public Graph graph;
	public List<Node> reachable; // reachable nodes
	public List<Node> explored; // explored nodes
	public List<Node> path;

	public Node goalNode;
	public int iterations; // number of iterations the search performs
	public bool finished; // has our search has completed?

	public Search(Graph graph) {
		this.graph = graph;
	}

	public void Start(Node start, Node goal) {
		reachable = new List<Node>(); 
		reachable.Add (start); // starting node is always reachable

		goalNode = goal;

		explored = new List<Node> ();
		path = new List<Node> ();
		iterations = 0;

		for (var i = 0; i < graph.nodes.Length; i++) {
			graph.nodes [i].Clear (); // resets all the values of the search
		}

	}



	public void Step() {
		if (path.Count > 0) { // to stop this method if we have already found a path
			return;
		}

		if (reachable.Count == 0) { // in this case we haven't found a solution, so the search is done
			finished = true;
			return;
		}

		iterations++;

		var node = ChoseNode (); // returns a random node from the reachable nodes
		if (node == goalNode) { // checks if the node is actually equal the goal node
			while(node != null){ // fills the path to how we got here. 
				path.Insert (0, node);
				node = node.previous;
			}

			finished = true;
			return;
		}

		reachable.Remove (node); // this happens if we haven't  reached the end of the search
		explored.Add (node); // adding the node to the explored list

		// iterate through all of the adjecent nodes attached to the current node
		for(var i = 0; i < node.adjecent.Count; i++) {
			AddAdjecent (node, node.adjecent [i]); // add the current node and it's own adjacent nodes
		}
	}





	public void AddAdjecent (Node node, Node adjecent){
		if(FindNode(adjecent, explored) || FindNode(adjecent, reachable)){
			return;
		}
		
		// if the if-statement doesn't return true, it means we found a new path
		adjecent.previous = node;
		reachable.Add (adjecent);
		
	}





	public bool FindNode (Node Node, List<Node> list) {
		return GetNodeIndex(Node, list) >= 0; // returns true if the node exists inside the list, false if it doesn't
	}





	public int GetNodeIndex(Node node, List<Node> list){
		for (var i = 0; i < list.Count; i++) { // does the node exist inside of the list?
			if(node == list[i]){
				return i;
			}
		}

		return -1;
	}




	public Node ChoseNode(){ // returning a random node from the reachable nodes
		return reachable [Random.Range (0, reachable.Count)];
	}
}
