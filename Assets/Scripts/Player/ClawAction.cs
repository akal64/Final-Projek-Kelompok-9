using UnityEngine;

public class ClawAction : MonoBehaviour
{
	[SerializeField] private Transform rayPoint;
	[SerializeField] private Transform grabPoint;
	[SerializeField] private string layerName;
	[SerializeField] private string trashTag;
	[SerializeField] private float throwForce;

	private int layerIndex;
	private bool isTrash = false;
	private bool isPickable = false;
	private bool isInteractable = false;
	private float rayDistance;
	private GameObject pickedGameObject;
	private RaycastHit2D hitInfo;

	private FloatingObject floatingObject;

	public void Initialize () {
		layerIndex = LayerMask.NameToLayer(layerName);
	}

	private void Update () {
		hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);

		if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex) {
			isPickable = true;
		} else {
			isPickable = false;
		}

		if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("Interactable")) {
			isInteractable = true;
		} else {
			isInteractable = false;
		}

	}

	public void OnInteract () {
		if (hitInfo.collider != null && isInteractable) {

			Lever lever = hitInfo.collider.gameObject.GetComponent<Lever>();

			if(lever != null) {
				lever.OnInteract();
			}

		}
	}

	public void OnPickObject () {
		if (isPickable && pickedGameObject == null) {
			pickedGameObject = hitInfo.collider.gameObject;

			floatingObject = pickedGameObject.GetComponent<FloatingObject>();
			floatingObject.SetStateBeingCarried();

			pickedGameObject.transform.position = grabPoint.position;
			pickedGameObject.transform.SetParent(transform);
			
			CheckIfTrash();
		}
	}


	public void OnDropObject () {

		if (pickedGameObject != null) {

			floatingObject.SetStateIdle();

			pickedGameObject.transform.SetParent(null);
			pickedGameObject = null;
			
			CheckIfTrash();
			ClearFloatingObjectRef();
		}
	}

	public void OnThrowObject () {

		if (pickedGameObject != null) {

			floatingObject.SetStateBeingThrown();
			floatingObject.SetVelocity(transform.right * throwForce);
			pickedGameObject.transform.SetParent(null);
			pickedGameObject = null;

			CheckIfTrash();
			ClearFloatingObjectRef();
		}
	}

	public void OnProcessTrash () {

		if (isTrash) {
			Debug.Log("Process Trash");
		}

	}

	private void CheckIfTrash () {

		if (pickedGameObject != null && pickedGameObject.CompareTag(trashTag)) {
			isTrash = true;
		} else {
			isTrash = false;
		}

	}

	private void ClearFloatingObjectRef () {
		floatingObject = null;
	}
}
