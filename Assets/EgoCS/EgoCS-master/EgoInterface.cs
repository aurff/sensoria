//EgoInterface.cs
using UnityEngine;
using System.Collections.Generic;

public class EgoInterface : MonoBehaviour
{
	static EgoInterface()
	{
		EgoSystems.Add (
			new MovementSystem (),
			new JumpSystem (),
			new GameStateSystem(),
			new PlayerSystem(),
			new GameEndSystem(),
			new StreamSystem(),
			new StartScreenSystem(),
			new StartScreenUISystem(),
			new PlayerReadySystem(),
			new SceneManagementSystem(),
			new AnimationSystem(),
			new ScoreUISystem(),
			new BorderSystem(),
			new RestartGameSystem()
		);
    }

    void Start()
    {
    	EgoSystems.Start();
	}
	
	void Update()
	{
		EgoSystems.Update();
	}
	
	void FixedUpdate()
	{
		EgoSystems.FixedUpdate();
	}
}
