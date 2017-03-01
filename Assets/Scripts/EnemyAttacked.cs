using UnityEngine;
using System.Collections;

public class EnemyAttacked : MonoBehaviour {
	public Sprite knockedDown,stabbed,bulletWound,backUp;
	public GameObject bloodPool,bloodSpurt; 
	SpriteRenderer sr;
	bool EnemyKnockedDown=false;
	float knockDownTimer = 3.0f;
	GameObject player;


	void Start () {
		sr = this.GetComponent<SpriteRenderer> ();
		player = GameObject.FindGameObjectWithTag ("Player");

	}


	void Update () {
		if(EnemyKnockedDown==true){
			knockDown ();
		}
	}

	public void knockDownEnemy()
	{
		EnemyKnockedDown = true;
		Debug.Log ("KNOCKED DOWN!!!!");
	}

	void knockDown()
	{


		knockDownTimer -= Time.deltaTime;
		sr.sprite = knockedDown;
		this.GetComponent<CircleCollider2D> ().enabled = false;
		this.GetComponent<EnemyAI> ().enabled = false;


		if (knockDownTimer <= 0) {
			EnemyKnockedDown = false;
			sr.sprite = backUp;
			this.GetComponent<EnemyAI> ().enabled = true;
			this.GetComponent<CircleCollider2D> ().enabled = true;

			knockDownTimer = 3.0f;
		}

	}

	public void killBullet()
	{

		sr.sprite = bulletWound;
		Instantiate(bloodPool, this.transform.position, this.transform.rotation);
		//disable ai
		this.GetComponent<EnemyAI> ().enabled = false;
		this.GetComponent<CircleCollider2D>().enabled= false;
		this.gameObject.tag = "Dead";

	}

	public void killMelee()
	{

		sr.sprite = stabbed;
		Instantiate (bloodPool,this.transform.position,this.transform.rotation);
		Instantiate (bloodSpurt,this.transform.position,player.transform.rotation);
		sr.sortingOrder = 2;
		this.GetComponent<EnemyAI> ().enabled = false;
		this.GetComponent<CircleCollider2D>().enabled= false;
		this.gameObject.tag = "Dead";
	}


}
