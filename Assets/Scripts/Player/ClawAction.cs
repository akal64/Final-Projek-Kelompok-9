using UnityEngine;

public class ClawAction : MonoBehaviour
{

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
	private bool isUIInteractShown = false;

	// Unity Components References
	private Collider2D collision;
	private RaycastHit2D hitInfo;

	// Scripts and Objects References
	private FloatingObject floatingObject;
	[SerializeField] private GameObject pickedGameObject;

	// Events
	public System.Action RadiationProtectionPicked;

	public System.Action ShowInteractUI;
	public System.Action ShowPickUI;
	public System.Action<bool> ShowTrashObjectActionUI;
	public System.Action ResetClawUI;


	public bool IsTrash { get { return isTrash; } }

	public GameObject PickedGameObject { get { return pickedGameObject; } }



	public void Initialize () {
		layerIndex = LayerMask.NameToLayer(layerName);
		SetClawColliderContainer(false);
		pickedGameObject = null;
	}

	private void Update () {

		hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, 10);

		if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex) {
			isPickable = true;

			if (pickedGameObject is null) {
				InvokePickUI();
			}

		} else {
			isPickable = false;
			if (pickedGameObject is null) {
				ResetClawUI?.Invoke();
			}
		}

	}

	private void InvokePickUI () {
		if (isPickable) {
			ShowPickUI?.Invoke();
		}
	}

	private void OnTriggerEnter2D (Collider2D collision) {
		if (collision.CompareTag("RadiationProtection")) {
			RadiationProtectionPicked?.Invoke();
			ShowPickUI?.Invoke();
		}
		
		CheckIfLever(collision);

	}

	private void OnTriggerStay2D (Collider2D collision) {

		if (collision.CompareTag("Lever") && !isUIInteractShown) {
			CheckIfLever(collision);
		}

	}

	private void OnTriggerExit2D (Collider2D collision) {
		if (isLever) {
			ResetClawUI?.Invoke();
		}

		isLever = false;
		isUIInteractShown = false;
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
			pickedGameObject = null;

		}

    }

	private void CheckIfLever (Collider2D collision) {
		if (collision.CompareTag("Lever")) {
			if (!isUIInteractShown) {
				ShowInteractUI?.Invoke();
				isUIInteractShown = true;
				Debug.Log("Kene");
			}
			isLever = true;
			this.collision = collision;
		}
	}

	private void CheckIfTrash () {

		if (pickedGameObject != null && pickedGameObject.CompareTag(trashTag)) {
			isPickable = true;
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

}
