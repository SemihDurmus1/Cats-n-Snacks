using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] bgMusics;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        PlayRandomBGMusic();
    }

    private void PlayRandomBGMusic()
    {
        if (bgMusics != null && bgMusics.Length > 0)
        {
            int randomIndex = Random.Range(0, bgMusics.Length);
            AudioClip selectedMusic = bgMusics[randomIndex];

            audioSource.clip = selectedMusic;
            audioSource.Play();
            audioSource.loop = true;
        }
    }
}
