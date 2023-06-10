
using UnityEngine;

public class ButtonTrigger : ObjectTrigger
{

	public void Start () {
		objectType = ObjectType.Lever;
	}

	private void Update () {
		if (isActivated && objectState == ObjectState.Off) {

			Activate();

		} else if (!isActivated && objectState == ObjectState.Active) { 
		
			ShutDown();

		}
	}

	private void OnCollisionEnter2D (Collision2D collision) {
		isActivated = true;
		Activate();
		objectState = ObjectState.Active;

	}

	private void OnCollisionExit2D (Collision2D collision) {
		isActivated = false;
		ShutDown();
		objectState = ObjectState.Off;

	}

	private void Activate () {
		SetObjectActivationStatus(true);
	}

	private void ShutDown () {
		SetObjectActivationStatus(false);
	}
}
