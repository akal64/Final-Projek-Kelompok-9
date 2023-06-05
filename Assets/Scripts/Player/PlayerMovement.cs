using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float droneSpeed = 10f;

	private bool isMoving = false;
	private Vector2 direction;
	private Rigidbody2D droneRigidbody2D;


	private void FixedUpdate () {

		if (!isMoving) {
			droneRigidbody2D.velocity = Vector2.zero;

		} else {
			droneRigidbody2D.velocity = direction * droneSpeed;

		}

	}

	public void SetDirection(Vector2 direction) {
		this.direction = direction;
	}

	public void IsDroneMoving(bool value) {
		isMoving = value;
	}

	public void SetDroneRigidbody2D (Rigidbody2D rigidbody2D) {
		this.droneRigidbody2D = rigidbody2D;
	}


}
