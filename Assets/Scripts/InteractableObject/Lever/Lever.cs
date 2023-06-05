using UnityEngine;

public class Lever : MonoBehaviour
{

    [SerializeField] private SlidingDoor slidingDoor;
    [SerializeField] private GameObject rotatingPoint;
	[SerializeField] private float rotationSpeed = 100f;
	[SerializeField] private SpriteRenderer leverIndicator;

	private Quaternion targetRotation;
	private bool isLeverActive = false;
	private bool isLeverPulled = false;


	private void Start () {
		Initialize();
	}

	public void Initialize() {

		slidingDoor.Initialize();

		if (!isLeverPulled) {
            slidingDoor.SetDoorOpen(false);
            IndicatorVisual(isLeverPulled);
            targetRotation = Quaternion.Euler(0f, 0f, -45f);
			isLeverActive = false;
        }

		targetRotation = rotatingPoint.transform.rotation;

	}

    private void Update() {

		Quaternion newRotation = Quaternion.RotateTowards(rotatingPoint.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
		rotatingPoint.transform.rotation = newRotation;
		
		if (isLeverPulled && !isLeverActive) {
			ActivateLever();
		} else if (!isLeverPulled && isLeverActive) {
			DeactivateLever();
		}

		IndicatorVisual(isLeverPulled);

	}

	public void OnInteract () {

		if (isLeverPulled) {
			isLeverPulled = false;
		} else if (!isLeverPulled) {
			isLeverPulled = true;
		}

	}

    private void ActivateLever () {
		targetRotation *= Quaternion.Euler(0f, 0f, 90f);
		slidingDoor.SetDoorOpen(true);
		isLeverActive = true;
    }

    private void DeactivateLever () {
		targetRotation *= Quaternion.Euler(0f, 0f, -90f);
		slidingDoor.SetDoorOpen(false);
		isLeverActive = false;
    }

    private void IndicatorVisual (bool isOn) {
        if (isOn) {
			leverIndicator.color = Color.green;
		} else {
			leverIndicator.color = Color.red;
		}
    }

}
