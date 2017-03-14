using System.Collections;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.Collections.Generic;
using UnityEngine.UI;

public class highScoreManager : MonoBehaviour {

	private string connectionString;
	private List <highscores> highscore = new List<highscores> (); // list of highScores 
	public Transform scoreParent; // set parent for inserting scores 
    public GameObject nameDialog;// box where player insert there name aftter completing game.
	public InputField enterName; // input player name


	void Start () {
		connectionString = "URI= file:" + Application.dataPath + "/highh.sqlite"; // connects unity with sqlite which was made from sqlite manager

		CreateTable ();// create the table if it's not in the .sqlite file
        ShowScore (); // show the scores
	}
		
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space))
		{
			nameDialog.SetActive(!nameDialog.activeSelf); // Space button to apen the namedialog button and insert your name .
		}
			

	}
		
	public void EnterName() // Methods for entering name 
	{
		
			int score = UnityEngine.Random.Range (1, 500);
			InsertScore (enterName.text, score);  // calling method to insert the name and score
		    enterName.text = string.Empty;
			ShowScore ();
	     	
	}

	private void InsertScore(string name, int newScore)  // methods to insert score 
	{

		using (IDbConnection dbconnection = new SqliteConnection (connectionString)) 
		{
			dbconnection.Open ();

			using (IDbCommand dbCmd = dbconnection.CreateCommand ())
			{
				string sqlQuery = string.Format("INSERT INTO highscore(Name,Score) VALUES(\"{0}\",\"{1}\") ",name,newScore); // query to insert name and score

				dbCmd.CommandText = sqlQuery;
				dbCmd.ExecuteScalar ();
				dbconnection.Close ();
			}
		}
	}

	private void GetScore() // methods to get score 
	{
		Debug.Log ("Here we come? ");
		highscore.Clear ();

		using (IDbConnection dbconnection = new SqliteConnection (connectionString)) {
			dbconnection.Open ();

			using (IDbCommand dbCmd = dbconnection.CreateCommand ()) {
				string sqlQuery = "SELECT * FROM highscore ORDER BY Score DESC LIMIT  5; "; // query to get score so that it orders by score in descending and limit by5

				dbCmd.CommandText = sqlQuery;

				using (IDataReader reader = dbCmd.ExecuteReader ()) {
					while (reader.Read ()) {
						highscore.Add (new highscores (reader.GetInt32 (0), reader.GetString (1), reader.GetInt32 (2))); // making scores readable 
					}
					dbconnection.Close ();
					reader.Close ();
				}
			}
			Debug.Log ("So select query went find? " + highscore.Count);
		}
	}

	private void CreateTable() // Table for highscore if it not exists
	{
		Debug.Log ("Will create the table if not exists");
		using (IDbConnection dbconnection = new SqliteConnection (connectionString)) 
		{
			dbconnection.Open ();

			using (IDbCommand dbCmd = dbconnection.CreateCommand ())
			{
				string sqlQuery = string.Format("CREATE TABLE IF NOT EXISTS highscore (Rank INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL  UNIQUE , Name TEXT NOT NULL , Score INTEGER NOT NULL  UNIQUE )");

				dbCmd.CommandText = sqlQuery;
				dbCmd.ExecuteScalar ();
				dbconnection.Close ();
     }
	}
	}
	private void ShowScore () // methods to show score
	{
		GetScore ();
		Debug.Log ("Do we come here too? " + highscore.Count);

		Text tmp = GameObject.FindGameObjectWithTag ("Score").GetComponent<Text> () as Text; // finding text which has tag score
		Text forName = GameObject.FindGameObjectWithTag ("naming").GetComponent<Text> () as Text; // finding text which has tag naming

		tmp.text = "";
		forName.text = "";
		int i = 0;

		foreach (highscores h in highscore) {
			Debug.Log ("Do we come 5 times here???? " + h.Name + " " + h.Score + " ::: " + h.ID);// checking whether it works or not

			 tmp.text += "#" + (i++ + 1) + "\t        " + h.Score +  "\n";//inserting the things that we want to put in text.
			forName.text += h.Name +"\n"; //inserting name
			 

			}	
		}
	}


