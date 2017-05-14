using UnityEngine;

public class JumpEvent : EgoEvent
{
	public enum JumpDirection {left, right};
	public JumpDirection jumpDirection;

	public JumpEvent(string jumpDirection)
	{
		if (jumpDirection == "right") {
			this.jumpDirection = JumpDirection.right;
		}

		if (jumpDirection == "left") {
			this.jumpDirection = JumpDirection.left;
		}
	}
}
