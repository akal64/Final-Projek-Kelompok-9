using UnityEngine;

public class SlideDoor : ObjectAction
{
	[Header("Object References")]
	[SerializeField] private GameObject slidingDoor;

	[Header("Object Specs")]
	[SerializeField] private float moveRange = 2f;
	[SerializeField] private float moveSpeed = 1f;

	private Vector3 targetPosition;
	private Vector3 originalPosition;

	private void Start () {
		targetPosition = slidingDoor.transform.position;
		originalPosition = slidingDoor.transform.position;
	}

	private void Update () {

		slidingDoor.transform.position = Vector3.MoveTowards(slidingDoor.transform.position, targetPosition, moveSpeed * Time.deltaTime);

		if (isShouldActive && objectState == ObjectState.Off) {

			Debug.Log("If else open door");

			OpenDoor();

		} else if (!isShouldActive && objectState == ObjectState.Active) {

			Debug.Log("If else close door");

			CloseDoor();
		}
	
	}


	private void OpenDoor () {

		targetPosition = new Vector3(slidingDoor.transform.position.x, slidingDoor.transform.position.y + moveRange, slidingDoor.transform.position.z);
		objectState = ObjectState.Active;
		Debug.Log("Door is opened");
	}

	private void CloseDoor () {
		targetPosition = new Vector3(slidingDoor.transform.position.x, originalPosition.y, slidingDoor.transform.position.z);
		objectState = ObjectState.Off;
		Debug.Log("Door is closed");
	}

}
