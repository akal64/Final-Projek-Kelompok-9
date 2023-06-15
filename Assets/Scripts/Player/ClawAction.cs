using UnityEngine;

public class ClawAction : MonoBehaviour
{

	public System.Action ShowInteractUI;
	public System.Action ShowPickUI;
	public System.Action<bool> ShowTrashObjectActionUI;
	public System.Action ResetClawUI;

	// Inspector Variables

	[Header("References")]
	[SerializeField] private GameObject colliderPickUp;

	[Header("Raycast Settings")]
	[SerializeField] private Transform rayPoint;
	[SerializeField] private Transform grabPoint;

	[Header("Script Settings")]
	[SerializeField] private string layerName;
	[SerializeField] private string trashTag;
	[SerializeField] private float throwForce;

	// Private Variables
	private int layerIndex;
	private bool isTrash = false;
	private bool isPickable = false;
	private bool isLever = false;

	// Unity Components References
	private Collider2D collision;
	private RaycastHit2D hitInfo;

	// Scripts and Objects References
	private FloatingObject floatingObject;
	private GameObject pickedGameObject;

	// Events
	public System.Action RadiationProtectionPicked;

	public void Initialize () {
		layerIndex = LayerMask.NameToLayer(layerName);
		SetClawColliderContainer(false);
	}

	private void Update () {

		hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, 10);

		if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex) {
			isPickable = true;
			ShowPickUI?.Invoke();

		} else {
			isPickable = false;
		}

	}

	private void OnTriggerEnter2D (Collider2D collision) {
		if (collision.CompareTag("RadiationProtection")) {
			RadiationProtectionPicked?.Invoke();
		}
		
		CheckIfLever(collision);

	}

	private void OnTriggerStay2D (Collider2D collision) {
		
		CheckIfLever(collision);
		ResetClawUI?.Invoke();

	}

	private void OnTriggerExit2D (Collider2D collision) {
		isLever = false;
		this.collision = null;
	}

	public void OnInteract () {

		if (isLever) {

			LeverTrigger lever = collision.gameObject.GetComponent<LeverTrigger>();

			if(lever != null) {
				lever.OnInteract();
			}

		}
	}

	public void OnPickObject () {
		if (isPickable && pickedGameObject == null) {
			pickedGameObject = hitInfo.collider.gameObject;

			floatingObject = pickedGameObject.GetComponent<FloatingObject>();

			floatingObject.SetFloatingObjectState(FloatingObjectState.BeingCarried);

			pickedGameObject.transform.position = grabPoint.position;
			pickedGameObject.transform.SetParent(transform);
			

			CheckIfTrash();
			SetClawColliderContainer(true);

		}
	}


	public void OnDropObject () {

		if (pickedGameObject != null) {
			SetClawColliderContainer(false);

			floatingObject.SetFloatingObjectState(FloatingObjectState.BeingDropped);

			DetachFromClaw();		
			CheckIfTrash();
			ClearFloatingObjectRef();

			ResetClawUI?.Invoke();
		}
	}

	public void OnThrowObject () {

		if (pickedGameObject != null) {

			SetClawColliderContainer(false);

			floatingObject.SetFloatingObjectState(FloatingObjectState.BeingThrown);

			floatingObject.SetVelocity(transform.right * throwForce);

			DetachFromClaw();
			CheckIfTrash();
			ClearFloatingObjectRef();

			ResetClawUI?.Invoke();
		}
	}

	public void OnProcessTrash () {

        if (isTrash && pickedGameObject != null) {

			SetClawColliderContainer(false);

			GameManager.instance.OnProcessTrash();
            Destroy(pickedGameObject);

			ResetClawUI?.Invoke();
		}

    }

	private void CheckIfLever (Collider2D collision) {
		if (collision.CompareTag("Lever")) {
			isLever = true;
			this.collision = collision;

			ShowInteractUI?.Invoke();
		}
	}

	private void CheckIfTrash () {

		if (pickedGameObject != null && pickedGameObject.CompareTag(trashTag)) {
			isTrash = true;
			ShowTrashObjectActionUI?.Invoke(true);

		} else {
			isTrash = false;
			ShowTrashObjectActionUI?.Invoke(false);
		}

	}

	private void DetachFromClaw () {
		pickedGameObject.transform.SetParent(null);
		pickedGameObject = null;
	}

	private void ClearFloatingObjectRef () {
		floatingObject = null;
	}

	private void SetClawColliderContainer(bool value) {
		colliderPickUp.gameObject.SetActive(value);
	}

	public bool IsTrash { get { return isTrash; } }

    public GameObject PickedGameObject { get { return pickedGameObject; } }
}
