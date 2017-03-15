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
		
			openCar ();




	}


	public bool areAllEnemiesDead()
	{
		
		return true;
	}

	void openCar()
	{
		Destroy (col);
		sr.sprite = doorsOpen;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
		 


			MenuScreen menu = GameObject.FindGameObjectWithTag ("Menu").GetComponent<MenuScreen> ();

			menu.saveHighScore ();
			menu.display = true;
			SceneManager.LoadScene ("Menu");
		}



	}
}