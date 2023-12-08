using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotateAndDestroy : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(30, 15, 45); // Rotation speed in degrees per second

    void Update()
    {
        // Calculate the rotation increment based on time
        Vector3 rotationIncrement = rotationSpeed * Time.deltaTime;

        // Apply the rotation increment to the coin
        transform.Rotate(rotationIncrement);
    }

    // This function is called when the player collides with the coin
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Destroy the coin game object
            Destroy(gameObject);
        }
    }
}

