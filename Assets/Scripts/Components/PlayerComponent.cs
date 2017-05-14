//PlayerComponent.cs
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerComponent : MonoBehaviour 
{
	public Vector3 initialPosition;
	public float rightBorder = 6f;
	public float leftBorder = -6f;

}
