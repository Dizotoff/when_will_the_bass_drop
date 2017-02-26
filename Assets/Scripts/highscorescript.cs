using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class highscorescript :MonoBehaviour  {
	
	public GameObject Score;
	public GameObject ScoreName;
	public GameObject Rank;

	public  void SetScore(string name,string score,string rank)
	{
		this.Rank.GetComponent<Text>().text = rank;
		this.ScoreName.GetComponent<Text>().text = name;
		this.Score.GetComponent<Text>().text = score;
	}
}
