using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour {
	public string name2; //name of sprite in conteiner
	public float fireRate; //fire rate)
	WeaponAttack wa; //script of playe attacking
	public bool gun, oneHanded;
	// Use this for initialization
	void Start () {
		wa = GameObject.FindGameObjectWithTag ("Player").GetComponent<WeaponAttack> ();


	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay2D(Collider2D coll) {
		
		if (coll.gameObject.tag == "Player" && Input.GetMouseButtonDown (1)) { //right mouse button to pickup the weapon
			//code to add weapon to player

			Debug.Log ("Player picked up:" + name2); //if player already has a weapon it will drop the current weapon
			if (wa.getCur () != null) {
				wa.dropWeapon ();

			}
			wa.setWeapon (this.gameObject, name2, fireRate, gun, oneHanded); //passing the name of sprite, firerate, attacking script (gun,meelee, shotgun)
			// DESTROY THIS GAMEOBJECT
			this.gameObject.SetActive(false);

		}
	}
}