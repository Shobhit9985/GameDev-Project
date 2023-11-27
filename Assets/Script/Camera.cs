using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target; // Assign your player's transform here
    public Vector3 offset = new Vector3(0, 2.0f, -5.0f); // Adjust this for desired camera position
    public float smoothSpeed = 0.125f; // Adjust this for camera movement smoothness

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
