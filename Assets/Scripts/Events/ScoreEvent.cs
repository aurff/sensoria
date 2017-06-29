using UnityEngine;

public class ScoreEvent : EgoEvent
{
	public readonly int playerID;
	public readonly int score;
	public ScoreEvent(int playerID, int score)
	{
		this.playerID = playerID;
		this.score = score;
	}
}
