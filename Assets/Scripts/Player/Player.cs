using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Press L to make player take damage")]
    public int damage = 5; // temporary

    public void Initialize() {
        currentHealth = maxHealth;
    }

    public int getHealth(string info) {
        return info switch {
            "current" => currentHealth,
            "max" => maxHealth,
            _ => damage
        };
    }

    public void Damaged() {
        currentHealth -= damage; // temporary

        
    }
}
