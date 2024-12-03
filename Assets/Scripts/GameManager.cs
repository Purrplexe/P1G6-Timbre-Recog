using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static System.TimeZoneInfo;

public class GameManager : MonoBehaviour
{
    [Header("UI objects")]

    // [SerializeField] private TMPro.TextMeshProUGUI timeText;
    // [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    public GameObject background;
    public GameObject Info1;
    public GameObject Info2;
    public GameObject Info3;
    public GameObject button1;
    public GameObject buttonReturn;
    public GameObject cameraMain;
    public GameObject confirmationPrompt;
    public bool transitioned = false;
    public float timerForTransition;

    //For later
    
    public GameObject[] turnOffs;
    public GameObject currentObject;
    private Dictionary<string, int> instrumentToID = new Dictionary<string, int>();


    public GameObject gameUI;
    public GameController gameController;

    [Header("Guitar")]
    public GameObject buttonGuitar;
    [Header("Guitar Cams")]
    public GameObject cameraGuitar;
    public GameObject cameraGuitarGame;

    [Header("Piano")]
    public GameObject buttonPiano;
    [Header("Piano Cams")]
    public GameObject cameraPiano;
    public GameObject cameraPianoGame;

    [Header("Drums")]
    public GameObject buttonDrums;
    [Header("Drums Cams")]
    public GameObject cameraDrums;
    public GameObject cameraDrumsGame;

    [Header("Trombone")]
    public GameObject buttonTrombone;
    [Header("Trombone Cams")]
    public GameObject cameraTrombone;
    public GameObject cameraTromboneGame;

    [Header("Cello")]
    public GameObject buttonCello;
    [Header("Cello Cams")]
    public GameObject cameraCello;
    public GameObject cameraCelloGame;

    [Header("Xylophone")]
    public GameObject buttonXylophone;
    [Header("Xylophone Cams")]
    public GameObject cameraXylophone;
    public GameObject cameraXylophoneGame;

    // Hardcoded variables you may want to tune.
    //private float startingTime = 30f;

    // Global variables



    /* public void Awake()
     {
         background.SetActive(false);
         Info1.SetActive(false);
         Info2.SetActive(false);
         Info3.SetActive(false);
         button1.SetActive(false);
         button2.SetActive(false);

     }*/
    // This is public so the play button can see it.
    public void Awake()
    {
        // Hide/show the UI elements we don't/do want to see.

        bindInstruments();
        background.SetActive(true);
        Info1.SetActive(true);
        Info2.SetActive(false);
        Info3.SetActive(false);
        button1.SetActive(true);
        
        buttonReturn.SetActive(false);
        cameraMain.SetActive(true);
        
        buttonGuitar.SetActive(false);
        cameraGuitar.SetActive(false);
        cameraGuitarGame.SetActive(false);
        

        buttonPiano.SetActive(false);
        cameraPiano.SetActive(false);
        cameraPianoGame.SetActive(false);

        buttonDrums.SetActive(false);
        cameraDrums.SetActive(false);
        cameraDrumsGame.SetActive(false);

        buttonTrombone.SetActive(false);
        cameraTrombone.SetActive(false);
        cameraTromboneGame.SetActive(false);

        buttonCello.SetActive(false);
        cameraCello.SetActive(false);
        cameraCelloGame.SetActive(false);

        buttonXylophone.SetActive(false);
        cameraXylophone.SetActive(false);
        cameraXylophoneGame.SetActive(false);




        //transitioned = false;
        

    }
    public void bindInstruments()
    {
        for (int i = 0; i < gameController.instruments.Length; i++)
        {
            instrumentToID.Add(gameController.instruments[i].name, i);
        }
    }
    public void Canner()
    {
        background.SetActive(false);
        Info1.SetActive(false);
        Info2.SetActive(true);
        Info3.SetActive(true);
        button1.SetActive(false);
        //button2.SetActive(true);
    }
    public void MainToGuitarSelect()
    {
        //cameraMain.SetActive(false);
        cameraGuitar.SetActive(true);
        buttonGuitar.SetActive(true);
        buttonReturn.SetActive(true);
        
    }
    public void PlayGuitar()
    {
        gameController.setCorrectInstrument(instrumentToID["Guitar"]);
        buttonGuitar.SetActive(false);
        cameraGuitar.SetActive(false);
        Info2.SetActive(false);
        Info3.SetActive(false);
        //transitionScreen.SetActive(true);
       
        
        cameraGuitarGame.SetActive(true);
        gameUI.SetActive(true);
            buttonReturn.SetActive(true);
            //transitioned = false;
        
        
        
        //transitionScreen.SetActive(false); 
    }
    public void MainToPianoSelect()
    {
        //cameraMain.SetActive(false);
        cameraPiano.SetActive(true);
        buttonPiano.SetActive(true);
        buttonReturn.SetActive(true);

    }
    public void PlayPiano()
    {
        gameController.setCorrectInstrument(instrumentToID["Piano"]);
        gameController.SelectReplay();
        buttonPiano.SetActive(false);
        cameraPiano.SetActive(false);
        Info2.SetActive(false);
        Info3.SetActive(false);
        //transitionScreen.SetActive(true);


        cameraPianoGame.SetActive(true);
        gameUI.SetActive(true);
        buttonReturn.SetActive(true);
        //transitioned = false;
        //transitionScreen.SetActive(false); 
    }
    public void MainToCelloSelect()
    {
        //cameraMain.SetActive(false);
        cameraCello.SetActive(true);
        buttonCello.SetActive(true);
        buttonReturn.SetActive(true);

    }

    public void MainToDrumsSelect()
    {
        //cameraMain.SetActive(false);
        cameraDrums.SetActive(true);
        buttonDrums.SetActive(true);
        buttonReturn.SetActive(true);

    }
    public void PlayDrums()
    {
        gameController.setCorrectInstrument(instrumentToID["Drum"]);
        gameController.SelectReplay();
        buttonDrums.SetActive(false);
        cameraDrums.SetActive(false);
        Info2.SetActive(false);
        Info3.SetActive(false);
        //transitionScreen.SetActive(true);


        cameraDrumsGame.SetActive(true);
        gameUI.SetActive(true);
        buttonReturn.SetActive(true);
        //transitioned = false;
        //transitionScreen.SetActive(false); 
    }
    public void MainToCongoSelect()
    {
        //cameraMain.SetActive(false);
        cameraPiano.SetActive(true);
        buttonPiano.SetActive(true);
        buttonReturn.SetActive(true);

    }
   
    public void MainToXylophoneSelect()
    {
        //cameraMain.SetActive(false);
       
        cameraXylophone.SetActive(true);
        buttonXylophone.SetActive(true);
        buttonReturn.SetActive(true);

    }
    public void PlayXylophone()
    {
        gameController.setCorrectInstrument(instrumentToID["Xylophone"]);
        gameController.SelectReplay();
        buttonXylophone.SetActive(false);
        cameraXylophone.SetActive(false);
        Info2.SetActive(false);
        Info3.SetActive(false);
        //transitionScreen.SetActive(true);


        cameraXylophoneGame.SetActive(true);
        gameUI.SetActive(true);
        buttonReturn.SetActive(true);
        //transitioned = false;
        //transitionScreen.SetActive(false); 
    }
    public void MainToTromboneSelect()
    {
        //cameraMain.SetActive(false);
        cameraTrombone.SetActive(true);
        buttonTrombone.SetActive(true);
        buttonReturn.SetActive(true);

    }
    public void PlayTrombone()
    {
        buttonTrombone.SetActive(false);
        cameraTrombone.SetActive(false);
        Info2.SetActive(false);
        Info3.SetActive(false);
        //transitionScreen.SetActive(true);


        cameraTromboneGame.SetActive(true);
        gameUI.SetActive(true);
        buttonReturn.SetActive(true);
        //transitioned = false;
        //transitionScreen.SetActive(false); 
    }
    public void ReturnToHub()
    {
        //transitionScreen.SetActive(true);
        /*foreach(GameObject tagged in turnOffs)
        {
            tagged.SetActive(false);
            break;
        }*/
        /*cameraGuitarGame.SetActive(false);
        guitarCanvas.SetActive(false);
        cameraGuitar.SetActive(false);
        
        
        buttonGuitar.SetActive(false);*/
        buttonReturn.SetActive(false);
        gameUI.SetActive(false);
        buttonGuitar.SetActive(false);
        cameraGuitar.SetActive(false);
        cameraGuitarGame.SetActive(false);

        gameUI.SetActive(false);
        buttonPiano.SetActive(false);
        cameraPiano.SetActive(false);
        cameraPianoGame.SetActive(false);

        gameUI.SetActive(false);
        buttonDrums.SetActive(false);
        cameraDrums.SetActive(false);
        cameraDrumsGame.SetActive(false);

        gameUI.SetActive(false);

        gameUI.SetActive(false);
        buttonTrombone.SetActive(false);
        cameraTrombone.SetActive(false);
        cameraTromboneGame.SetActive(false);

        gameUI.SetActive(false);
        buttonCello.SetActive(false);
        cameraCello.SetActive(false);
        cameraCelloGame.SetActive(false);

        gameUI.SetActive(false);
        buttonXylophone.SetActive(false);
        cameraXylophone.SetActive(false);
        cameraXylophoneGame.SetActive(false);
        Info2.SetActive(true);
        Info3.SetActive(true);
        cameraMain.SetActive(true);
        Debug.Log("returned and falsed");
        //transitionScreen.SetActive(false);
    }

}