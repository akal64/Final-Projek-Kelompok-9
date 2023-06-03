using UnityEngine;

public class FloatingObject : MonoBehaviour
{
	private enum ObjectState { Idle, BeingCarried, BeingThrown }

	[SerializeField] private ObjectState objectState;
	[SerializeField] private Rigidbody2D objectRigidbody2D;

	private void Start () {
		SetStateIdle();
	}

	public void SetStateIdle () {
		objectState = ObjectState.Idle;
		SetKinematic(true);

		//objectRigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
	}

	public void SetStateBeingCarried () {
		objectState = ObjectState.BeingCarried;
		SetKinematic(true);

		//objectRigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
	}

	public void SetStateBeingThrown () {
		objectState = ObjectState.BeingThrown;
		SetKinematic(false);

		//objectRigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
	}

	private void FixedUpdate () {
		if (objectRigidbody2D.velocity == Vector2.zero) {
			SetStateIdle();
		}
	}

	public void SetVelocity (Vector2 value) {
		objectRigidbody2D.velocity = value;
	}

	private void SetKinematic (bool value) {
		objectRigidbody2D.isKinematic = value;
	}


}

