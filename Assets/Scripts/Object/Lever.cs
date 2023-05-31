using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    private GameObject leverHandle;

    private float leverHandleRotation;

    private void Awake() {
        leverHandle = transform.Find("Lever Handle").gameObject;
    }

    private void Update() {
        leverRotationHandler();
    }

    private void leverRotationHandler() {
        leverHandleRotation = Mathf.Clamp(leverHandleRotation, -40f, 40f);
        leverHandle.transform.eulerAngles = new Vector3(0f, 0f, leverHandleRotation);
    }
}
