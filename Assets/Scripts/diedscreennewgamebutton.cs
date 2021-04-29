using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diedscreennewgamebutton : MonoBehaviour
{
    public void buttonclicked()
    {
        GameManager.instance.gameState = GameManager.GameState.Loading;
    }
}