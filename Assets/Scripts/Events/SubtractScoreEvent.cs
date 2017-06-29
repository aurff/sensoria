using UnityEngine;

public class SubtractScoreEvent : EgoEvent
{
	public readonly int playerID;
	public readonly int scoreID;
	public SubtractScoreEvent(int playerID, int scoreID)
	{
		this.playerID = playerID;
		this.scoreID = scoreID;
	}
}
