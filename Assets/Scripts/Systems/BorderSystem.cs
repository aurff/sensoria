using UnityEngine;

public class BorderSystem : EgoSystem<EgoConstraint<PlayerComponent>>
{
	public override void Start()
	{
		
	}

	public override void Update()
	{
		constraint.ForEachGameObject ((egoComponent, player) => {

			if (player.transform.position.x <= player.leftBorder || player.transform.position.x >= player.rightBorder || 
				player.transform.position.y < player.bottomBorder)
			{
				if (player.score > 0)
				{
					player.score--;
					EgoEvents<SubtractScoreEvent>.AddEvent(new SubtractScoreEvent(player.playerID, player.score));
				}
				player.transform.position = player.initialPosition;
			}
		});
	}
}