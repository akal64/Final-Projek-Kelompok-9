using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
	[Header("Scene Management")]
	[SerializeField] private string surfaceSceneName;
	
	[SerializeField]
	[Tooltip("If true, the first level will be generated when the game starts. DISABLE FOR DEVELOPMENT ONLY!")]
	private bool generateFirstLevel = true;

	public void Initialize () {

		bool isSceneLoaded = IsSceneLoaded(surfaceSceneName);

		if (generateFirstLevel) {
			if (!isSceneLoaded) {
				SceneManager.LoadScene(surfaceSceneName, LoadSceneMode.Additive);
			}
		}
	}

	private bool IsSceneLoaded(string scene) {
		Scene targetScene = SceneManager.GetSceneByName(scene);
		return targetScene.IsValid() && targetScene.isLoaded;
	}
}
