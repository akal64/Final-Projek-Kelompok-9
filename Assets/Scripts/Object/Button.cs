using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private float rotationSpeed = 100f;

    private bool isWallOpen = false;
    private Quaternion targetRotation;

    private void Awake() {
        targetRotation = wall.transform.rotation; 
    }

    private void Update() {
        if (isWallOpen) {
            Quaternion newRotation = Quaternion.RotateTowards(wall.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            wall.transform.rotation = newRotation;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("InteractableObject") && !isWallOpen) {
            isWallOpen = true;
            targetRotation *= Quaternion.Euler(0f, 0f, -90f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.CompareTag("InteractableObject") && isWallOpen) {
            isWallOpen = false;
            targetRotation *= Quaternion.Euler(0f, 0f, 90f);
        }
    }
}
