using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	[SerializeField] private PlayerControl playerControl;

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
