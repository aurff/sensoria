using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerReadySystem : EgoSystem<EgoConstraint<ReadyComponent>>
{
	public override void Start()
	{
		EgoEvents<InputDataReceivedEvent>.AddHandler(Handle);
	}

	public override void Update()
	{
		constraint.ForEachGameObject ((ego, ready) => {

			if (ready.playerOneReady && ready.playerTwoReady)
			{
				var e = new SwitchSceneEvent();
				EgoEvents<SwitchSceneEvent>.AddEvent(e);
			}
		});
		
	}
	void Handle(InputDataReceivedEvent e)
	{
		constraint.ForEachGameObject ((ego, ready) => {

			if (e.data == 5 && e.playerID == 1)
			{
				ready.playerOneReady = true;
				EgoEvents<PlayerReadyEvent>.AddEvent(new PlayerReadyEvent(1));
			}
			if (e.data == 6 && e.playerID == 1)
			{
				ready.playerOneReady = false;
				EgoEvents<PlayerNotReadyEvent>.AddEvent(new PlayerNotReadyEvent(1));
			}
			if (e.data == 5 && e.playerID == 2)
			{
				ready.playerTwoReady = true;
				EgoEvents<PlayerReadyEvent>.AddEvent(new PlayerReadyEvent(2));
			}

			if (e.data == 6 && e.playerID == 2)
			{
				ready.playerOneReady = false;
				EgoEvents<PlayerNotReadyEvent>.AddEvent(new PlayerNotReadyEvent(2));
			}

		});
	
	}
}