using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Specify the name of the next level
    public string nextLevelName = "Level2";

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Load the next level
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
