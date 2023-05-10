using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    public float maxDistance = 5f;
    public float minY = -55f;
    public float maxY = 54f;
    
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPos = target.position;
            Vector3 cameraPos = transform.position;
            float distanceX = Mathf.Abs(targetPos.x - cameraPos.x);
            float distanceY = Mathf.Abs(targetPos.y - cameraPos.y);
            
            if (distanceX > maxDistance || distanceY > maxDistance)
            {
                Vector3 desiredPos = new Vector3(targetPos.x, targetPos.y, cameraPos.z);
                desiredPos.x = 0f; // x position always 0
                desiredPos.y = Mathf.Clamp(desiredPos.y, minY, maxY); // limit y position
                transform.position = Vector3.SmoothDamp(cameraPos, desiredPos, ref velocity, smoothTime);
            }
        }
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(maxDistance * 2, maxDistance * 2, 0));
    }

}
