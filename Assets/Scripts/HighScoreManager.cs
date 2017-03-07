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
	public GameObject ScorePrefab; 
	public Transform scoreParent; // set parent for inserting scores 
	public int SaveScores; // number of scores you want to save.
	public int TopRank; // Number of rank you want to show.
	public InputField enterName;
	public GameObject nameDialog;// box where player insert there name aftter completing game.

	void Start () {
		connectionString = "URI= file:" + Application.dataPath + "/highscore.sqlite"; // connects unity with sqlite which was made from sqlite manager
		CreateTable ();
		ShowScore ();
		GetScore ();

	}
		
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			nameDialog.SetActive(!nameDialog.activeSelf); // esc button to apen the namedialog button and insert your name .
		}
	}
	public void EnterName() // Methods for entering name 
	{
		if (enterName.text != string.Empty) 
		{
			int score = UnityEngine.Random.Range (1, 500);
			InsertScore (enterName.text, score);
			enterName.text = string.Empty;

			ShowScore ();
		}
		
	}

	private void InsertScore(string name, int newScore)  // methods to insert score 
	{

		using (IDbConnection dbconnection = new SqliteConnection (connectionString)) 
		{
			dbconnection.Open ();

			using (IDbCommand dbCmd = dbconnection.CreateCommand ())
			{
				string sqlQuery = string.Format("INSERT INTO highscore(Name,Score) VALUES(\"{0}\",\"{1}\") ",name,newScore);

				dbCmd.CommandText = sqlQuery;
				dbCmd.ExecuteScalar ();
				dbconnection.Close ();
			}
		}
	}
	private void GetScore() // methods to get score 
	{
		highscore.Clear ();

		using (IDbConnection dbconnection = new SqliteConnection (connectionString)) {
			dbconnection.Open ();

			using (IDbCommand dbCmd = dbconnection.CreateCommand ()) {
				string sqlQuery = "SELECT * FROM highscore \nORDER BY Score\n LIMIT  1 ; "; // query to get score .

				dbCmd.CommandText = sqlQuery;

				using (IDataReader reader = dbCmd.ExecuteReader ()) {
					while (reader.Read ()) {
						highscore.Add (new highscores (reader.GetInt32 (0), reader.GetString (1), reader.GetInt32 (2))); // making scores readable 
					}
					dbconnection.Close ();
					reader.Close ();
				}
			}
		}
	}

	private void CreateTable() // Table for highscore
	{
		using (IDbConnection dbconnection = new SqliteConnection (connectionString)) 
		{
			dbconnection.Open ();

			using (IDbCommand dbCmd = dbconnection.CreateCommand ())
			{
				string sqlQuery = string.Format("CREATE TABLE highscore (PlayerID INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL  UNIQUE , Name TEXT NOT NULL , Score INTEGER NOT NULL ) ");

				dbCmd.CommandText = sqlQuery;
				dbCmd.ExecuteScalar ();
				dbconnection.Close ();
     }
	}
	}

	private void ShowScore() // methods to show score 
	{
		GetScore ();

		foreach (GameObject score in GameObject.FindGameObjectsWithTag ("Score")) {
			Destroy (score);
		}

		for (int i = 0; i < TopRank; i++) 
		{
			if (i <= highscore.Count-1) {
				GameObject tmpobjec = Instantiate (ScorePrefab);
				highscores tmpscore = highscore [i]; // list of highscores
				tmpobjec.GetComponent <highscorescript> ().SetScore (tmpscore.Name, tmpscore.Score.ToString (), "#" + (i + 1).ToString ());

				tmpobjec.transform.SetParent (scoreParent);
				tmpobjec.GetComponent <RectTransform> ().localScale = new Vector3 (1, 1, 1); // align them straight below.
			}
		}

	}
}
