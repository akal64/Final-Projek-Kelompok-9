using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUnloader : MonoBehaviour
{
	[SerializeField] private int lastSceneBuildIndex;
	private bool sceneUnloaded;

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
		if (lastSceneBuildIndex != -1 && !sceneUnloaded) {
			if (collision.gameObject.name == "Player" && SceneManager.GetSceneByBuildIndex(lastSceneBuildIndex).isLoaded) {
				UnloadSceneAsync(lastSceneBuildIndex);
			}
		}
	}

	private void UnloadSceneAsync (int sceneBuildIndex) {
		sceneUnloaded = true;

		SceneManager.UnloadSceneAsync(sceneBuildIndex);
	}
}
