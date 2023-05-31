using System;
using UnityEngine;

public class Door : MonoBehaviour
{
	[SerializeField] private GameObject rotatingPoint;
	[SerializeField] private float rotationSpeed = 100f;

	private bool isDoorOpen = false;
	private bool isSwitchCollide = false;
	private Quaternion targetRotation;

	private void Awake () {
		targetRotation = rotatingPoint.transform.rotation;
	}

	private void Update () {

		Quaternion newRotation = Quaternion.RotateTowards(rotatingPoint.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
		rotatingPoint.transform.rotation = newRotation;

		Debug.Log(isDoorOpen);
		Debug.Log(isSwitchCollide);

		if (isSwitchCollide && !isDoorOpen) {
			OpenDoor();
		} else if (!isSwitchCollide && isDoorOpen) {
			CloseDoor();
		}

	}

	public void SetCollideStatus (bool isSwitchCollide) {
		this.isSwitchCollide = isSwitchCollide;
	}

	private void OpenDoor () {
		targetRotation *= Quaternion.Euler(0f, 0f, -90f);
		isDoorOpen = true;
	}

	private void CloseDoor () {
		targetRotation *= Quaternion.Euler(0f, 0f, 90f);
		isDoorOpen = false;
	}

}
