
using UnityEngine;

public class ButtonTrigger : ObjectTrigger
{
    private int collisionCount = 0;

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
        collisionCount++;
        isActivated = true;
		Activate();
		objectState = PuzzleObjectState.Active;

	}

	private void OnCollisionExit2D (Collision2D collision) {
        collisionCount--;
        if (collisionCount <= 0) {
            isActivated = false;
			ShutDown();
			objectState = PuzzleObjectState.Off;
			collisionCount= 0;
		}

	}

	private void Activate () {
		SetObjectActivationStatus(true);
	}

	private void ShutDown () {
		SetObjectActivationStatus(false);
	}
}
