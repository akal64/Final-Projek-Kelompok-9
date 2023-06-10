
using UnityEngine;

public class LeverTrigger : ObjectTrigger
{

	[Header("Lever References")]
	[SerializeField] private GameObject rotatingPoint;
	[SerializeField] private SpriteRenderer leverIndicator;

	[Header("Lever Specs")]
	[SerializeField] private float rotationSpeed = 100f;

	private Quaternion targetRotation;

	private void Start () {

		objectState = ObjectState.Off;

		objectType = ObjectType.Lever;

		if (objectState == ObjectState.Off) {
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

		if (objectState == ObjectState.Active && !isActivated) {
			ActivateLever();
			IndicatorVisual(true);

		} else if (objectState == ObjectState.Off && isActivated) {
			DeactivateLever();
			IndicatorVisual(false);
		}

	}

	public void OnInteract () {

		if (objectType == ObjectType.Lever) {
			if (objectState == ObjectState.Off) {
				objectState = ObjectState.Active;

			} else if (objectState == ObjectState.Active) {
				objectState = ObjectState.Off;

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
