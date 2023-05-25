using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Transform target;  // Objek yang ingin diikuti kamera
    public float smoothSpeed = 0.5f;  // Kecepatan pergerakan kamera
    public Vector2 offset;  // Offset antara kamera dan objek diikuti

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector2 currentposition = new Vector2 (transform.position.x, transform.position.y);
            currentposition.x = 0;
            // Tentukan posisi target
            Vector2 targetPosition = target.position;

            // Interpolasi posisi kamera untuk menghasilkan pergerakan yang lebih halus
            Vector2 smoothedPosition = Vector2.Lerp(currentposition, targetPosition, smoothSpeed * Time.deltaTime);

            // Atur posisi kamera ke posisi yang diinterpolasi
            transform.position = smoothedPosition;
            Debug.Log(transform.position);
        }
    }

}
