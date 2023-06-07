using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	[SerializeField] private PlayerControl playerControl;
	[SerializeField] private int surfaceBuildIndex;

	private bool isFirstSceneIsLoaded = false;

	private void Awake () {
		if (isFirstSceneIsLoaded == false) {
			
			SceneManager.LoadSceneAsync(SceneManager.GetSceneByBuildIndex(surfaceBuildIndex).name, LoadSceneMode.Additive);
			isFirstSceneIsLoaded = true;
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
