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


	void Start () {
		pa = this.GetComponent<PlayerAnimate> ();
		sc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<SpriteContainer> ();
	}


	void Update () {


		if(Input.GetMouseButton(0))
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

	public void setWeapon(GameObject cur, string name, float fireRate,bool gun)
	{
		
		changingWeapon = true;
		curWeapon = cur;
		pa.setNewTorso (sc.getWeaponWalk(name),sc.getWeapon(name));
		this.gun = gun;
		timerReset = fireRate;
		timer = timerReset;
	}
		

	public void attack()
	{

			pa.attack ();

	}

	public GameObject getCur()
	{
		return curWeapon;
	}

	public void dropWeapon()
	{
		
		curWeapon.transform.position = this.transform.position;
			curWeapon.SetActive (true);
		setWeapon (null, "", 0.5f, false);
			
		}

	}

	