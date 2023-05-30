using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followObjectUI : MonoBehaviour
{
    public Transform targetObject;

    void Update() {
        if (targetObject != null) {
            Vector3 targetPosition = targetObject.transform.position;
            Vector3 screenPosition = Camera.main.WorldToViewportPoint(targetPosition);
            transform.position = screenPosition;
        }
    }
}
