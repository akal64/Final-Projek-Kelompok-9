using UnityEngine;

public class ClawAction : MonoBehaviour
{
	[SerializeField] private Transform rayPoint;
	[SerializeField] private Transform grabPoint;
	[SerializeField] private string layerName;

	private bool isTrash = false;
	private float rayDistance;
	private GameObject pickedGameObject;

	private void Update () {
		
	}

	public void OnPickObject () {

	}


	public void OnDropObject () {

	}

	public void OnThrowObject () {

	}

	public void OnProcessTrash () {

	}
}
