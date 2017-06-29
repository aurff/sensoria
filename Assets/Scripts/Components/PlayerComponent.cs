//PlayerComponent.cs
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerComponent : MonoBehaviour 
{
	public int playerID;
	public Vector3 initialPosition;
	public float rightBorder = 10f;
	public float leftBorder = -10f;
	public float bottomBorder = -6.5f;
	public int score;

}
