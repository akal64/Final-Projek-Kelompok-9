using UnityEngine;

public class Radiation : MonoBehaviour
{
	[SerializeField] private int damage = 10;
	[SerializeField] private float damageInterval = 5f;

	private bool isPlayerInside = false;
	private float damageTimer = 0f;
	private PlayerMovement playerMovement;

	private void Start() {
		// Get the PlayerMovement component from the Player GameObject
		playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

		// Access the droneSpeed variable from the PlayerMovement component
        float droneSpeed = playerMovement.droneSpeed;
	}
	private void Update () {
		if (isPlayerInside) {
			// Used fixedDeltaTime instead of deltaTime to make the radiation damage more responsive
			damageTimer += Time.fixedDeltaTime;
			if (damageTimer >= damageInterval) {
				// Apply damage to the player
				GameManager.instance.DamageByRadiation(damage);
				damageTimer = 0f;
			}
		}
	}

	private void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag("Player")) {
			isPlayerInside = true;
			damageTimer = 0f;

			playerMovement.droneSpeed = 3f; // Slows down the droneSpeed in PlayerMovement
		}
	}

	private void OnTriggerExit2D (Collider2D collision) {
		if (collision.CompareTag("Player")) {
			isPlayerInside = false;
			damageTimer = 0f;

        	playerMovement.droneSpeed = 10f; // Restore the droneSpeed to its original value when player exits the radiation
		}
	}
}
