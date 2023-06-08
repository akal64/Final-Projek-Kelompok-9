using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private int maxHealth = 100;
	private int currentHealth;

	public void Initialize () {
		currentHealth = maxHealth;
	}

	public int GetMaxHealth () {
		return maxHealth;
	}

	public int GetCurrentHealth () {
		return currentHealth;
	}

	public void TakeDamage (int damage) {
		currentHealth -= damage;
	}
}
