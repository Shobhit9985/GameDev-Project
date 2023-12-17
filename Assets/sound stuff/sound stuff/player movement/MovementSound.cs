using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSound : MonoBehaviour
{
    //0 = running on ground, 1 = running through water
    //2 = jump, 3 = jump land
    public AudioClip[] sounds;
    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRunGround()
    {
        audioSource.clip = sounds[0];
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

    }

    public void PlayRunWater()
    {
        audioSource.clip = sounds[1];
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void PlayJump()
    {
        
        audioSource.Stop();
        audioSource.clip = sounds[2];

        audioSource.Play();

    }
    public void PlayJumpLand()
    {
        
        audioSource.Stop();
        audioSource.clip = sounds[3];

        audioSource.Play();

    }
    public void StopAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

    }
    
}
