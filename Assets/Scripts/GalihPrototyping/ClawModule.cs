using UnityEngine;

public class ClawModule : MonoBehaviour
{

	bool isObjectNearby = false;

	private void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.CompareTag("InteractableTrash")) {
			isObjectNearby = true;
		}
	}

	private void OnCollisionExit2D (Collision2D collision) {
		isObjectNearby = false;
	}

	public void Interact () {
		if (isObjectNearby) {
			PickTrash();
		} else {
			Debug.Log("No object nearby");
		}
	}

	private void PickTrash () {
		Debug.Log("Object is Interacted");
	}
}
