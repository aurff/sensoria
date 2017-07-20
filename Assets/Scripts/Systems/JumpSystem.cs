// JumpSystem.cs
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class JumpSystem : EgoSystem<EgoConstraint<Transform, Rigidbody2D, JumpComponent, PlayerComponent, OnCollisionEnter2DComponent, Animator, AnimationComponent, SpriteRenderer, SerialPortComponent>> {

	// Use this for initialization
	public override void Start()
	{
		//Register Event Handlers
		EgoEvents<CollisionEnter2DEvent>.AddHandler (Handle);
		EgoEvents<InputDataReceivedEvent>.AddHandler (Handle);

		constraint.ForEachGameObject ((egoComponent, transform, rigbody, jump, player, onCollissionEnter, Animator, AnimationComponent, spriteRend, serialPort) => {
			jump.jumpstatus = JumpComponent.Jumpstatus.grounded;
		});
	}
	
	// Update is called once per frame
	public override void FixedUpdate () {
		/*constraint.ForEachGameObject ((egoComponent, transform, rigbody, jump) => {
			if (Input.GetKeyDown(jump.keyCodeJump) && jump.jumpstatus == JumpComponent.Jumpstatus.grounded)
			{
				jump.jumpstatus = JumpComponent.Jumpstatus.jumping;
				Ego.AddComponent<JumpStatus>(egoComponent);
				rigbody.gravityScale = 0;
				jump.jumpPosition = transform.position;
			}

			if (Input.GetKey(jump.keyCodeJump) && jump.jumpstatus == JumpComponent.Jumpstatus.jumping) {
				rigbody.MovePosition(Vector3.Lerp(transform.position, new Vector3(transform.position.x, jump.jumpPosition.y + jump.jumpHeight, transform.position.z), jump.jumpTime));
			}

			if (Input.GetKeyUp(jump.keyCodeJump) && jump.jumpstatus == JumpComponent.Jumpstatus.jumping)
			{
				rigbody.gravityScale = jump.gravityScale;
				jump.jumpstatus = JumpComponent.Jumpstatus.falling;
			}
		});*/

		constraint.ForEachGameObject ((egoComponent, transform, rigbody, jump, player, onCollissionEnter, Animator, AnimationComponent, spriteRend, serialPort) => {
			if (jump.canJump && jump.jumpstatus == JumpComponent.Jumpstatus.grounded)
			{
				jump.jumpstatus = JumpComponent.Jumpstatus.jumping;
				Ego.AddComponent<JumpStatus>(egoComponent);
				rigbody.gravityScale = 0;
				jump.jumpPosition = transform.position;
			}

			if (jump.canJump && jump.jumpstatus == JumpComponent.Jumpstatus.jumping) {
				rigbody.MovePosition(Vector3.Lerp(transform.position, new Vector3(transform.position.x, jump.jumpPosition.y + jump.jumpHeight, transform.position.z), jump.jumpTime));
			}

			if (!jump.canJump && jump.jumpstatus == JumpComponent.Jumpstatus.jumping)
			{
				rigbody.gravityScale = jump.gravityScale;
				jump.jumpstatus = JumpComponent.Jumpstatus.falling;
			}
		});
	}
		

	void Handle(CollisionEnter2DEvent e)
	{
		constraint.ForEachGameObject ((egoComponent, transform, rigbody, jump, player, onCollissionEnter, Animator, AnimationComponent, spriteRend, serialPort) => {
			//When Player lands on ground
			if (e.egoComponent2.HasComponents<Ground>() && jump.jumpstatus == JumpComponent.Jumpstatus.falling ) {
				jump.jumpstatus = JumpComponent.Jumpstatus.grounded;
				Ego.DestroyComponent<JumpStatus>(egoComponent);
			}
			//When Player jumps against a plattform
			if (e.egoComponent2.HasComponents<Ground>() && jump.jumpstatus == JumpComponent.Jumpstatus.jumping ) {
				jump.jumpPosition.y = egoComponent.transform.position.y - jump.jumpHeight;
			}
			//When Player lands on Player
			if (e.egoComponent2.HasComponents<PlayerComponent> () && e.egoComponent1.HasComponents<JumpComponent>()) {

				if (e.egoComponent1.GetComponent<JumpComponent>().jumpstatus == JumpComponent.Jumpstatus.falling) {		
					e.egoComponent1.GetComponent<PlayerComponent>().score++;
					if (e.egoComponent1.GetComponent<PlayerComponent>().score == 12)
					{
						EgoEvents<GameEndEvent>.AddEvent(new GameEndEvent(e.egoComponent1.GetComponent<PlayerComponent>().playerID));
					}
					EgoEvents<ScoreEvent>.AddEvent(new ScoreEvent(e.egoComponent1.GetComponent<PlayerComponent>().playerID, e.egoComponent1.GetComponent<PlayerComponent>().score));
					EgoEvents<PlayerHitEvent>.AddEvent(new PlayerHitEvent());
				}
			}
			if (e.egoComponent1.HasComponents<PlayerComponent> () && e.egoComponent2.HasComponents<JumpComponent>()) {

				if (e.egoComponent2.GetComponent<JumpComponent>().jumpstatus == JumpComponent.Jumpstatus.falling) {
					e.egoComponent2.GetComponent<PlayerComponent>().score++;
					if (e.egoComponent2.GetComponent<PlayerComponent>().score == 12)
					{
						EgoEvents<GameEndEvent>.AddEvent(new GameEndEvent(e.egoComponent2.GetComponent<PlayerComponent>().playerID));
					}
					EgoEvents<ScoreEvent>.AddEvent(new ScoreEvent(e.egoComponent2.GetComponent<PlayerComponent>().playerID, e.egoComponent2.GetComponent<PlayerComponent>().score));
					EgoEvents<PlayerHitEvent>.AddEvent(new PlayerHitEvent());
				}
			}
		});
	}

	void Handle(InputDataReceivedEvent e)
	{
		constraint.ForEachGameObject ((egoComponent, transform, rigbody, jump, player, onCollissionEnter, Animator, AnimationComponent, spriteRend, serialPort) => {

			if (e.playerID == player.playerID)
			{
				//Enable Jumping 
				if (e.data == 5)
				{
					jump.canJump = false;
				}
				//Disable Jumping 
				if (e.data == 6)
				{
					jump.canJump = true;
				}	
			}
		});
	}
}