using UnityEngine;

public class PlayerReadyEvent : EgoEvent
{
	public readonly int playerID;
	public PlayerReadyEvent(int playerID)
	{
		this.playerID = playerID;
	}
}
