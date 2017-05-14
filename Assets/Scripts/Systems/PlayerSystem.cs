// PlayerSystem.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : EgoSystem<EgoConstraint<Transform, PlayerComponent>> {

	// Use this for initialization
	public override void Start () {
		//Register Event Handlers
		EgoEvents<PlayerHitEvent>.AddHandler (Handle);

		constraint.ForEachGameObject ((egoComponent, transform, player) =>
		{
			player.initialPosition = transform.position;
		});
	}
	
	public override void Update ()
	{		
		constraint.ForEachGameObject ((egoComponent, transform, player) =>
			{
				//Keep Player within boundaries
				if (transform.position.x >= player.rightBorder)
				{
					transform.SetX(player.rightBorder);
				}

				if (transform.position.x <= player.leftBorder)
				{
					transform.SetX(player.leftBorder);
				}
			});
	}

	void Handle (PlayerHitEvent e)
	{
		constraint.ForEachGameObject ((egoComponent, transform, player) => {
			transform.position = player.initialPosition;
		});
	}
}
