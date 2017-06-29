using UnityEngine;

public class PlayerNotReadyEvent : EgoEvent
{
	public readonly int playerID;
	public PlayerNotReadyEvent(int playerID)
	{
		this.playerID = playerID;
	}
}
