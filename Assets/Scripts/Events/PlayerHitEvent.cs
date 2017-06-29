// PlayerHitEvent.cs
using UnityEngine;

public class PlayerHitEvent : EgoEvent
{
	public readonly int playerID;
	public PlayerHitEvent(int playerID)
	{
		this.playerID = playerID;
	}
}
