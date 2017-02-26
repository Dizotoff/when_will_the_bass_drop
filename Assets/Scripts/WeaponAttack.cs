using UnityEngine;
using System.Collections;

public class WeaponAttack : MonoBehaviour {
	 GameObject bullet,curWeapon;
	 bool gun = false;
	float timer = 0.1f,timerReset=0.1f;
	PlayerAnimate pa;
	SpriteContainer sc;

	float weaponChange = 0.5f;
	bool changingWeapon = false;
	bool oneHanded = false;

	void Start () {
		pa = this.GetComponent<PlayerAnimate> ();
		sc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<SpriteContainer> ();
	}


	void Update () {


		if (timer > 0) {
			timer -= Time.deltaTime;
		}

		if(Input.GetMouseButton(0) && timer <=0)
		{
			attack ();
		}
		if(Input.GetMouseButtonDown(0))
		{
			pa.resetCounter ();
		}
		if (Input.GetMouseButtonUp (0)) {
			pa.resetCounter ();
		}
			
				if (Input.GetMouseButtonDown (1) && changingWeapon == false) {
					dropWeapon ();
				}

		if(changingWeapon==true)
		{
			weaponChange -= Time.deltaTime;
			if(weaponChange<=0)
			{
				changingWeapon = false;
			}
		}
	}

	public void setWeapon(GameObject cur, string name, float fireRate,bool gun, bool oneHanded)
	{
		
		changingWeapon = true;
		curWeapon = cur;
		pa.setNewTorso (sc.getWeaponWalk(name),sc.getWeapon(name));
		this.gun = gun;
		timerReset = fireRate;
		timer = timerReset;
		this.oneHanded = oneHanded;
	}
		

	public void attack()
	{

			
		pa.attack ();
		RaycastHit2D ray = Physics2D.Raycast (new Vector2 (this.transform.position.x, this.transform.position.y), new Vector2 (transform.right.x, transform.right.y)); //create a line from the player wich can hit an enemy 
		Debug.DrawRay (new Vector2 (this.transform.position.x, this.transform.position.y), new Vector2 (transform.right.x, transform.right.y), Color.green);


		//THE PROBLEM IS HERE!!!!!!
		if (curWeapon == null && ray.collider.gameObject.tag == "Enemy") {
			EnemyAttacked ea = ray.collider.gameObject.GetComponent<EnemyAttacked> ();
			ea.knockDownEnemy ();
			Debug.Log ("KNOCKED DOWN!");
		} else if (ray.collider != null) {
			if (ray.collider.gameObject.tag == "Enemy") { //if player have meelee weapon -> instant kill 
				EnemyAttacked ea = ray.collider.gameObject.GetComponent<EnemyAttacked> ();
				ea.killMelee ();
				Debug.Log ("KILL!");
			}

		}
	}

	public GameObject getCur()
	{
		return curWeapon;
	}

	public void dropWeapon()
	{
		
		curWeapon.transform.position = this.transform.position;
			curWeapon.SetActive (true);
		setWeapon (null, "", 0.5f, false, false);
			
		}

	}

	