
using UnityEngine;

public class ButtonTrigger : ObjectTrigger
{

	public void Start () {
		objectType = PuzzleObjectType.Lever;
	}

	private void Update () {
		if (isActivated && objectState == PuzzleObjectState.Off) {

			Activate();

		} else if (!isActivated && objectState == PuzzleObjectState.Active) { 
		
			ShutDown();

		}
	}

	private void OnCollisionEnter2D (Collision2D collision) {
		isActivated = true;
		Activate();
		objectState = PuzzleObjectState.Active;

	}

	private void OnCollisionExit2D (Collision2D collision) {
		isActivated = false;
		ShutDown();
		objectState = PuzzleObjectState.Off;

	}

	private void Activate () {
		SetObjectActivationStatus(true);
	}

	private void ShutDown () {
		SetObjectActivationStatus(false);
	}
}
