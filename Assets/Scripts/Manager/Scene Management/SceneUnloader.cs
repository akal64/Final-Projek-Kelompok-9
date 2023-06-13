using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUnloader : MonoBehaviour
{
	[SerializeField] private int lastSceneBuildIndex;

	private void OnTriggerStay2D (Collider2D collision) {
		if (collision.gameObject.name == "Player" && SceneManager.GetSceneByBuildIndex(lastSceneBuildIndex).isLoaded) {
			SceneManager.UnloadSceneAsync(lastSceneBuildIndex);
		}
	}
}
