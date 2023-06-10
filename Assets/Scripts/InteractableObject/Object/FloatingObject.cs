using UnityEngine;

public class FloatingObject : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private Rigidbody2D objectRigidbody2D;

	[Header("Specs")]
	[SerializeField] private bool useGravity = false;

	private void Start () {
		SetStateIdle();
	}

	public void SetStateIdle () {
		
		if (useGravity) {

			SetKinematic(false);

		} else if(!useGravity) {

			SetKinematic(true);

		}

		//objectRigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
	}

	public void SetStateBeingCarried () {
		SetKinematic(true);

		//objectRigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
	}

	public void SetStateBeingThrown () {
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

