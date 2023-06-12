using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private int maxHealth = 100;
	[SerializeField] private int currentHealth;
	[SerializeField] private int currentTrash;

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

	public void HealthRegen(int health) {
		currentHealth += health;
	}

	public void AddTrash() {
		currentTrash++;
	}

	public int GetCurrentTrash() {
		return currentTrash;
	}
}
