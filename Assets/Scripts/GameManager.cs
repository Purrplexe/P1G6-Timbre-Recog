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
    public GameObject transitionScreen;
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
    

    [Header("Guitar")]
    public GameObject guitarCanvas;
    public GameObject buttonGuitar;
    [Header("Guitar Cams")]
    public GameObject cameraGuitar;
    public GameObject cameraGuitarGame;

    [Header("Piano")]
    public GameObject pianoCanvas;
    public GameObject buttonPiano;
    public MaterialChanger changerPiano1;
    public MaterialChanger changerPiano2;
    public MaterialChanger changerPiano3;
    public MaterialChanger changerPiano4;
    [Header("Piano Cams")]
    public GameObject cameraPiano;
    public GameObject cameraPianoGame;

    [Header("Drums")]
    public GameObject drumsCanvas;
    public GameObject buttonDrums;
    [Header("Drums Cams")]
    public GameObject cameraDrums;
    public GameObject cameraDrumsGame;

    [Header("Trombone")]
    public GameObject tromboneCanvas;
    public GameObject buttonTrombone;
    [Header("Trombone Cams")]
    public GameObject cameraTrombone;
    public GameObject cameraTromboneGame;

    [Header("Cello")]
    public GameObject celloCanvas;
    public GameObject buttonCello;
    [Header("Cello Cams")]
    public GameObject cameraCello;
    public GameObject cameraCelloGame;

    [Header("Xylophone")]
    public GameObject xylophoneCanvas;
    public GameObject buttonXylophone;
    [Header("Xylophone Cams")]
    public GameObject cameraXylophone;
    public GameObject cameraXylophoneGame;

    [Header("Congo Drum")]
    public GameObject congoCanvas;
    public GameObject buttonCongo;
    [Header("Congo Cams")]
    public GameObject cameraCongo;
    public GameObject cameraCongoGame;
    
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
        
        background.SetActive(true);
        transitionScreen.SetActive(false);
        Info1.SetActive(true);
        Info2.SetActive(false);
        Info3.SetActive(false);
        button1.SetActive(true);
        
        buttonReturn.SetActive(false);
        cameraMain.SetActive(true);
        
        guitarCanvas.SetActive(false);
        buttonGuitar.SetActive(false);
        cameraGuitar.SetActive(false);
        cameraGuitarGame.SetActive(false);
        
        pianoCanvas.SetActive(false);
        buttonPiano.SetActive(false);
        cameraPiano.SetActive(false);
        cameraPianoGame.SetActive(false);

        drumsCanvas.SetActive(false);
        buttonDrums.SetActive(false);
        cameraDrums.SetActive(false);
        cameraDrumsGame.SetActive(false);

        congoCanvas.SetActive(false);
        buttonCongo.SetActive(false);
        cameraCongo.SetActive(false);
        cameraCongoGame.SetActive(false);

        tromboneCanvas.SetActive(false);
        buttonTrombone.SetActive(false);
        cameraTrombone.SetActive(false);
        cameraTromboneGame.SetActive(false);

        celloCanvas.SetActive(false);
        buttonCello.SetActive(false);
        cameraCello.SetActive(false);
        cameraCelloGame.SetActive(false);

        xylophoneCanvas.SetActive(false);
        buttonXylophone.SetActive(false);
        cameraXylophone.SetActive(false);
        cameraXylophoneGame.SetActive(false);




        //transitioned = false;
        

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
        buttonGuitar.SetActive(false);
        cameraGuitar.SetActive(false);
        Info2.SetActive(false);
        Info3.SetActive(false);
        //transitionScreen.SetActive(true);
        StartCoroutine (TransitionScreen());
       
        
        cameraGuitarGame.SetActive(true);
        guitarCanvas.SetActive(true);
            buttonReturn.SetActive(true);
        changerPiano1.isBeat = true;
        changerPiano2.isBeat = true;
        changerPiano3.isBeat = true;
        changerPiano4.isBeat = true;
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
        buttonPiano.SetActive(false);
        cameraPiano.SetActive(false);
        Info2.SetActive(false);
        Info3.SetActive(false);
        //transitionScreen.SetActive(true);
        StartCoroutine(TransitionScreen());


        cameraPianoGame.SetActive(true);
        pianoCanvas.SetActive(true);
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
    public void PlayCello()
    {
        buttonCello.SetActive(false);
        cameraCello.SetActive(false);
        Info2.SetActive(false);
        Info3.SetActive(false);
        //transitionScreen.SetActive(true);
        StartCoroutine(TransitionScreen());


        cameraCelloGame.SetActive(true);
        celloCanvas.SetActive(true);
        buttonReturn.SetActive(true);
        //transitioned = false;
        //transitionScreen.SetActive(false); 
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
        buttonDrums.SetActive(false);
        cameraDrums.SetActive(false);
        Info2.SetActive(false);
        Info3.SetActive(false);
        //transitionScreen.SetActive(true);
        StartCoroutine(TransitionScreen());


        cameraDrumsGame.SetActive(true);
        drumsCanvas.SetActive(true);
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
    public void PlayCongo()
    {
        buttonCongo.SetActive(false);
        cameraCongo.SetActive(false);
        Info2.SetActive(false);
        Info3.SetActive(false);
        //transitionScreen.SetActive(true);
        StartCoroutine(TransitionScreen());


        cameraCongoGame.SetActive(true);
        congoCanvas.SetActive(true);
        buttonReturn.SetActive(true);
        //transitioned = false;
        //transitionScreen.SetActive(false); 
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
        buttonXylophone.SetActive(false);
        cameraXylophone.SetActive(false);
        Info2.SetActive(false);
        Info3.SetActive(false);
        //transitionScreen.SetActive(true);
        StartCoroutine(TransitionScreen());


        cameraXylophoneGame.SetActive(true);
        xylophoneCanvas.SetActive(true);
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
        StartCoroutine(TransitionScreen());


        cameraTromboneGame.SetActive(true);
        tromboneCanvas.SetActive(true);
        buttonReturn.SetActive(true);
        //transitioned = false;
        //transitionScreen.SetActive(false); 
    }
    public void ReturnToHub()
    {
        //transitionScreen.SetActive(true);
        StartCoroutine(TransitionScreen());
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
        guitarCanvas.SetActive(false);
        buttonGuitar.SetActive(false);
        cameraGuitar.SetActive(false);
        cameraGuitarGame.SetActive(false);

        pianoCanvas.SetActive(false);
        buttonPiano.SetActive(false);
        cameraPiano.SetActive(false);
        cameraPianoGame.SetActive(false);

        drumsCanvas.SetActive(false);
        buttonDrums.SetActive(false);
        cameraDrums.SetActive(false);
        cameraDrumsGame.SetActive(false);

        congoCanvas.SetActive(false);
        buttonCongo.SetActive(false);
        cameraCongo.SetActive(false);
        cameraCongoGame.SetActive(false);

        tromboneCanvas.SetActive(false);
        buttonTrombone.SetActive(false);
        cameraTrombone.SetActive(false);
        cameraTromboneGame.SetActive(false);

        celloCanvas.SetActive(false);
        buttonCello.SetActive(false);
        cameraCello.SetActive(false);
        cameraCelloGame.SetActive(false);

        xylophoneCanvas.SetActive(false);
        buttonXylophone.SetActive(false);
        cameraXylophone.SetActive(false);
        cameraXylophoneGame.SetActive(false);
        Info2.SetActive(true);
        Info3.SetActive(true);
        cameraMain.SetActive(true);
        Debug.Log("returned and falsed");
        //transitionScreen.SetActive(false);
    }
    public IEnumerator TransitionScreen()
    {
        transitionScreen.SetActive(true);
        //transitioned = true;
        yield return new WaitForSeconds(timerForTransition);
        transitionScreen.SetActive(false);
        
    }
}