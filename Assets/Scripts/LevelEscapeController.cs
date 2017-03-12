using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelEscapeController : MonoBehaviour {
	public GameObject col,van;
	public Sprite doorsOpen;
	SpriteRenderer sr;
	 GameObject[] enemies;
	// Use this for initialization
	void Start () {
		sr = this.GetComponent<SpriteRenderer> ();
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");


	}

	void Update () {
		if (areAllEnemiesDead () == true && sr.sprite != doorsOpen) {
			openCar ();

		}


	}


	public bool areAllEnemiesDead()
	{
		for (int x = 0; x < enemies.Length; x++) {
			if (enemies [x].tag != "Dead") {
				return false;
			}
		}
		return true;
	}

	void openCar()
	{
		Destroy (col);
		sr.sprite = doorsOpen;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
		 
			Debug.Log ("COOOOOLLLLIIIDDEEEERRR!!!!");

			MenuScreen menu = GameObject.FindGameObjectWithTag ("Menu").GetComponent<MenuScreen> ();

			menu.saveHighScore ();
			menu.display = true;
			SceneManager.LoadScene ("Menu");
		}



	}
}