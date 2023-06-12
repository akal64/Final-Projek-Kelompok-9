using UnityEngine;

public class Radiation : MonoBehaviour
{
	[SerializeField] private int damage = 10;
	[SerializeField] private float damageInterval = 5f;

	private bool isPlayerInside = false;
	private float damageTimer = 0f;

	private void Update () {
		if (isPlayerInside) {
			damageTimer += Time.deltaTime;
			if (damageTimer >= damageInterval) {
				GameManager.instance.DamageByRadiation(damage);
				damageTimer = 0f;
			}
		}
	}

	private void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag("Player")) {
			isPlayerInside = true;
			damageTimer = 0f;
		}
	}

	private void OnTriggerExit2D (Collider2D collision) {
		if (collision.CompareTag("Player")) {
			isPlayerInside = false;
			damageTimer = 0f;
		}
	}
}
