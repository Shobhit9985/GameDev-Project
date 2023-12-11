using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
   private void OnCollisionEnter(Collision collision)
    {
        // Destroy the bullet on collision
        Destroy(gameObject);
    }
}
