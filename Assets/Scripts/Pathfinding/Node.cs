using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node {

	public List <Node> adjecent = new List<Node>(); // other nodes adjacent to the node we're in
	public Node previous = null; // the previous node we looked at 
	public string label = ""; // each node will get their unique name

	public void Clear (){ // clearing our ode so we can reset the previous field
		previous = null;
	}

}
