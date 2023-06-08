using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public int damage = 5; // temporary

    public void Initialize() {
        currentHealth = maxHealth;
    }

    private void Update() {
        //if (Input.GetKeyDown(KeyCode.L)) {
        //    Damaged(20);
        //}
    }

    public int getHealth(string info) {
        // ini buat ngetes
        switch (info) {
            case "current":
                return currentHealth;
            case "max":
                return maxHealth;
            default: return damage;
        }
    }

    public void Damaged() {
        currentHealth -= damage; // temporary

        
    }
}
