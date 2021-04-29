using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainmenubuttons : MonoBehaviour
{
    public void buttonStart()
    {
        GameManager.instance.gameState = GameManager.GameState.Loading;
    }
    public void buttonExit()
    {
        GameManager.instance.gameState = GameManager.GameState.GameExit;
    }
}