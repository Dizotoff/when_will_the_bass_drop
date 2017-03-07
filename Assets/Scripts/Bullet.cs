using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public Vector3 direction;
	string creator;
	EnemyAttacked attacked;
	public GameObject bloodImpact,wallImpact;
	float timer = 10.0f;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.Translate (direction*17*Time.deltaTime); //

		timer -= Time.deltaTime;
		if(timer<=0)
		{
			//Destroy (this.gameObject); //destroy after 10 seconds if doesnt hit anything 
		}

	}


	public void setVals(Vector3 dir, string name)
	{
		direction = dir;
		creator = name;
	}


	void OnCollisionEnter2D(Collision2D col) //if it hits gameobject it will get enemyattacked script  ant then killed them by the bullet
	{
		if (col.gameObject.tag == "Enemy") {
			attacked = col.gameObject.GetComponent<EnemyAttacked> ();
			attacked.killBullet ();
			Instantiate (bloodImpact, this.transform.position, this.transform.rotation); //create blood sprite and destroy the bullet
			Destroy (this.gameObject);


		} else if (col.gameObject.tag == "Player") {
			Instantiate (bloodImpact, this.transform.position, this.transform.rotation);
			PlayerHealth.dead = true;//new for 10
			Destroy (this.gameObject);
		}

		else {
			Instantiate (wallImpact, this.transform.position, this.transform.rotation); //if it hit not the enemy  it will just create wall impact 
			Destroy (this.gameObject);
		}
	}
}