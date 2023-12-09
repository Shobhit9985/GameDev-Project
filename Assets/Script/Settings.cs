using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public float volume;
    public AudioMixer mixer;

    public void SetVolume(float volume){
        mixer.SetFloat("Volume" , volume);
    }
    
    public void low(){
        QualitySettings.SetQualityLevel(0);
    }
    public void med(){
        QualitySettings.SetQualityLevel(1);
    }
    public void high(){
        QualitySettings.SetQualityLevel(2);
    }

    public void LoadScene1()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
    
}
