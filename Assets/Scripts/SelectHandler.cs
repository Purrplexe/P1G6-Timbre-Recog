using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectHandler : MonoBehaviour
{
    public GameController controller;
    public int buttonID;
     public void OnClick()
    {
        controller.ButtonClicked(buttonID);
    }

}
