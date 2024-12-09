using JetBrains.Annotations;
using System;
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
    private int[] current_melodies = { 0, 0, 0, 0 };
    private int[] currentInstruments;
    public Button defaultSelect;
    public Dictionary<string, int> InstrumentToID { get; private set; } = new Dictionary<string, int>();
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
    public void PlayAudio(Instrument instrument, int melodyID)
    {
        m_AudioSource.clip = instrument.audioClips[melodyID];
        m_AudioSource.Play();
    }
    private void BindInstruments()
    {
        for (int i = 0; i < instruments.Length; i++)
        {
            InstrumentToID.Add(instruments[i].name.ToLower(), i);
        }
    }
    private void Start()
    {
        //set up the dictionary so we can get the id of it from name
        BindInstruments();
        // should be the actual instrument
        correctInstrument = UnityEngine.Random.Range(0, instruments.Length);
        // set the current instruments such that it contains the correct instrument and 3 other random ones that are unique
        currentInstruments = new int[] { -1, -1, -1, -1 };
        int correctIndex = UnityEngine.Random.Range(0, 3);
        for (int i = 0; i < 4; i++)
        {
            if (i == correctIndex)
            {
                currentInstruments[i] = correctInstrument;
            }
            else
            {
                int randominstrument = UnityEngine.Random.Range(0, instruments.Length);
                // check that the selected instrument is not the correct instrument or a duplicate (by checking if the array contain)
                while (randominstrument == correctInstrument || currentInstruments.ToList().FindAll(i => i == randominstrument).Count != 0)
                {
                    randominstrument = UnityEngine.Random.Range(0, instruments.Length);
                }
                currentInstruments[i] = randominstrument;
            }
            
        }
        //defaults to random melodies
        for (int i = 0; i < current_melodies.Length; i++)
        {
            current_melodies[i] = UnityEngine.Random.Range(0, melodies.Length);
        }
    }

    public void PlayWithDifficulty(Difficulty difficulty)
    {
        if (difficulty.isDifferentMelodies) {
            // all melodies are different
            for (int i = 0; i < current_melodies.Length; i++)
            {
                current_melodies[i] = UnityEngine.Random.Range(0, melodies.Length);
            }
        } else
        {
            // all melodies are same
            int sameMelody = UnityEngine.Random.Range(0, melodies.Length);
            for (int i = 0; i < current_melodies.Length; i++)
            {
                current_melodies[i] = sameMelody;
            }
        }
        List<string> DiffInstruments = difficulty.instruments.ToList<string>();
        //set instruments
        for (int i = 0; i < currentInstruments.Length; i++) {
            //sets each instrument to a random instrument in the list
            int randomID = UnityEngine.Random.Range(0, DiffInstruments.Count);
            currentInstruments[i] = InstrumentToID[DiffInstruments[randomID].ToLower()];
            // remove it from the list
            DiffInstruments.Remove(DiffInstruments[randomID]);
        }

    }

    public void setCorrectInstrument (int instrumentID)
    {
        correctInstrument = instrumentID;
        // set the current instruments such that it contains the correct instrument and 3 other random ones that are unique
        currentInstruments = new int[] { -1, -1, -1, -1 };
        int correctIndex = UnityEngine.Random.Range(0, 3);
        for (int i = 0; i < 4; i++)
        {
            if (i == correctIndex)
            {
                currentInstruments[i] = correctInstrument;
            }
            else
            {
                int randominstrument = UnityEngine.Random.Range(0, instruments.Length);
                // check that the selected instrument is not the correct instrument or a duplicate (by checking if the array contain)
                while (randominstrument == correctInstrument || currentInstruments.ToList().FindAll(i => i == randominstrument).Count != 0)
                {
                    randominstrument = UnityEngine.Random.Range(0, instruments.Length);
                }
                currentInstruments[i] = randominstrument;
            }

        }

        //defaults to random melodies
        for (int i = 0; i < current_melodies.Length; i++)
        {
            current_melodies[i] = UnityEngine.Random.Range(0, melodies.Length);
        }
    }
    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    public void Replay()
    {
        PlayAudio(instruments[correctInstrument], current_melodies[correctInstrument]);
    }
    public void ButtonClicked(int id)
    {
        selectedInstrument = currentInstruments[id];
        // play corresponding instrument
        PlayAudio(instruments[currentInstruments[id]], current_melodies[id]);
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
        defaultSelect.Select();
    }
}
