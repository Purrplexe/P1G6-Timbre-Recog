using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Instrument[] instruments;
    private AudioSource m_AudioSource;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }
}
