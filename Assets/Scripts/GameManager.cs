using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static System.TimeZoneInfo;

public class GameManager : MonoBehaviour
{
    //[SerializeField] private List<Mole> moles;

    [Header("UI objects")]

    // [SerializeField] private TMPro.TextMeshProUGUI timeText;
    // [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    public GameObject background;
    public GameObject transitionScreen;
    public GameObject Info1;
    public GameObject Info2;
    public GameObject Info3;
    public GameObject button1;
    public GameObject guitarCanvas;
    public GameObject buttonGuitar;
    public GameObject buttonReturn;
    public GameObject cameraMain;
    public GameObject cameraGuitar;
    public GameObject cameraGuitarGame;
    public bool transitioned = false;
    public float timerForTransition;
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
        buttonGuitar.SetActive(false);
        buttonReturn.SetActive(false);
        //button2.SetActive(false);
        cameraMain.SetActive(true);
        cameraGuitar.SetActive(false);
        cameraGuitarGame.SetActive(false);
        guitarCanvas.SetActive(false);
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
            //transitioned = false;
        
        
        
        //transitionScreen.SetActive(false); 
    }
    public void ReturnToHub()
    {
        //transitionScreen.SetActive(true);
        StartCoroutine(TransitionScreen());
        cameraGuitarGame.SetActive(false);
        guitarCanvas.SetActive(false);
        cameraGuitar.SetActive(false);
        cameraMain.SetActive(true);
        buttonReturn.SetActive(false);
        buttonGuitar.SetActive(false);
        Info2.SetActive(true);
        Info3.SetActive(true);
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