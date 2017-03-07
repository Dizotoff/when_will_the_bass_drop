using UnityEngine;
using System.Collections;

public class EnemyAttacked : MonoBehaviour {
	public Sprite knockedDown,stabbed,bulletWound,backUp;
	public GameObject bloodPool,bloodSpurt; 
	SpriteRenderer sr;
	bool EnemyKnockedDown=false;
	float knockDownTimer = 3.0f;
	GameObject player;
	ScoreController sc;


	void Start () {
		sr = this.GetComponent<SpriteRenderer> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		sc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<ScoreController> ();
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
			sc.AddScore (500,this.transform.position);
			EnemyKnockedDown = false;
			sr.sprite = backUp;
			this.GetComponent<EnemyAI> ().enabled = true;
			this.GetComponent<CircleCollider2D> ().enabled = true;

			knockDownTimer = 3.0f;
		}

	}

	public void killBullet()
	{
		sc.AddScore (500,this.transform.position);
		sr.sprite = bulletWound;
		Instantiate(bloodPool, this.transform.position, this.transform.rotation);
		//disable ai
		this.GetComponent<EnemyAI> ().enabled = false;
		this.GetComponent<CircleCollider2D>().enabled= false;
		this.gameObject.tag = "Dead";

	}

	public void killMelee()
	{
		sc.AddScore (1000,this.transform.position);
		sr.sprite = stabbed;
		Instantiate (bloodPool,this.transform.position,this.transform.rotation);
		Instantiate (bloodSpurt,this.transform.position,player.transform.rotation);
		sr.sortingOrder = 2;
		this.GetComponent<EnemyAI> ().enabled = false;
		this.GetComponent<CircleCollider2D>().enabled= false;
		this.gameObject.tag = "Dead";
	}


}
