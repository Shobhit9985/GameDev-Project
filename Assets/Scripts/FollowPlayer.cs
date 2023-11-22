using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;  // Reference to the player's transform.
    public Vector3 offset = new Vector3(0, 10, -10);  // Camera offset (Y = height, Z = distance behind).
    
    void Update()
    {
        if (target == null)
            return;  // Return early if the target is not assigned.

        // Calculate the camera's new position based on the target's position and offset.
        Vector3 targetPosition = target.position + offset;
        
        // Set the camera's position.
        transform.position = targetPosition;
        
        // Rotate the camera to look at the player.
        transform.LookAt(target);
    }
}
