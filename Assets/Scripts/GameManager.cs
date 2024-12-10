using Cinemachine;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using static System.TimeZoneInfo;

public class GameManager : MonoBehaviour
{
    [Header("UI objects")]

    // [SerializeField] private TMPro.TextMeshProUGUI timeText;
    // [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    public GameObject background;
    public GameObject button1;
    public GameObject buttonReturn;
    // int denoting how hard it is
    public int difficultyLevel;
    public GameObject cameraMain;
    public GameObject confirmationPrompt;
    public Difficulty[] Difficulties;
    private PlayScene currentScene;
    public Selectable defaultSelect;
    public GameObject hubCam;
    public bool transitioned = false;
    public float timerForTransition;
    private string selectedInstrument;
    //For later
    public GameObject[] turnOffs;


    public GameObject gameUI;
    public GameController gameController;

    [Header("scenes")]
    public PlayScene[] scenes;

    public void Canner()
    {
        background.SetActive(false);
        button1.SetActive(false);
        defaultSelect.Select();
        //button2.SetActive(true);
    }
    public void PlayWithDifficulty()
    {
        //run this to get camera and ui to show
        PlayInstrument();
        // set the difficulty scenario
        SetDifficulty();
    }
    private List<Difficulty> GetValidDifficulties()
    {
        //find what difficulties are valid
        List<Difficulty> validDifficulties = new List<Difficulty>();
        foreach (Difficulty df in Difficulties)
        {
            // if the difficulties instrument is the instrument
            if (df.instruments[0].ToLower() == selectedInstrument)
            {
                //if the difficulty is less than the allowed difficulty
                if (df.difficulty <= difficultyLevel)
                {
                    validDifficulties.Add(df);
                }
            }
        }
        return validDifficulties;
    }
    private void SetDifficulty()
    {
        List<Difficulty> validDifficulties = GetValidDifficulties();
        //select a random valid difficulty to play with
        gameController.PlayWithDifficulty(validDifficulties[UnityEngine.Random.Range(0,validDifficulties.Count)]);
    }
    private int GetSceneIndex(string instrument)
    {
        for (int i = 0; i < scenes.Length; i++)
        {
            if (scenes[i].instrument.ToLower() == instrument)
            {
                return i;
            }
        }
        throw new KeyNotFoundException("scene not added (or name is wrong)");
    }
    public void SelectInstrument(string instrument)
    {
        instrument = instrument.ToLower();
        currentScene = scenes[GetSceneIndex(instrument)];
        selectedInstrument = instrument;
        SwitchToCam(currentScene.selectCamera);
        //get second childs text which is the play button
        confirmationPrompt.GetComponentsInChildren<TMP_Text>()[1].text = "Play the " + instrument + "!";
        confirmationPrompt.SetActive(true);
        //Select the play button
        confirmationPrompt.GetComponentsInChildren<Selectable>()
            .Last()
            .Select();
        //set the slider to be the amount of valid difficulties
        confirmationPrompt.GetComponentInChildren<Slider>().maxValue = GetValidDifficulties().Count;
    }
    public void PlayInstrument()
    {
        gameController.setCorrectInstrument(gameController.InstrumentToID[selectedInstrument]);
        confirmationPrompt.SetActive(false) ;
        SwitchToCam(currentScene.gameCamera);
        gameUI.SetActive(true);
        gameUI.GetComponentInChildren<Button>().Select();
    }


    public void ReturnToHub()
    {
        defaultSelect.Select();
        confirmationPrompt.SetActive(false);
        gameUI.SetActive(false);
        SwitchToCam(hubCam);
        Debug.Log("returned and falsed");
        //transitionScreen.SetActive(false);
    }
    private void SwitchToCam(GameObject camera)
    {
        DisableCams();
        camera.SetActive(true);
    }
    private void DisableCams()
    {
        foreach (CinemachineVirtualCamera camera in Resources.FindObjectsOfTypeAll<CinemachineVirtualCamera>()) {
            camera.gameObject.SetActive(false);
        }
    }
}