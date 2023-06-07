using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	[SerializeField] private int nextSceneBuildIndex;
	public static bool load;

	private void OnTriggerEnter2D (Collider2D collision) {
		Check(collision);
	}

	private void OnTriggerStay2D (Collider2D collision) {
		Check(collision);
	}

	private void OnTriggerExit2D (Collider2D collision) {
		Check(collision);
	}

	private void Check (Collider2D collision) {
		if (nextSceneBuildIndex != -1) {
			if (collision.gameObject.name == "Player" && !SceneManager.GetSceneByBuildIndex(nextSceneBuildIndex).isLoaded) {

				if (load) {
					load = false;
					return;
				}

				SceneManager.LoadScene(nextSceneBuildIndex, LoadSceneMode.Additive);
				load = true;
			}
		}
	}
}