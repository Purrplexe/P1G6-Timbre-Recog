using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectHandler : MonoBehaviour, ISelectHandler
{
    public GameController controller;
    public int buttonID;
     public void OnSelect(BaseEventData eventData)
    {
        controller.InstrumentSelected(buttonID);
    }

}