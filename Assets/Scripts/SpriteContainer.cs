using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteContainer : MonoBehaviour {
	public Sprite[] pLegs, pUnarmedWalk;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Sprite[] getPlayerLegs()
	{
		return pLegs;
	}

	public Sprite[] getPlayerUnarmedWalk()
	{
		return pUnarmedWalk;
	}

}

