using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public Instrument[] instruments;
    private AudioSource m_AudioSource;
    private int currentInstrument;
    private int current_melody = 0;
    public GameObject[] selectableIntruments;
    private int[] currentInstruments;
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
    public void playAudio(Instrument instrument)
    {
        m_AudioSource.clip = instrument.audioClips[current_melody];
        m_AudioSource.Play();
    }
    private void Start()
    {
        // should be the actual instrument
        currentInstrument = 0;
        // randomly selected?
        current_melody = 0;
        // set what instruments are used by index
        currentInstruments = new int[]{0,1,2,3};
    }
    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    public void InstrumentSelected(int id)
    {
        playAudio(instruments[id]);
    }

    public void Replay()
    {
        playAudio(instruments[currentInstrument]);
    }
    public void ButtonClicked(int id)
    {
        // play corresponding instrument
        playAudio(instruments[currentInstruments[id]]);
        // open prompt to confirm choice?
    }
}
