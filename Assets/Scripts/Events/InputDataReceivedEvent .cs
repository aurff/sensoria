using UnityEngine;

public class InputDataReceivedEvent  : EgoEvent
{
	public readonly int data;
	public readonly int playerID;
	public InputDataReceivedEvent (int data, int playerID)
	{
		this.data = data;
		this.playerID = playerID;
	}
}
