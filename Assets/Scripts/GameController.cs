using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Instrument[] instruments;
    private AudioSource m_AudioSource;
    private int current_melody = 0;
    private Instrument[] currentIntruments;
    private string[] melodies = {
        "Down",
        "EineKliene",
        "Melody 1",
        "Melody 2",
        "Melody 3",
        "Melody 4",
        "Sonata No 16",
        "Up"
    };
    public void playAudio(int melodyID, Instrument instrument)
    {
        m_AudioSource.clip = instrument.audioClips[melodyID];
        m_AudioSource.Play();
    }

    public void ButtonHovered()
    {
        // play audio on delay 
    }
    private void Start()
    {
        //setup buttons with sounds and etc
    }
    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }
}
