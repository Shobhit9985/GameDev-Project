using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AmbientSound : MonoBehaviour
{
    private float time = 0f;
    System.Random rnd = new System.Random();

    //0-3
    public AudioClip[] sounds;
    private AudioSource audioSource;

    //1-4
    public int loopSound = 1;


    public bool randomSmallSounds = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (randomSmallSounds)
        {
            time += Time.deltaTime;
            if (time >= 8f)
            {
                int track = rnd.Next(0, 5);
                audioSource.clip = sounds[track];
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                time = 0f;
            }
        }
        else
        {
            audioSource.loop = true;
            audioSource.clip = sounds[4 + loopSound];
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

    }
}

