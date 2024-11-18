using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Instrument : MonoBehaviour
{
    // the audio files for the melodies
    public  List<AudioClip> audioClips;
    public string instrumentName;
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
