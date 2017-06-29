using UnityEngine;

public class GameEndEvent : EgoEvent
{
	public readonly int playerID;
	public GameEndEvent(int playerID)
	{
		this.playerID = playerID;
	}
}
