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
    public GameObject cameraMain;
    public GameObject confirmationPrompt;
    private PlayScene currentScene;
    public Selectable defaultSelect;
    public GameObject hubCam;
    public bool transitioned = false;
    public float timerForTransition;
    private string selectedInstrument;
    public GameObject startCam;
    //For later
    public GameObject[] turnOffs;
    private Dictionary<string, int> instrumentToID = new Dictionary<string, int>();

    public MaterialChanger guitarMatChanger;
    public MaterialChanger pianoPart1;
    public MaterialChanger pianoPart2;
    public MaterialChanger pianoPart3;
    public MaterialChanger pianoPart4;
    public GameObject pianoComponentTurnOffs;
    public GameObject gameUI;
    public GameController gameController;

    [Header("scenes")]
    public PlayScene[] scenes;

    private void Awake()
    {
        BindInstruments();
        startCam.SetActive(true);
        hubCam.SetActive(false);
        guitarMatChanger.guitarUnlock = true;
        pianoPart1.pianoUnlock = false;

        //guitarMatChanger.isBeat = true;
        
    }
    public void Update()
    {
        //LockingOfPiano();
    }
    public void BindInstruments()
    {
        for (int i = 0; i < gameController.instruments.Length; i++)
        {
            instrumentToID.Add(gameController.instruments[i].name.ToLower(), i);
        }
    }
    public void StartMenuTransition()
    {
        background.SetActive(false);
        button1.SetActive(false);
        defaultSelect.Select();
        startCam.SetActive(false);
        hubCam.SetActive(true);
        //button2.SetActive(true);
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
        
    }
    public void PlayInstrument()
    {/*
        if (guitarMatChanger.guitarUnlock == false || pianoPart1.pianoUnlock == false /*|| GetComponent<MaterialChanger>().drumsUnlock == false)
        {
            Debug.Log("Not unlocked");
           
            
        }*/
       // else if (guitarMatChanger.guitarUnlock == true || pianoPart1.pianoUnlock == true /*|| GetComponent<MaterialChanger>().drumsUnlock == true*/)
        //{
            gameController.setCorrectInstrument(instrumentToID[selectedInstrument]);
            confirmationPrompt.SetActive(false);
            SwitchToCam(currentScene.gameCamera);
            gameUI.SetActive(true);
            gameUI.GetComponentInChildren<Button>().Select();
        //}
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
    public void LockingOfPiano()
    {
        if(pianoPart1.isBeat == false)
        {
            pianoComponentTurnOffs.GetComponent<BoxCollider>().enabled = false;
            //pianoComponentTurnOffs.GetComponent<Button>().enabled = false;
           

        }
        else if(pianoPart1 == true)
        {
            pianoComponentTurnOffs.GetComponent<BoxCollider>().enabled = true;
            //pianoComponentTurnOffs.GetComponent<Button>().enabled = true;
            
            pianoPart2.isBeat = true;
            pianoPart3.isBeat = true;
            pianoPart4.isBeat = true;
        }
    }
}