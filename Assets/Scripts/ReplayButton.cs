using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayButton : MonoBehaviour
{
    public GameController controller;
    public void OnClick()
    {
        controller.Replay();
    }
}
