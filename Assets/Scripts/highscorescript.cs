using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class highscorescript :MonoBehaviour  {
	
	public GameObject Score;
	public GameObject ScoreName;
	public GameObject Rank;

	public  void SetScore(string name,string score,string rank) // all the things are string because we are going to insert everything on text.
	{
		this.Rank.GetComponent<Text>().text = rank;
		this.ScoreName.GetComponent<Text>().text = name;
		this.Score.GetComponent<Text>().text = score;
	}
}
