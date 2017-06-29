using UnityEngine;
using UnityEngine.UI;

public class StartScreenSystem : EgoSystem<EgoConstraint<TimerComponent>>
{
	public override void Start()
	{
		EgoEvents<PlayerReadyEvent>.AddHandler(Handler);
		EgoEvents<PlayerNotReadyEvent>.AddHandler(Handler);
	}

	public override void Update()
	{
		constraint.ForEachGameObject ((ego, timerComponent) => { 

			if(timerComponent.startTimer)
			{
				timerComponent.timer -= Time.deltaTime;
		
				if (timerComponent.timer < 0.5f)
				{
					ego.GetComponent<Text>().enabled = false;
				}
				if (timerComponent.timer < 0)
				{
					ego.GetComponent<Text>().enabled = true;
					timerComponent.timer = 1f;
				}
			}
		});
	}
		
	void Handler(PlayerReadyEvent e)
	{
		constraint.ForEachGameObject ((ego, timerComponent) => {

			if (e.playerID == timerComponent.playerID)
			{
				timerComponent.startTimer = false;
				timerComponent.timer = 1f;
				ego.gameObject.GetComponent<Text>().enabled = true;
				ego.gameObject.GetComponent<Text>().text = "READY!";
			}
		});
	}

	void Handler (PlayerNotReadyEvent e)
	{
		constraint.ForEachGameObject ((ego, timerComponent) => {
			
			if (e.playerID == timerComponent.playerID)
			{
				timerComponent.startTimer = true;
				ego.gameObject.GetComponent<Text>().text = "SIT DOWN";
			}
		});
	}
}