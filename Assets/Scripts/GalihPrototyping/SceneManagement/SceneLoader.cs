using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	[SerializeField] private string nextSceneName;
	public static bool load;

	private void OnTriggerEnter2D (Collider2D collision) {
		Check(collision);
	}

	private void OnTriggerExit2D (Collider2D collision) {
		Check(collision);
	}

	private void Check (Collider2D collision) {
		if (collision.gameObject.name == "Player" && !SceneManager.GetSceneByName(nextSceneName).isLoaded) {

			if (load) {
				load = false;
				return;
			}

			SceneManager.LoadScene(nextSceneName, LoadSceneMode.Additive);
			load = true;
		}
	}
}
