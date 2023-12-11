using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip[] sounds;
    private AudioSource audioSource;

    //1-4. 1 jungle ambient, 2 inside ambient,3 tense, 4 triumphant
    public int songNum = 1;
    bool outside = true;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sounds[songNum - 1];

        audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            if (outside)
            {
                audioSource.clip = sounds[0];
            }
            else
            {
                audioSource.clip = sounds[1];
            }
            audioSource.loop = true;
            audioSource.Play();
        }
    }
    public void PlayOutsideAmbient()
    {
        if (audioSource.clip.name != sounds[0].name)
        {
            audioSource.loop = true;
            audioSource.clip = sounds[0];
            audioSource.Play();
        }
    }
    public void PlayInsideAmbient()
    {
        if (audioSource.clip.name != sounds[1].name)
        {
            audioSource.loop = true;
            audioSource.clip = sounds[1];
            audioSource.Play();
        }
    }
    public void PlayTense()
    {

        if (audioSource.clip.name != sounds[2].name)
        {
            audioSource.loop = true;
            audioSource.clip = sounds[2];
            audioSource.Play();
        }


    }

    public void PlayTriumphant(bool outside)
    {
        if (audioSource.clip == sounds[0])
        {
            outside = true;
        }
        else
        {
            outside = false;
        }
        audioSource.loop = false;
        audioSource.clip = sounds[3];
        audioSource.Play();
    }
    public void StopMusic()
    {
        audioSource.Stop();
    }
}
