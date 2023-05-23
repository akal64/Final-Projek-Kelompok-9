using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private GameSceneManager gameSceneManager;

	private void Start () {
		gameSceneManager.Initialize();
	}

}
