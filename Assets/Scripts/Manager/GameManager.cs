using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	[SerializeField] private PlayerControl playerControl;
	[SerializeField] private string surfaceSceneName;

	[SerializeField] private Player player;
	[SerializeField] private UIManager UI;

	private void Awake () {
		if (SceneManager.GetSceneByName(surfaceSceneName).isLoaded == false) {

			SceneManager.LoadScene(surfaceSceneName, LoadSceneMode.Additive);

		}

	}

	private void Start () {
		playerControl.Initialize();
        UI.SetMaxHealth(player.getHealth("max"));
		player.Initialize();
    }

	private void OnEnable () {
		playerControl.PauseClicked += OnPauseClicked;
	}

	private void OnDisable () {
		playerControl.PauseClicked -= OnPauseClicked;
	}

    private void Update() {
		// for test
        if (Input.GetKeyDown(KeyCode.L)) {
            OnPlayerDamaged();
        }
    }

    private void OnPauseClicked () {

		// TODO Pause Game

		Debug.Log("Pause Clicked");
	}

	private void OnPlayerDamaged() {
		player.Damaged();
        UI.setHealth(player.getHealth("current"));
    }
}
