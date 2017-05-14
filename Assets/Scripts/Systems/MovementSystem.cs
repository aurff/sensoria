// MovementSystem.cs
using UnityEngine;

public class MovementSystem : EgoSystem<EgoConstraint<Transform, MovementComponent>> {

	// Use this for initialization
	public override void Start ()
	{
		constraint.ForEachGameObject ((egoComponent, transform, movement) => {
			movement.viewDirection = MovementComponent.ViewDirection.none;
		});

		EgoEvents<JumpEvent>.AddHandler (Handle);
	}
	
	// Update is called once per frame
	public override void FixedUpdate ()
	{		
		constraint.ForEachGameObject ((egoComponent, transform, movement) =>
		{
			// Move Player Right
			if ( Input.GetKey(movement.keyCodeRight) && !egoComponent.HasComponents<JumpStatus>())
			{
				MovePlayer(transform, movement.velocity);
				movement.viewDirection = MovementComponent.ViewDirection.right;
			}

			// Move Player Left
			if (Input.GetKey(movement.keyCodeLeft) && !egoComponent.HasComponents<JumpStatus>())
			{
				MovePlayer(transform, -movement.velocity);
				movement.viewDirection = MovementComponent.ViewDirection.left;
			}

				if (((Input.GetKeyUp(movement.keyCodeLeft) || Input.GetKeyUp(movement.keyCodeRight)) && !egoComponent.HasComponents<JumpStatus>()) || (!Input.GetKey(movement.keyCodeLeft) && !Input.GetKey(movement.keyCodeRight) && !egoComponent.HasComponents<JumpStatus>())) {
				movement.viewDirection = MovementComponent.ViewDirection.none;
			}
			
			//Player movement in Air
			if (egoComponent.HasComponents<JumpStatus>()) {
				if (movement.viewDirection == MovementComponent.ViewDirection.right) {
					MovePlayer(transform, movement.velocity);
				}
				if (movement.viewDirection == MovementComponent.ViewDirection.left) {
					MovePlayer(transform, -movement.velocity);
				}
			}
		});
	}

	void Handle(JumpEvent e)
	{
		constraint.ForEachGameObject ((egoComponent, transform, movement) =>
		{
			MovementComponent.ViewDirection moveDirectionVar;
			moveDirectionVar = movement.viewDirection;
			EgoEvents<JumpEvent>.AddEvent (new JumpEvent (moveDirectionVar.ToString ()));
		});
	}
		
	void MovePlayer(Transform transform, float speed)
	{
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}
}