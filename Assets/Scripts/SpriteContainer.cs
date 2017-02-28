using UnityEngine;
using System.Collections;

public class SpriteContainer : MonoBehaviour {
	public Sprite[] pLegs,pUnarmedWalk,pPunch,pMac10Walk,pMac10Attack,pBowieWalk,pBowieAttack;

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

	public Sprite[] getPlayerPunch()
	{
		return pPunch;
	}

	public Sprite[] getWeapon(string weapon)
	{
		switch (weapon) {
		case "Mac10":
			return pMac10Attack;
			//break;
		case "Bowie":
			return pBowieAttack;
			//break;
		default:
			return getPlayerPunch ();
			//break;
		}
	}

	public Sprite[] getWeaponWalk(string weapon)
	{
		switch (weapon) {
		case "Mac10":
			return pMac10Walk;
			//break;
		case "Bowie":
			return pBowieWalk;
			//break;
		default:
			return getPlayerUnarmedWalk ();
			//break;
		}
	}



}
