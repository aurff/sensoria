// JumpComponent.cs
using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
public class JumpComponent : MonoBehaviour {

	public float timeToJumpToHighestPoint = 0.2f;
	public Vector2 jumpVelocity = new Vector2(0, 1);
	public float jumpHeight = 2f;
	public float jumpTime = 0.5f;
	public Vector3 jumpPosition;
	public KeyCode keyCodeJump;
	public float gravityScale = 1;
	public enum Jumpstatus {jumping, falling, grounded};
	public Jumpstatus jumpstatus;
	public bool canJump;
}
