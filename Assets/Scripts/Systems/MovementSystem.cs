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
		EgoEvents<InputDataReceivedEvent>.AddHandler(Handle);
	}
	
	// Update is called once per frame
	public override void FixedUpdate ()
	{		
		constraint.ForEachGameObject ((egoComponent, transform, movement) =>
		{
			/*
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
			}*/

			// Move Player Right
			if (movement.canMoveRight && !egoComponent.HasComponents<JumpStatus>())
			{
				MovePlayer(transform, movement.velocity);
				movement.viewDirection = MovementComponent.ViewDirection.right;
			}

			// Move Player Left
			if (movement.canMoveLeft && !egoComponent.HasComponents<JumpStatus>())
			{
				MovePlayer(transform, -movement.velocity);
				movement.viewDirection = MovementComponent.ViewDirection.left;
			}
			// No Button Pressed 
			/*if (((Input.GetKeyUp(movement.keyCodeLeft) || Input.GetKeyUp(movement.keyCodeRight)) && !egoComponent.HasComponents<JumpStatus>()) || (!Input.GetKey(movement.keyCodeLeft) && !Input.GetKey(movement.keyCodeRight) && !egoComponent.HasComponents<JumpStatus>())) {
				movement.viewDirection = MovementComponent.ViewDirection.none;
			}*/
			
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

	void Handle(InputDataReceivedEvent e)
	{
		constraint.ForEachGameObject ((egoComponent, transform, movement) =>
		{
			if (e.playerID == movement.playerID)
			{
				//Debug.Log(e.data + ", " + e.playerID);
				if (e.data == 1)
				{
					//Debug.Log(e.playerID + ": Start move right!");
					movement.canMoveRight = true;
					movement.canMoveLeft = false;
				}
				else if (e.data == 2)
				{
					//Debug.Log(e.playerID + ": Stop move right!");
					movement.canMoveRight = false;
				}

				if (e.data == 3)
				{
					movement.canMoveLeft = true;
					movement.canMoveRight = false;
				}
				else if (e.data == 4)
				{
					movement.canMoveLeft = false;
				}
			}
		});
	}
		
	void MovePlayer(Transform transform, float speed)
	{
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}
}