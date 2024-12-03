using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Instrument[] instruments;
    private AudioSource m_AudioSource;
    public GameObject confirmationPrompt;
    public int selectedInstrument;
    private int correctInstrument;
    private int current_melody = 0;
    private int[] currentInstruments;
    public Button replayButton;
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
    public void PlayAudio(Instrument instrument)
    {
        m_AudioSource.clip = instrument.audioClips[current_melody];
        m_AudioSource.Play();
    }
    private void Start()
    {
        // should be the actual instrument
        correctInstrument = Random.Range(0, instruments.Length);
        // set the current instruments such that it contains the correct instrument and 3 other random ones that are unique
        currentInstruments = new int[] { -1, -1, -1, -1 };
        int correctIndex = Random.Range(0, 3);
        for (int i = 0; i < 4; i++)
        {
            if (i == correctIndex)
            {
                currentInstruments[i] = correctInstrument;
            }
            else
            {
                int randominstrument = Random.Range(0, instruments.Length);
                // check that the selected instrument is not the correct instrument or a duplicate (by checking if the array contain)
                while (randominstrument == correctInstrument || currentInstruments.ToList().FindAll(i => i == randominstrument).Count != 0)
                {
                    randominstrument = Random.Range(0, instruments.Length);
                }
                currentInstruments[i] = randominstrument;
            }
            
        }
        
        current_melody = Random.Range(0,melodies.Length);
    }

    public void setCorrectInstrument (int instrumentID)
    {
        correctInstrument = instrumentID;
        // set the current instruments such that it contains the correct instrument and 3 other random ones that are unique
        currentInstruments = new int[] { -1, -1, -1, -1 };
        int correctIndex = Random.Range(0, 3);
        for (int i = 0; i < 4; i++)
        {
            if (i == correctIndex)
            {
                currentInstruments[i] = correctInstrument;
            }
            else
            {
                int randominstrument = Random.Range(0, instruments.Length);
                // check that the selected instrument is not the correct instrument or a duplicate (by checking if the array contain)
                while (randominstrument == correctInstrument || currentInstruments.ToList().FindAll(i => i == randominstrument).Count != 0)
                {
                    randominstrument = Random.Range(0, instruments.Length);
                }
                currentInstruments[i] = randominstrument;
            }

        }

        current_melody = Random.Range(0, melodies.Length);
    }
    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    public void Replay()
    {
        PlayAudio(instruments[correctInstrument]);
    }
    public void ButtonClicked(int id)
    {
        selectedInstrument = currentInstruments[id];
        // play corresponding instrument
        PlayAudio(instruments[currentInstruments[id]]);
        // open prompt to confirm choice
        confirmationPrompt.SetActive(true);
        confirmationPrompt.GetComponentInChildren<Button>().Select();
    }
    public void OnConfirm()
    {
        confirmationPrompt.SetActive(false);
        //if choice was correct
        if (selectedInstrument == correctInstrument)
        {
            Debug.Log("Confirm");
        }
        SelectReplay();
    }
    public void OnDeny()
    {
        confirmationPrompt.SetActive(false);
        SelectReplay();
    }
    public void SelectReplay()
    {
        replayButton.Select();
    }
}
