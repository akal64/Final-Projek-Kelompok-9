using UnityEngine;

public class SlideDoor : ObjectAction
{
	[SerializeField] private bool reverseDirection = false;
	[SerializeField] private bool moveHorizontal = false;

	[Header("Object References")]
	[SerializeField] private GameObject slidingDoor;

	[Header("Object Specs")]
	[SerializeField] private float moveRange = 2f;
	[SerializeField] private float moveSpeed = 1f;

	private float moveRangeX;
	private float moveRangeY;

	private int multiplier = 1;
	private Vector3 targetPosition;
	private Vector3 originalPosition;

	private void Start () {
		targetPosition = slidingDoor.transform.position;
		originalPosition = slidingDoor.transform.position;
	}

	private void Update () {

		slidingDoor.transform.position = Vector3.MoveTowards(slidingDoor.transform.position, targetPosition, moveSpeed * Time.deltaTime);

		if (isShouldActive && objectState == ObjectState.Off) {

			OpenDoor();

		} else if (!isShouldActive && objectState == ObjectState.Active) {

			CloseDoor();
		}
	
		if (reverseDirection) {
			multiplier = -1;
		} else {
			multiplier = 1;
		}

		if (moveHorizontal) {
			moveRangeX = moveRange;
			moveRangeY = 0;
		} else if (!moveHorizontal) {
			moveRangeY = moveRange;
			moveRangeX = 0;
		}

	}


	private void OpenDoor () {

		targetPosition = new Vector3(slidingDoor.transform.position.x + (moveRangeX * multiplier), slidingDoor.transform.position.y + (moveRangeY * multiplier), slidingDoor.transform.position.z);
		objectState = ObjectState.Active;

	}

	private void CloseDoor () {
		targetPosition = new Vector3(originalPosition.x, originalPosition.y, slidingDoor.transform.position.z);
		objectState = ObjectState.Off;

	}

}
