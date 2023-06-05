using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Door door;

	private void OnCollisionEnter2D(Collision2D collision) {
        door.SetCollideStatus(true);
    }

    private void OnCollisionExit2D(Collision2D collision) {
		door.SetCollideStatus(false);
	}
}
