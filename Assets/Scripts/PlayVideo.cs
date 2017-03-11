
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayVideo : MonoBehaviour {

	// Use this for initialization
	public MovieTexture movie;
	void Start () {
		GetComponent<RawImage> ().texture = movie as MovieTexture;
		
		movie.Play ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
