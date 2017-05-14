// GameStateComponent.cs
using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
public class GameStateComponent : MonoBehaviour {

	public enum GameState {Running, Menu, Paused};
}
