using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndSystem : EgoSystem
{
	public override void Start()
	{
		EgoEvents<GameEndEvent>.AddHandler(Handle);
	}

	public override void Update()
	{
		
	}

	public override void FixedUpdate()
	{
		
	}

	void Handle(GameEndEvent e)
	{
		if (e.playerID == 1)
		{
			SceneManager.LoadScene("Player1Win");
		}

		if (e.playerID == 2)
		{
			SceneManager.LoadScene("Player2Win");
		}
	}
}