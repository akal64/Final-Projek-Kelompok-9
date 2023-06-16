using System.Collections.Generic;
using UnityEngine;

public enum PuzzleObjectType
{
	Button,
	Lever
}

public class ObjectTrigger : MonoBehaviour
{

	[Header("General Object References")]
	[SerializeField] protected List<ObjectAction> objectActionList = new List<ObjectAction>();

	[Header("General Object Settings")]
	[SerializeField] protected PuzzleObjectType objectType;
	[SerializeField] protected PuzzleObjectState objectState;
	[SerializeField] protected bool isActivated = false;

	private void Start () {
		// TODO PlayerPrefs to save the state of the object

		foreach (ObjectAction objectAction in objectActionList) {
			objectAction.Initialize();
		}

	}
	
	protected void SetObjectActivationStatus(bool isOn) {
		foreach (ObjectAction objectAction in objectActionList) {
			objectAction.SetActive(isOn);
		}
	}
}
