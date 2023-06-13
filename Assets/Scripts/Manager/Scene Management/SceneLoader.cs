using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	[SerializeField] private int nextSceneBuildIndex;
	public static bool load;

	private void OnTriggerStay2D (Collider2D collision) {
		Check(collision);
	}


	private void Check (Collider2D collision) {
		if (nextSceneBuildIndex != -1 && !SceneManager.GetSceneByBuildIndex(nextSceneBuildIndex).isLoaded) {
			if (collision.gameObject.name == "Player") {
				if (load) {
					load = false;
					return;
				}

				LoadSceneAsync(nextSceneBuildIndex);
			}
		}
	}

	private void LoadSceneAsync (int sceneBuildIndex) {
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneBuildIndex, LoadSceneMode.Additive);
		asyncLoad.completed += operation => {
			SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneBuildIndex));
		};

		load = true;
	}
}
