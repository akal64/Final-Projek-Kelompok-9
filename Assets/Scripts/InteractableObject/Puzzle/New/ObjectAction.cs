using UnityEngine;

public enum PuzzleObjectState
{
	Off,
	Active
}

public class ObjectAction : MonoBehaviour
{

	[Header("General Object Settings")]
	[SerializeField] protected PuzzleObjectState objectState;
	[SerializeField] protected bool isShouldActive = false;

	private void Start () {
		Initialize();
	}

	public virtual void Initialize () {
		objectState = PuzzleObjectState.Off;
	}

	private void Update () {

        if (objectState == PuzzleObjectState.Active  && !isShouldActive)
        {
			objectState = PuzzleObjectState.Off;

		} else if (objectState == PuzzleObjectState.Off && isShouldActive) {

			objectState = PuzzleObjectState.Active;

		}

    }

	public void SetActive(bool isActive) {
		this.isShouldActive = isActive;
	}

}
