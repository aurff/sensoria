using UnityEngine;

public class AnimationSystem : EgoSystem<EgoConstraint<Transform, PlayerComponent, Animator, JumpComponent, MovementComponent, OnCollisionEnter2DComponent>>
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
					animator.SetBool("running", true);
					animator.SetBool("running2", true);
				}

				if (e.data == 3 && animator.GetBool("running") == false)
				{
					animator.SetBool("running", true);
					animator.SetBool("running2", true);
				}

				if (e.data == 2 && animator.GetBool("running") == true) {

					animator.SetBool("running", false);
				}

				if (e.data == 4 & animator.GetBool("running2") == true)
				{
					animator.SetBool("running2", false);
				}
					
				if (jump.jumpstatus == JumpComponent.Jumpstatus.jumping && animator.GetBool("jumping") == false) {
						animator.SetBool("jumping", true);
						animator.SetBool("grounded", false);
				}
			
				if (jump.jumpstatus == JumpComponent.Jumpstatus.falling && animator.GetBool("jumping") == true) {
					animator.SetBool("jumping", false);
				}
			}
		});

	}

	void Handle(PlayerHitEvent e) {
		constraint.ForEachGameObject ((egoComponent, transform, player, animator, jump, movement, onCollisionEnter) => {
			if (e.playerID == player.playerID) {
				animator.SetBool ("hit", true);
			}
		});
	}

	void Handle(CollisionEnter2DEvent e) {
		Debug.Log("Enter Collision 2D Handler");
		Debug.Log(e.egoComponent1.name);
		constraint.ForEachGameObject ((egoComponent, transform, player, animator, jump, movement, onCollisionEnter) => {
			if (e.egoComponent2.HasComponents<Ground>() && animator.GetBool("grounded") == false ) {
				animator.SetBool("grounded", true);
			}
		});
	}
}