
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayVideo : MonoBehaviour {
	public bool playing = false;
	// Use this for initialization
	public MovieTexture movie;
	void Start () {
		GetComponent<RawImage> ().texture = movie as MovieTexture;
		movie.loop= true;
		movie.Play ();

		
	}
	
	// Update is called once per frame
	void Update () {
		
		playing = true;

	}
}
