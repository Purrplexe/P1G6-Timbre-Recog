using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    public Material newMaterialRef;
    public Material originalMaterial;
    public bool isBeat = false;
    public bool guitarUnlock = true;
    public bool pianoUnlock = false;
    public bool drumsUnlock = false;
    private GameManager gameManager;
    public void Start()
    {
        GetComponent<Renderer>().material = newMaterialRef;
        //isBeat = false;
        guitarUnlock = true;
        pianoUnlock = false;
        drumsUnlock = false;

    }
    public void Update()
    {
        if(pianoUnlock == true)
        {
            GetComponent<Renderer>().material = originalMaterial;
        }
        else if(drumsUnlock == true)
        {
            GetComponent<Renderer>().material = originalMaterial;
        }
        
    }
    public void GuitarWon()
    {
        pianoUnlock = true;
    }
    public void PianoWon()
    {
        drumsUnlock = true;
    }
}
