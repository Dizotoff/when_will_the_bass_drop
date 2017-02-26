using System;

class highscores:IComparable<highscores>
	{
	public int Score { get; set;}
	public string Name { get; set;}
	public int ID { get; set;}

	public highscores(int id,string name, int score){
		this.Score = score;
		this.Name = name;
		this.ID = id;
	}
	public int CompareTo(highscores other)
	{
		if (other.Score < this.Score) {
			return -1;
		} 
		else if (other.Score > this.Score) 
		{
			return 1;
		}
		return 0;
	}
}

