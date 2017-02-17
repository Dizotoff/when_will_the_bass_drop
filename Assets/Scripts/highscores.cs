using System;

class highscores
	{
	public int Score { get; set;}
	public string Name { get; set;}
	public int ID { get; set;}

	public highscores(int id,string name, int score){
		this.Score = score;
		this.Name = name;
		this.ID = id;
	}
	}

