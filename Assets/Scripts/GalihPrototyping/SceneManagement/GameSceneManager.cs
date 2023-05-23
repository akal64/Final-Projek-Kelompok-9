using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
	public void Initialize () {
		GenerateStartLevel();
	}

	private void GenerateStartLevel () {
		SceneManager.LoadSceneAsync("Level 1", LoadSceneMode.Additive);
	}

}
