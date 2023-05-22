using UnityEngine;

public class PlayerController : MonoBehaviour
{

	[SerializeField] private float moveSpeed = 10f;
	[SerializeField] private Rigidbody2D rb;

	private Vector2 movementDirection;

	void Update () {

		float moveX = Input.GetAxisRaw("Horizontal");
		float moveY = Input.GetAxisRaw("Vertical");

		movementDirection = new Vector2(moveX, moveY).normalized;
	}

	void FixedUpdate () {
		rb.velocity = movementDirection * moveSpeed;
	}
}
