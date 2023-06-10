using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
	Button,
	Lever
}

public class ObjectTrigger : MonoBehaviour
{
	[SerializeField] protected List<ObjectAction> objectActionList = new List<ObjectAction>();

	[Header("Object Status")]
	[SerializeField] protected ObjectType objectType;
	[SerializeField] protected ObjectState objectState;
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
