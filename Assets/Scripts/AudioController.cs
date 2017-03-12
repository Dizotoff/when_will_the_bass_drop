﻿using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {
	AudioSource aus;
	public AudioClip pickup,smgShot,melee;
	// Use this for initialization
	void Start () {
		aus = this.GetComponent<AudioSource> ();
		aus.volume = 0.5f;
	}
	// Update is called once per frame
	void Update () {

	}

	public void fireSmg()
	{
		aus.clip = smgShot;
		aus.Play ();
	}



	public void pickupWeapon()
	{
		aus.clip = pickup;
		aus.Play();
	}

	public void meleeAttack()
	{
		aus.clip = melee;
		aus.Play ();
	}
}
