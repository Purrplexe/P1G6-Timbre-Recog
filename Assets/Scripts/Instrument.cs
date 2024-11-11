using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Instrument : MonoBehaviour
{
    // the audio files for the melodies
    public  List<AudioClip> audioClips;

    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayAudio(int id)
    {
        audioSource.clip = audioClips[id];
        audioSource.Play();
    }
}
