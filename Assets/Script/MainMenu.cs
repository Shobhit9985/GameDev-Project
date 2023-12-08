using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Button StartButton;

    void Start()
    {
        StartButton.onClick.AddListener(ClickedStartButton);
    }

    void ClickedStartButton()
    {
        SceneManager.LoadScene(0);
    }
}
