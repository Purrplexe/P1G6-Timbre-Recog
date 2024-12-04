using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    public Material newMaterialRef;
    public Material originalMaterial;
    public bool isBeat = false;
    private GameManager gameManager;
    public void Start()
    {
        GetComponent<Renderer>().material = newMaterialRef;
        isBeat = false;

    }
    public void Update()
    {
        if(isBeat == true)
        {
            GetComponent<Renderer>().material = originalMaterial;
        }
        
    }
}
