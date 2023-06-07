using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUnloader : MonoBehaviour
{
	[SerializeField] int lastSceneBuildIndex;

	private void OnTriggerEnter2D (Collider2D collision) {
		if (collision.gameObject.name == "Player" && SceneManager.GetSceneByBuildIndex(lastSceneBuildIndex).isLoaded) {
			SceneManager.UnloadSceneAsync(lastSceneBuildIndex);
		}
	}
}