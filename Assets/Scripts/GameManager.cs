using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[SerializeField] private List<Mole> moles;

    [Header("UI objects")]

    // [SerializeField] private TMPro.TextMeshProUGUI timeText;
    // [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    public GameObject background;
    public GameObject Info1;
    public GameObject Info2;
    public GameObject Info3;
    public GameObject button1;
    public GameObject button2;
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
        Info1.SetActive(true);
        Info2.SetActive(false);
        Info3.SetActive(false);
        button1.SetActive(true);
        button2.SetActive(false);



    }
    public void Canner()
    {
        background.SetActive(false);
        Info1.SetActive(false);
        Info2.SetActive(true);
        Info3.SetActive(true);
        button1.SetActive(false);
        button2.SetActive(true);
    }
}