using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{

    public void LoadScene1()
    {
        SceneManager.LoadScene("Settings"); 
    }


    public void LoadScene2()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
