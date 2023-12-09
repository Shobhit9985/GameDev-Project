using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void LoadScene1()
    {
        SceneManager.LoadScene("Level1"); 
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("Level2"); 
    }

    public void LoadScene3()
    {
        SceneManager.LoadScene("Settings"); 
    }


    public void LoadScene4()
    {
        // Quit the application or stop playing in the editor
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
         Application.Quit();
        #endif
    }
}
