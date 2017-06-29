using UnityEngine;
using UnityEngine.UI;
public class ScoreUISystem : EgoSystem<EgoConstraint<ScoreUIComponent>>
{
	public override void Start()
	{
		EgoEvents<ScoreEvent>.AddHandler(Handle);
		EgoEvents<SubtractScoreEvent>.AddHandler(Handle);
	}

	public override void Update()
	{
		
	}

	public override void FixedUpdate()
	{
		
	}

	void Handle(ScoreEvent e)
	{
		constraint.ForEachGameObject ((egoComponent, scoreUI) => {

			if (e.playerID == scoreUI.playerID && e.score == scoreUI.scoreID)
			{
				egoComponent.gameObject.GetComponent<Image>().enabled = true;
			}
		});
	}

	void Handle (SubtractScoreEvent e)
	{
		constraint.ForEachGameObject ((egoComponent, scoreUI) => {

			if (e.playerID == scoreUI.playerID && e.scoreID == scoreUI.scoreID)
			{
				egoComponent.gameObject.GetComponent<Image>().enabled = false;
			}
		});	
	}
}