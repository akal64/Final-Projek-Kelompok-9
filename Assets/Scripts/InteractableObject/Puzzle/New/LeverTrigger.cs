
using UnityEngine;

public class LeverTrigger : ObjectTrigger
{

	[Header("Object References")]
	[SerializeField] private GameObject rotatingPoint;
	[SerializeField] private SpriteRenderer leverIndicator;

	[Header("Object Settings")]
	[SerializeField] private float rotationSpeed = 100f;

	private Quaternion targetRotation;

	private void Start () {

		objectState = PuzzleObjectState.Off;

		objectType = PuzzleObjectType.Lever;

		if (objectState == PuzzleObjectState.Off) {
			SetObjectActivationStatus(false);
			IndicatorVisual(false);
			targetRotation = Quaternion.Euler(0f, 0f, -45f);
			isActivated = false;
		}

		targetRotation = rotatingPoint.transform.rotation;
	}

	private void Update () {

		Quaternion newRotation = Quaternion.RotateTowards(rotatingPoint.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
		rotatingPoint.transform.rotation = newRotation;

		if (objectState == PuzzleObjectState.Active && !isActivated) {
			ActivateLever();
			IndicatorVisual(true);

		} else if (objectState == PuzzleObjectState.Off && isActivated) {
			DeactivateLever();
			IndicatorVisual(false);
		}

	}

	public void OnInteract () {

		if (objectType == PuzzleObjectType.Lever) {
			if (objectState == PuzzleObjectState.Off) {
				objectState = PuzzleObjectState.Active;

			} else if (objectState == PuzzleObjectState.Active) {
				objectState = PuzzleObjectState.Off;

			}
		}

	}

	private void ActivateLever () {

		targetRotation *= Quaternion.Euler(0f, 0f, 90f);
		SetObjectActivationStatus(true);
		isActivated = true;

	}

	private void DeactivateLever () {

		targetRotation *= Quaternion.Euler(0f, 0f, -90f);
		SetObjectActivationStatus(false);
		isActivated = false;

	}

	private void IndicatorVisual (bool isOn) {

		if (isOn) {

			leverIndicator.color = Color.green;

		} else {

			leverIndicator.color = Color.red;

		}

	}
}
