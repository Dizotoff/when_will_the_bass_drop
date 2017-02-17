using System.Collections;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.Collections.Generic;

public class HighScoreManager : MonoBehaviour {
	
	private string connectionString;
	private List <highscores> highscore = new List<highscores> ();


	void Start () {
		connectionString = "URI= file:" + Application.dataPath + "/highscore.sqlite";
		GetScore ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void InsertScore(string name, int newScore)
	{
		using (IDbConnection dbconnection = new SqliteConnection (connectionString)) 
		{
			dbconnection.Open ();

			using (IDbCommand dbCmd = dbconnection.CreateCommand ()) {
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
	}
}
