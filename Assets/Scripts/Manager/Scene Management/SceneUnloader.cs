using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUnloader : MonoBehaviour
{
	[SerializeField] int lastSceneBuildIndex;

	private void OnTriggerEnter2D (Collider2D collision) {
		CheckCollision(collision);
	}

	private void OnTriggerStay2D (Collider2D collision) {
		CheckCollision(collision);
	}

	private void OnTriggerExit2D (Collider2D collision) {
		CheckCollision(collision);
	}

	private void CheckCollision (Collider2D collision) {

		if (lastSceneBuildIndex != -1) {
			if (collision.gameObject.name == "Player" && SceneManager.GetSceneByBuildIndex(lastSceneBuildIndex).isLoaded) {
				SceneManager.UnloadSceneAsync(lastSceneBuildIndex);
			}
		}

	}
}