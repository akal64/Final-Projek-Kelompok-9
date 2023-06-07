using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	[SerializeField] private PlayerControl playerControl;
	[SerializeField] private string surfaceSceneName;

	private void Awake () {
		if (SceneManager.GetSceneByName(surfaceSceneName).isLoaded == false) {

			SceneManager.LoadScene(surfaceSceneName, LoadSceneMode.Additive);

		}

	}

	private void Start () {
		playerControl.Initialize();
	}

	private void OnEnable () {
		playerControl.PauseClicked += OnPauseClicked;
	}

	private void OnDisable () {
		playerControl.PauseClicked -= OnPauseClicked;
	}


	private void OnPauseClicked () {

		// TODO Pause Game

		Debug.Log("Pause Clicked");
	}
}
