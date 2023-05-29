using UnityEngine;

public class ClawMovement : MonoBehaviour
{
	private Vector2 clawDirection;
	private Vector2 cursorPosition;
	private Vector2 scale;
	private bool isMove = false;
	private void Update () {
		
	}

	public void ReferenceCursorPosition (Vector2 cursorPosition) {
		this.cursorPosition = cursorPosition;
	}

	public void SetClawMoveActiveStatus (bool value) {
		isMove = value;
	}

	private void SetClawFacingDirection(Vector2 clawDirection) {
		if (clawDirection.x < 0) {
			scale.y = -1;

		} else if (clawDirection.x > 0) {
			scale.y = 1;
		}
	}

}
