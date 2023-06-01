using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
	[SerializeField] private GameObject slidingDoor;
	[SerializeField] private float moveRange = 2f;
	[SerializeField] private float moveSpeed = 1f;
	[SerializeField] private bool isDoorOpen = false;
	[SerializeField] private bool openDoor = false;
	private Vector3 targetPosition;

	public void Initialize () {
		targetPosition = slidingDoor.transform.position;
	}

	private void Update () {
		if (openDoor && !isDoorOpen) {
			OpenDoor();
		} else if (!openDoor && isDoorOpen) {
			CloseDoor();
		}

		slidingDoor.transform.position = Vector3.MoveTowards(slidingDoor.transform.position, targetPosition, moveSpeed * Time.deltaTime);
	}

	public void SetDoorOpen (bool open) {
		openDoor = open;
	}

	private void OpenDoor () {
		targetPosition = new Vector3(slidingDoor.transform.position.x, slidingDoor.transform.position.y + moveRange, slidingDoor.transform.position.z);
		isDoorOpen = true;
	}

	private void CloseDoor () {
		targetPosition = new Vector3(slidingDoor.transform.position.x, slidingDoor.transform.position.y + (moveRange * -1), slidingDoor.transform.position.z);
		isDoorOpen = false;
	}
}
