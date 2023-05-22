using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[Header("Player Stat")]
	[SerializeField] private float moveSpeed = 10f;

	[Header("Player Component")]
	[SerializeField] private Rigidbody2D playerRigidbody2D;

	private Vector2 movementDirection;

	void Update () {

		float moveX = Input.GetAxisRaw("Horizontal");
		float moveY = Input.GetAxisRaw("Vertical");

		movementDirection = new Vector2(moveX, moveY).normalized;
	}

	void FixedUpdate () {
		playerRigidbody2D.velocity = movementDirection * moveSpeed;
	}
}
