using UnityEngine;

public enum ObjectState
{
	Off,
	Active
}


public class ObjectAction : MonoBehaviour
{

	[Header("Object Status")]
	[SerializeField] protected ObjectState objectState;
	[SerializeField] protected bool isShouldActive = false;

	private void Start () {
		Initialize();
	}

	public virtual void Initialize () {
		objectState = ObjectState.Off;
	}

	private void Update () {

        if (objectState == ObjectState.Active  && !isShouldActive)
        {
			objectState = ObjectState.Off;
			ShutDownDoor();

		} else if (objectState == ObjectState.Off && isShouldActive) {

			objectState = ObjectState.Active;
			ActivateDoor();

		}

    }

	public void SetActive(bool isActive) {
		this.isShouldActive = isActive;
	}

	protected virtual void ActivateDoor () {

	}

	protected virtual void ShutDownDoor () {

	}

}
