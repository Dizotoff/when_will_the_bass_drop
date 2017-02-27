using System.Collections;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.Collections.Generic;
using UnityEngine.UI;

public class highScoreManager : MonoBehaviour {

	private string connectionString;
	private List <highscores> highscore = new List<highscores> ();
	public GameObject ScorePrefab;
	public Transform scoreParent;
	public int SaveScores;
	public int TopRank;
	public InputField enterName;
	public GameObject nameDialog;

	void Start () {
		connectionString = "URI= file:" + Application.dataPath + "/highscore.sqlite";
		CreateTable ();
		DeleteExtraScores ();
		ShowScore ();

	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			nameDialog.SetActive(!nameDialog.activeSelf);
		}
	}
	public void EnterName()
	{
		if (enterName.text != string.Empty) 
		{
			int score = UnityEngine.Random.Range (1, 500);
			InsertScore (enterName.text, score);
			enterName.text = string.Empty;

			ShowScore ();
		}
		
	}

	private void InsertScore(string name, int newScore)
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
	private void GetScore()
	{
		highscore.Clear ();

		using (IDbConnection dbconnection = new SqliteConnection (connectionString)) 
		{
			dbconnection.Open ();

			using (IDbCommand dbCmd = dbconnection.CreateCommand ())
			{
				string sqlQuery = "SELECT * FROM highscore ";

				dbCmd.CommandText = sqlQuery;

				using (IDataReader reader = dbCmd.ExecuteReader ()) 
				{
					while (reader.Read ())
					{
						highscore.Add(new highscores(reader.GetInt32(0),reader.GetString(1),reader.GetInt32(2)));
					}
					dbconnection.Close ();
					reader.Close ();
				}
			}
		}
		highscore.Sort ();
	}

	private void CreateTable()
	{
		using (IDbConnection dbconnection = new SqliteConnection (connectionString)) 
		{
			dbconnection.Open ();

			using (IDbCommand dbCmd = dbconnection.CreateCommand ())
			{
				string sqlQuery = string.Format("CREATE TABLE highscore if not exists (PlayerID INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL  UNIQUE , Name TEXT NOT NULL , Score INTEGER NOT NULL ) ");

				dbCmd.CommandText = sqlQuery;
				dbCmd.ExecuteScalar ();
				dbconnection.Close ();
     }
	}
	}

	private void ShowScore()
	{
		GetScore ();

		foreach (GameObject score in GameObject.FindGameObjectsWithTag ("Score")) {
			Destroy (score);
		}

		for (int i = 0; i < TopRank; i++) 
		{
			if (i <= highscore.Count-1) {
				GameObject tmpobjec = Instantiate (ScorePrefab);
				highscores tmpscore = highscore [i];
				tmpobjec.GetComponent <highscorescript> ().SetScore (tmpscore.Name, tmpscore.Score.ToString (), "#" + (i + 1).ToString ());

				tmpobjec.transform.SetParent (scoreParent);
				tmpobjec.GetComponent <RectTransform> ().localScale = new Vector3 (1, 1, 1);
			}
		}

	}
	public void DeleteExtraScores()
	{
		GetScore ();
		if (SaveScores <= highscore.Count) 
		{
			int deleteCount = highscore.Count - SaveScores;
			highscore.Reverse ();

			using (IDbConnection dbConnection = new SqliteConnection(connectionString))
			{
				dbConnection.Open ();
				using (IDbCommand dbCmd= dbConnection.CreateCommand())
				{
					for (int i = 0; i < deleteCount; i++) 
					{
						string sqlQuery = string.Format ("DELETE FROM highscore WHERE PLAYERID= \"{0}\"", highscore [i].ID);
						dbCmd.CommandText = sqlQuery;
						dbCmd.ExecuteScalar ();
					}
						dbConnection.Close ();
				}
			}
		}
	} 
}
