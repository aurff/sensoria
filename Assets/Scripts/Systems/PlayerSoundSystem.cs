using UnityEngine;

public class PlayerSoundSystem : EgoSystem<EgoConstraint<Transform, PlayerComponent, Animator, JumpComponent, MovementComponent, OnCollisionEnter2DComponent>>
{
	public override void Start()
	{
		EgoEvents<InputDataReceivedEvent>.AddHandler (Handle);
		EgoEvents<PlayerHitEvent>.AddHandler (Handle);
		EgoEvents<CollisionEnter2DEvent>.AddHandler (Handle);
	}

	void Handle(InputDataReceivedEvent e) {

		constraint.ForEachGameObject ((egoComponent, transform, player, animator, jump, movement, onCollisionEnter) => {


			if (e.playerID == player.playerID) {

				if (e.data == 1 && animator.GetBool("running") == false) {
					
				}

				if (e.data == 3 && animator.GetBool("running") == false)
				{
					


				}

				if (e.data == 2 && animator.GetBool("running") == true) {


				}

				if (e.data == 4 & animator.GetBool("running2") == true)
				{
					
				}

				if (jump.jumpstatus == JumpComponent.Jumpstatus.jumping && animator.GetBool("jumping") == false) {
					
				}

				if (jump.jumpstatus == JumpComponent.Jumpstatus.falling && animator.GetBool("jumping") == true) {
					
				}
			}
		});

	}

	void Handle(PlayerHitEvent e) {
		constraint.ForEachGameObject ((egoComponent, transform, player, animator, jump, movement, onCollisionEnter) => {
			if (e.playerID == player.playerID) {
				
			}
		});
	}

	void Handle(CollisionEnter2DEvent e) {
		constraint.ForEachGameObject ((egoComponent, transform, player, animator, jump, movement, onCollisionEnter) => {
			if (e.egoComponent2.HasComponents<Ground>() && animator.GetBool("grounded") == false ) {
				
			}
		});
	}
}