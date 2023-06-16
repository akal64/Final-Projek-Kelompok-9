using UnityEngine;

public enum FloatingObjectState
{
	Idle,
	BeingCarried,
	BeingThrown,
	BeingDropped
}

public class FloatingObject : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private Rigidbody2D objectRigidbody2D;

	[Header("Object Settings")]
	[SerializeField]
	[Tooltip("If true, at this time this object is using and affected by Physic Engine gravity")]
	private bool isOnUsingGravity = false;

	[SerializeField]
	[Tooltip("If true, this object is originally affected by Gravity (This is the main behaviour for this object)")]
	private bool isGravityObject = false;

	[SerializeField] private FloatingObjectState objectState;

	private BoxCollider2D objectCollider;
	private Vector2 originalObjectCollider;

	private void Start () {
		objectState = FloatingObjectState.Idle;
        objectCollider = GetComponent<BoxCollider2D>();
		originalObjectCollider = objectCollider.size;
	}

	private void FixedUpdate () {

		bool isIdle = objectState == FloatingObjectState.Idle;
		bool isCarried = objectState == FloatingObjectState.BeingCarried;

		if (!isCarried && !isIdle &&  objectRigidbody2D.velocity == Vector2.zero) {
			objectState = FloatingObjectState.Idle;
		}

		switch (objectState) {
			case FloatingObjectState.Idle:

				SetStateIdle();

			break;

			case FloatingObjectState.BeingCarried:

				SetStateBeingCarried();

			break;

			case FloatingObjectState.BeingThrown:

				SetStateBeingThrown();

			break;

			case FloatingObjectState.BeingDropped:

				SetStateBeingDropped();

			break;
		}
	}

	public void SetVelocity (Vector2 value) {
		objectRigidbody2D.velocity = value;
	}

	public void SetFloatingObjectState (FloatingObjectState objectState) {
		this.objectState = objectState;
	}

	private void SetStateIdle () {

		if (objectState == FloatingObjectState.Idle && !isGravityObject && isOnUsingGravity) {

			isOnUsingGravity = false;
			SetKinematic(true);

		} else if (objectState == FloatingObjectState.Idle && isGravityObject && !isOnUsingGravity) {

			isOnUsingGravity = true;
			SetKinematic(false);

		}
		AdjustColliderToSmall(false);
	}

	private void SetStateBeingCarried () {
		SetKinematic(true);
		isOnUsingGravity = false;
		AdjustColliderToSmall(true);
	}

	private void SetStateBeingThrown () {
		SetKinematic(false);
		isOnUsingGravity = true;
		AdjustColliderToSmall(false);
	}

	private void SetStateBeingDropped () {
		if (isGravityObject) {
			
			SetKinematic(true);

        } else {
			
			SetKinematic(false);

        }
        AdjustColliderToSmall(false);
    }

	private void SetKinematic (bool value) {
		objectRigidbody2D.isKinematic = value;
	}

	private void AdjustColliderToSmall(bool value) {
		if (value)
            objectCollider.size = new Vector2(0.5f, 0.5f);
        else
			objectCollider.size = originalObjectCollider;
    }

}

