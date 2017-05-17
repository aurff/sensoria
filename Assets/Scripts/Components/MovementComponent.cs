// MovementComponent.cs
using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
public class MovementComponent : MonoBehaviour {

	public float velocity = 1f;
	public KeyCode keyCodeRight;
	public KeyCode keyCodeLeft;
	public enum ViewDirection {left, right, none};
	public ViewDirection viewDirection;
	public bool canMoveRight, canMoveLeft;
}
