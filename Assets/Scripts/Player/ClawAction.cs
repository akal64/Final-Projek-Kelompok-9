using UnityEngine;

public class ClawAction : MonoBehaviour
{
	[SerializeField] private Transform rayPoint;
	[SerializeField] private Transform grabPoint;
	[SerializeField] private string layerName;
	[SerializeField] private string trashTag;

	private int layerIndex;
	private bool isTrash = false;
	private bool isPickable = false;
	private float rayDistance;
	private GameObject pickedGameObject;
	private RaycastHit2D hitInfo;

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

		Debug.DrawRay(rayPoint.position, transform.right * rayDistance, Color.red);
	}

	public void OnPickObject () {
		if (isPickable && pickedGameObject == null) {
			pickedGameObject = hitInfo.collider.gameObject;
			pickedGameObject.GetComponent<Rigidbody2D>().isKinematic = true;	
			pickedGameObject.transform.position = grabPoint.position;
			pickedGameObject.transform.SetParent(transform);
			
			CheckIfTrash();
		}
	}


	public void OnDropObject () {
		if (pickedGameObject != null) {
			pickedGameObject.GetComponent<Rigidbody2D>().isKinematic = false;
			pickedGameObject.transform.SetParent(null);
			pickedGameObject = null;
			
			CheckIfTrash();
		}
	}

	public void OnThrowObject () {
		Debug.Log("Throw Object");
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
}
