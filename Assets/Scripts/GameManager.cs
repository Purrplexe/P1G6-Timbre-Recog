using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
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
    public bool transitioned = false;
    public float timerForTransition;
    private string selectedInstrument;
    //For later
    public GameObject[] turnOffs;
    public GameObject currentObject;
    private Dictionary<string, int> instrumentToID = new Dictionary<string, int>();


    public GameObject gameUI;
    public GameController gameController;

    [Header("scenes")]
    public PlayScene[] scenes;

    private void Awake()
    {
        BindInstruments();
    }
    public void BindInstruments()
    {
        for (int i = 0; i < gameController.instruments.Length; i++)
        {
            instrumentToID.Add(gameController.instruments[i].name.ToLower(), i);
        }
    }
    public void Canner()
    {
        background.SetActive(false);
        button1.SetActive(false);
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
        return -1;
    }
    public void SelectInstrument(string instrument)
    {
        Debug.Log(instrument + " clicked");
        instrument = instrument.ToLower();
        currentScene = scenes[GetSceneIndex(instrument)];
        currentScene.selectCamera.SetActive(true);
        selectedInstrument = instrument;
        currentScene.selectCamera.SetActive(true);
        //get second childs text which is the play button
        confirmationPrompt.GetComponentsInChildren<TMP_Text>()[1].text = "Play the " + instrument + "!";
        confirmationPrompt.SetActive(true);
        
    }
    public void PlayInstrument(string instrument)
    {
        instrument = instrument.ToLower();
        gameController.setCorrectInstrument(instrumentToID[instrument]);
        confirmationPrompt.SetActive(false) ;
        currentScene.gameCamera.SetActive(true);
        gameUI.SetActive(true);
    }


    public void ReturnToHub()
    {

        gameUI.SetActive(false);
        cameraMain.SetActive(true);
        Debug.Log("returned and falsed");
        //transitionScreen.SetActive(false);
    }

}