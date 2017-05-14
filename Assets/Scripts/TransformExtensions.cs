// TransformExtensions.cs
using System.Collections;
using UnityEngine;

public static class TransformExtensions {

	public static Transform SetX(this Transform transform, float x) {
		var newPosition = transform.position;
		newPosition.x = x;
		transform.position = newPosition;
		return transform;
	}

	public static Transform SetY(this Transform transform, float y)
	{
		var newPosition = transform.position;
		newPosition.y = y;
		transform.position = newPosition;
		return transform;
	}

	public static Transform SetZ(this Transform transform, float z)
	{
		var newPosition = transform.position;
		newPosition.z = z;
		transform.position = newPosition;
		return transform;
	}
}
