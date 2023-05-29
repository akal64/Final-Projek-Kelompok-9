using UnityEngine;

public class ClawMovement : MonoBehaviour
{
	[SerializeField] private GameObject rotatorPoint;
	private Vector3 mouseWorldPosition;

	private void Update () {
		RotateModuleTowardsMouse();
	}

	public void ReferenceCursorPosition (Vector2 cursorPosition) {
		this.mouseWorldPosition = cursorPosition;
	}

	public void SetRotatorPoint(GameObject rotatorPoint) {
		this.rotatorPoint = rotatorPoint;
	}

	private void RotateModuleTowardsMouse () {

		Vector3 modulePosition = rotatorPoint.transform.position;
		modulePosition.z = 0;

		Vector3 direction = mouseWorldPosition - modulePosition;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

		rotatorPoint.transform.rotation = Quaternion.Euler(0, 0, angle);

		Vector3 scale = rotatorPoint.transform.localScale;
		scale.y = Mathf.Sign(direction.x);
		rotatorPoint.transform.localScale = scale;
	}

}
