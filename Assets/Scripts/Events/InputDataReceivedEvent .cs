using UnityEngine;

public class InputDataReceivedEvent  : EgoEvent
{
	public readonly int data;
	public InputDataReceivedEvent (int data)
	{
		this.data = data;
	}
}
