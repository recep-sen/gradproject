using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diedscreenexitbutton : MonoBehaviour
{
    public void Buttonclicked()
    {
        GameManager.instance.gameState = GameManager.GameState.Gotomenu;
    }
}